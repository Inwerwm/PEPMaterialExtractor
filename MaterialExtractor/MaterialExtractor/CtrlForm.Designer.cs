namespace MaterialExtractor
{
    partial class CtrlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxMaterial = new System.Windows.Forms.ListBox();
            this.textBoxModelName = new System.Windows.Forms.TextBox();
            this.textBoxModelText = new System.Windows.Forms.TextBox();
            this.checkBoxMorph = new System.Windows.Forms.CheckBox();
            this.checkBoxBone = new System.Windows.Forms.CheckBox();
            this.labelModelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxPhysics = new System.Windows.Forms.CheckBox();
            this.radioRelationBone = new System.Windows.Forms.RadioButton();
            this.radioAllBone = new System.Windows.Forms.RadioButton();
            this.radioRelationBoneAndParent = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonReload = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxMaterial
            // 
            this.listBoxMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxMaterial.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listBoxMaterial.FormattingEnabled = true;
            this.listBoxMaterial.ItemHeight = 21;
            this.listBoxMaterial.Location = new System.Drawing.Point(4, 5);
            this.listBoxMaterial.Name = "listBoxMaterial";
            this.listBoxMaterial.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMaterial.Size = new System.Drawing.Size(246, 340);
            this.listBoxMaterial.TabIndex = 0;
            // 
            // textBoxModelName
            // 
            this.textBoxModelName.Location = new System.Drawing.Point(365, 8);
            this.textBoxModelName.Name = "textBoxModelName";
            this.textBoxModelName.Size = new System.Drawing.Size(366, 19);
            this.textBoxModelName.TabIndex = 1;
            // 
            // textBoxModelText
            // 
            this.textBoxModelText.Location = new System.Drawing.Point(365, 33);
            this.textBoxModelText.Multiline = true;
            this.textBoxModelText.Name = "textBoxModelText";
            this.textBoxModelText.Size = new System.Drawing.Size(366, 122);
            this.textBoxModelText.TabIndex = 2;
            // 
            // checkBoxMorph
            // 
            this.checkBoxMorph.AutoSize = true;
            this.checkBoxMorph.Checked = true;
            this.checkBoxMorph.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMorph.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxMorph.Location = new System.Drawing.Point(6, 28);
            this.checkBoxMorph.Name = "checkBoxMorph";
            this.checkBoxMorph.Size = new System.Drawing.Size(62, 25);
            this.checkBoxMorph.TabIndex = 3;
            this.checkBoxMorph.Text = "モーフ";
            this.checkBoxMorph.UseVisualStyleBackColor = true;
            // 
            // checkBoxBone
            // 
            this.checkBoxBone.AutoSize = true;
            this.checkBoxBone.Checked = true;
            this.checkBoxBone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBone.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxBone.Location = new System.Drawing.Point(6, 59);
            this.checkBoxBone.Name = "checkBoxBone";
            this.checkBoxBone.Size = new System.Drawing.Size(64, 25);
            this.checkBoxBone.TabIndex = 4;
            this.checkBoxBone.Text = "ボーン";
            this.checkBoxBone.UseVisualStyleBackColor = true;
            this.checkBoxBone.CheckedChanged += new System.EventHandler(this.CheckBoxBone_CheckedChanged);
            // 
            // labelModelName
            // 
            this.labelModelName.AutoSize = true;
            this.labelModelName.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelModelName.Location = new System.Drawing.Point(258, 6);
            this.labelModelName.Name = "labelModelName";
            this.labelModelName.Size = new System.Drawing.Size(99, 21);
            this.labelModelName.TabIndex = 6;
            this.labelModelName.Text = "新規モデル名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(258, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "新規コメント:";
            // 
            // buttonExecute
            // 
            this.buttonExecute.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonExecute.Location = new System.Drawing.Point(383, 293);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(348, 52);
            this.buttonExecute.TabIndex = 8;
            this.buttonExecute.Text = "実行";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.ButtonExecute_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBoxPhysics);
            this.groupBox1.Controls.Add(this.checkBoxMorph);
            this.groupBox1.Controls.Add(this.checkBoxBone);
            this.groupBox1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(262, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 121);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "追加取り出し設定";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "┗";
            // 
            // checkBoxPhysics
            // 
            this.checkBoxPhysics.AutoSize = true;
            this.checkBoxPhysics.Location = new System.Drawing.Point(27, 89);
            this.checkBoxPhysics.Name = "checkBoxPhysics";
            this.checkBoxPhysics.Size = new System.Drawing.Size(126, 25);
            this.checkBoxPhysics.TabIndex = 5;
            this.checkBoxPhysics.Text = "剛体・ジョイント";
            this.checkBoxPhysics.UseVisualStyleBackColor = true;
            // 
            // radioRelationBone
            // 
            this.radioRelationBone.AutoSize = true;
            this.radioRelationBone.Checked = true;
            this.radioRelationBone.Location = new System.Drawing.Point(16, 27);
            this.radioRelationBone.Name = "radioRelationBone";
            this.radioRelationBone.Size = new System.Drawing.Size(122, 25);
            this.radioRelationBone.TabIndex = 5;
            this.radioRelationBone.TabStop = true;
            this.radioRelationBone.Text = "関連ボーンのみ";
            this.radioRelationBone.UseVisualStyleBackColor = true;
            // 
            // radioAllBone
            // 
            this.radioAllBone.AutoSize = true;
            this.radioAllBone.Location = new System.Drawing.Point(16, 89);
            this.radioAllBone.Name = "radioAllBone";
            this.radioAllBone.Size = new System.Drawing.Size(104, 25);
            this.radioAllBone.TabIndex = 6;
            this.radioAllBone.Text = "全てのボーン";
            this.radioAllBone.UseVisualStyleBackColor = true;
            // 
            // radioRelationBoneAndParent
            // 
            this.radioRelationBoneAndParent.AutoSize = true;
            this.radioRelationBoneAndParent.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioRelationBoneAndParent.Location = new System.Drawing.Point(16, 58);
            this.radioRelationBoneAndParent.Name = "radioRelationBoneAndParent";
            this.radioRelationBoneAndParent.Size = new System.Drawing.Size(170, 25);
            this.radioRelationBoneAndParent.TabIndex = 7;
            this.radioRelationBoneAndParent.Text = "関連ボーンと親子構造";
            this.radioRelationBoneAndParent.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioRelationBoneAndParent.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioAllBone);
            this.groupBox2.Controls.Add(this.radioRelationBoneAndParent);
            this.groupBox2.Controls.Add(this.radioRelationBone);
            this.groupBox2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(472, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 121);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ボーン取り出し設定";
            // 
            // buttonReload
            // 
            this.buttonReload.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonReload.Location = new System.Drawing.Point(262, 293);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(111, 52);
            this.buttonReload.TabIndex = 11;
            this.buttonReload.Text = "再読込";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.ButtonReload_Click);
            // 
            // CtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 349);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelModelName);
            this.Controls.Add(this.textBoxModelText);
            this.Controls.Add(this.textBoxModelName);
            this.Controls.Add(this.listBoxMaterial);
            this.MaximizeBox = false;
            this.Name = "CtrlForm";
            this.Text = "材質取り出し";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CtrlForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMaterial;
        private System.Windows.Forms.TextBox textBoxModelName;
        private System.Windows.Forms.TextBox textBoxModelText;
        private System.Windows.Forms.CheckBox checkBoxBone;
        private System.Windows.Forms.Label labelModelName;
        private System.Windows.Forms.CheckBox checkBoxMorph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioRelationBone;
        private System.Windows.Forms.RadioButton radioAllBone;
        private System.Windows.Forms.RadioButton radioRelationBoneAndParent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxPhysics;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonReload;
    }
}