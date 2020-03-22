using PEPlugin;
using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MaterialExtractor
{
    public partial class CtrlForm : Form
    {
        IPERunArgs args;
        IPXPmx currentPmx;

        public CtrlForm(IPERunArgs input)
        {
            InitializeComponent();
            args = input;
            currentPmx = args.Host.Connector.Pmx.GetCurrentState();
            listBoxMaterial.Items.AddRange(currentPmx.Material.Select(m => m.Name).ToArray());
            textBoxModelName.Text = currentPmx.ModelInfo.ModelName;
            textBoxModelText.Text = currentPmx.ModelInfo.Comment;
        }

        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            IPXPmx pmx = args.Host.Builder.Pmx.Pmx();

            pmx.ModelInfo.ModelName = textBoxModelName.Text;
            pmx.ModelInfo.Comment = textBoxModelText.Text;

            // 作成したpmxにマテリアルをコピー
            foreach (int i in listBoxMaterial.SelectedIndices)
                pmx.Material.Add(currentPmx.Material[i]);

            // マテリアルに含まれる頂点のリストを作成
            List<IPXVertex> vertices = new List<IPXVertex>();
            foreach (var m in pmx.Material)
            {
                foreach (var f in m.Faces)
                {
                    vertices.Add(f.Vertex1);
                    vertices.Add(f.Vertex2);
                    vertices.Add(f.Vertex3);
                }
            }
            // 重複を除去
            vertices = vertices.Distinct().ToList();
            foreach (var v in vertices)
            {
                pmx.Vertex.Add(v);
            }

            // 頂点のウェイトに基づいてボーンをコピー
            if (checkBoxBone.Checked)
            {
                if (radioAllBone.Checked)
                {
                    foreach (var b in currentPmx.Bone)
                        pmx.Bone.Add(b);
                    if (checkBoxPhysics.Checked)
                    {
                        foreach (var b in currentPmx.Body)
                            pmx.Body.Add(b);
                        foreach (var j in currentPmx.Joint)
                            pmx.Joint.Add(j);
                    }
                }
                else
                {
                    // 元のボーン順を保存
                    Dictionary<IPXBone, int> boneIndex = new Dictionary<IPXBone, int>();
                    for (int i = 0; i < currentPmx.Bone.Count; i++)
                        boneIndex.Add(currentPmx.Bone[i], i);

                    // 関連ボーン
                    List<IPXBone> bones = new List<IPXBone>();
                    foreach (var v in vertices)
                    {
                        if (v.Bone1 != null)
                            bones.Add(v.Bone1);
                        if (v.Bone2 != null)
                            bones.Add(v.Bone2);
                        if (v.Bone3 != null)
                            bones.Add(v.Bone3);
                        if (v.Bone4 != null)
                            bones.Add(v.Bone4);
                    }
                    bones = bones.Distinct().ToList();


                    if (checkBoxPhysics.Checked)
                    {
                        // 関連ボーンの関連剛体
                        List<IPXBody> bodies = new List<IPXBody>();
                        foreach (var b in bones)
                            bodies.AddRange(currentPmx.Body.Where(x => x.Bone == b));
                        bodies = bodies.Distinct().ToList();
                        // 関連剛体の関連ジョイント
                        List<IPXJoint> joints = new List<IPXJoint>();
                        foreach (var b in bodies)
                            joints.AddRange(currentPmx.Joint.Where(x => x.BodyA == b || x.BodyB == b));
                        joints = joints.Distinct().ToList();
                        // ジョイントに必要な剛体がbodiesに不足していた場合追加
                        foreach (var j in joints)
                        {
                            if (!bodies.Any(b => b == j.BodyA))
                                bodies.Add(j.BodyA);
                            if (!bodies.Any(b => b == j.BodyB))
                                bodies.Add(j.BodyB);
                        }
                        // 剛体に必要なボーンがbonesに不足していた場合追加
                        foreach (var b in bodies)
                            if (!bones.Any(x => x == b.Bone))
                                bones.Add(b.Bone);

                        // 剛体・ジョイントの並び順を戻す
                        Dictionary<IPXBody, int> bodyIndex = new Dictionary<IPXBody, int>();
                        for (int i = 0; i < currentPmx.Body.Count; i++)
                            bodyIndex.Add(currentPmx.Body[i], i);
                        Dictionary<IPXJoint, int> jointIndex = new Dictionary<IPXJoint, int>();
                        for (int i = 0; i < currentPmx.Joint.Count; i++)
                            jointIndex.Add(currentPmx.Joint[i], i);

                        bodies.Sort((a, b) => bodyIndex[a] - bodyIndex[b]);
                        joints.Sort((a, b) => jointIndex[a] - jointIndex[b]);

                        foreach (var b in bodies)
                            pmx.Body.Add(b);
                        foreach (var j in joints)
                            pmx.Joint.Add(j);
                    }

                    bones.Sort((a, b) => boneIndex[a] - boneIndex[b]);

                    if (radioRelationBone.Checked)
                        foreach (var b in bones)
                            pmx.Bone.Add(b);

                    if (radioRelationBoneAndParent.Checked)
                    {
                        List<IPXBone> bonesWithParent = new List<IPXBone>();
                        //関連ボーンの親を遡って保持
                        for (int i = 0; i < bones.Count; i++)
                        {
                            IPXBone b = bones[i];
                            IPXBone forcus = b;
                            while (forcus != null)
                            {
                                if (bonesWithParent.Exists(x => x == forcus))
                                    break;
                                bonesWithParent.Add(forcus);
                                if (forcus.AppendParent != null && !bones.Exists(x => x == forcus.AppendParent))
                                    bones.Add(forcus.AppendParent);
                                forcus = forcus.Parent;
                            }
                        }

                        bonesWithParent.Sort((a, b) => boneIndex[a] - boneIndex[b]);
                        foreach (var b in bonesWithParent)
                            pmx.Bone.Add(b);
                    }
                }
            }

            // モーフをコピー
            if (checkBoxMorph.Checked)
            {
                foreach (var m in currentPmx.Morph)
                {
                    IPXMorph morph = m;
                    bool morphExists = true;
                    switch (m.Kind)
                    {
                        case MorphKind.Vertex:
                            List<IPXVertexMorphOffset> vmo = m.Offsets.ToList().ConvertAll(o => (IPXVertexMorphOffset)o);
                            foreach (var o in vmo)
                                if (!vertices.Exists(v => v == o.Vertex))
                                    morph.Offsets.Remove(o);
                            break;
                        case MorphKind.UV:
                        case MorphKind.UVA1:
                        case MorphKind.UVA2:
                        case MorphKind.UVA3:
                        case MorphKind.UVA4:
                            List<IPXUVMorphOffset> umo = m.Offsets.ToList().ConvertAll(o => (IPXUVMorphOffset)o);
                            foreach (var o in umo)
                                if (!vertices.Exists(v => v == o.Vertex))
                                    morph.Offsets.Remove(o);
                            break;
                        case MorphKind.Material:
                            List<IPXMaterialMorphOffset> mmo = m.Offsets.ToList().ConvertAll(o => (IPXMaterialMorphOffset)o);
                            foreach (var o in mmo)
                                if (!pmx.Material.Contains(o.Material))
                                    morph.Offsets.Remove(o);
                            break;
                        default:
                            morphExists = false;
                            break;
                    }
                    if (morphExists && morph.Offsets.Count != 0)
                        pmx.Morph.Add(morph);
                }
            }

            Update(args.Host.Connector, pmx, PmxUpdateObject.All);
            MessageBox.Show("完了");
            Reload();
        }

        private void Update(IPEConnector connector, IPXPmx pmx, PmxUpdateObject option, int index = -1)
        {
            connector.Pmx.Update(pmx, option, index);
            connector.Form.UpdateList(ConvUObjrct_DtoX(option));
            connector.View.PmxView.UpdateModel();
        }

        private PEPlugin.Pmd.UpdateObject ConvUObjrct_DtoX(PmxUpdateObject input)
        {
            PEPlugin.Pmd.UpdateObject output;
            switch (input)
            {
                case PmxUpdateObject.None:
                    output = PEPlugin.Pmd.UpdateObject.None;
                    break;
                case PmxUpdateObject.All:
                    output = PEPlugin.Pmd.UpdateObject.All;
                    break;
                case PmxUpdateObject.Header:
                    output = PEPlugin.Pmd.UpdateObject.Header;
                    break;
                case PmxUpdateObject.ModelInfo:
                    output = PEPlugin.Pmd.UpdateObject.All;
                    break;
                case PmxUpdateObject.Vertex:
                    output = PEPlugin.Pmd.UpdateObject.Vertex;
                    break;
                case PmxUpdateObject.Face:
                    output = PEPlugin.Pmd.UpdateObject.Face;
                    break;
                case PmxUpdateObject.Material:
                    output = PEPlugin.Pmd.UpdateObject.Material;
                    break;
                case PmxUpdateObject.Bone:
                    output = PEPlugin.Pmd.UpdateObject.Bone;
                    break;
                case PmxUpdateObject.Morph:
                    output = PEPlugin.Pmd.UpdateObject.Morph;
                    break;
                case PmxUpdateObject.Node:
                    output = PEPlugin.Pmd.UpdateObject.Node;
                    break;
                case PmxUpdateObject.Body:
                    output = PEPlugin.Pmd.UpdateObject.Body;
                    break;
                case PmxUpdateObject.Joint:
                    output = PEPlugin.Pmd.UpdateObject.Joint;
                    break;
                case PmxUpdateObject.SoftBody:
                    output = PEPlugin.Pmd.UpdateObject.All;
                    break;
                default:
                    output = PEPlugin.Pmd.UpdateObject.All;
                    break;
            }

            return output;
        }

        private void Reload()
        {
            currentPmx = args.Host.Connector.Pmx.GetCurrentState();
            listBoxMaterial.Items.Clear();
            listBoxMaterial.Items.AddRange(currentPmx.Material.Select(m => m.Name).ToArray());
            textBoxModelName.Text = currentPmx.ModelInfo.ModelName;
            textBoxModelText.Text = currentPmx.ModelInfo.Comment;
        }

        private void CheckBoxBone_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxPhysics.Enabled = checkBoxBone.Checked;
            groupBox2.Enabled = checkBoxBone.Checked;
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void CtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                // フォームを非表示設定
                this.Visible = false;
            }
        }
    }
}
