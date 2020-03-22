using PEPlugin;
using System;
using System.Windows.Forms;

namespace MaterialExtractor
{
    public class MaterialExtractor : PEPluginClass
    {
        public MaterialExtractor() : base()
        {
        }

        public override string Name
        {
            get
            {
                return "材質取り出し";
            }
        }

        public override string Version
        {
            get
            {
                return "2";
            }
        }

        public override string Description
        {
            get
            {
                return "ウェイトボーン込で選択材質のみにする";
            }
        }

        public override IPEPluginOption Option
        {
            get
            {
                // boot時実行, プラグインメニューへの登録, メニュー登録名
                return new PEPluginOption(false, true, "材質取り出し");
            }
        }

        public override void Run(IPERunArgs args)
        {
            try
            {
                if (ctrlForm == null)
                {
                    ctrlForm = new CtrlForm(args);
                    ctrlForm.Visible = true;
                }
                else
                {
                    ctrlForm.Visible = !ctrlForm.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override void Dispose()
        {
            if (ctrlForm != null)
            {
                ctrlForm.Close();
                ctrlForm = null;
            }
        }


        CtrlForm ctrlForm;

    }
}
