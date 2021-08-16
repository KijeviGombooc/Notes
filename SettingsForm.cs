using System;
using System.Drawing;
using System.Windows.Forms;

namespace Notes
{
    public partial class SettingsForm : Form
    {

        public SettingsForm()
        {
            InitializeComponent();
            SetCheckBoxText();
            this.KeyDown += ReadKey;
            this.KeyPreview = true;
            SetOpenKeyLabelText();
        }

        private void ReadKey(object sender, KeyEventArgs e)
        {
            if(checkBox.Checked)
            {
                Settings.OpenKey = (WindowsHook.Keys)e.KeyCode;
                checkBox.Checked = false;
                SetOpenKeyLabelText();
            }
        }

        private void SetOpenKeyLabelText()
        {
            openKeyLabel.Text = "Key: " + Settings.OpenKey.ToString();
        }

        private void OnKeyButtonCheckChanged(object sender, EventArgs e)
        {
            SetCheckBoxText();
        }

        private void SetCheckBoxText()
        {
            checkBox.Text = checkBox.Checked ? "Press key" : "Press to set key";
        }
    }
}
