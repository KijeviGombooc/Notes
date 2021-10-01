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
            SetOpenKeyCheckboxText();
            this.KeyDown += ReadKey;
            this.KeyPreview = true;
            SetOpenKeyLabelText();
            SetOpenKeyFunctionButtonText();
        }

        private void ReadKey(object sender, KeyEventArgs e)
        {
            if(openKeyCheckBox.Checked)
            {
                Settings.OpenKey = (WindowsHook.Keys)e.KeyCode;
                openKeyCheckBox.Checked = false;
                SetOpenKeyLabelText();
            }
        }

        private void SetOpenKeyLabelText()
        {
            openKeyLabel.Text = "Open key: " + Settings.OpenKey.ToString();
        }

        private void OnKeyButtonCheckChanged(object sender, EventArgs e)
        {
            SetOpenKeyCheckboxText();
        }

        private void SetOpenKeyCheckboxText()
        {
            openKeyCheckBox.Text = openKeyCheckBox.Checked ? "Press key" : "Press to set key";
        }

        private void OnOpenKeyFunctionButtonPressed(object sender, EventArgs e)
        {
            if(Settings.OpenKeyFunctionWhenOpen == SettingsData.KeyFunction.CLOSE)
            {
                Settings.OpenKeyFunctionWhenOpen = SettingsData.KeyFunction.TOGGLEFOCUS;
            }
            else if(Settings.OpenKeyFunctionWhenOpen == SettingsData.KeyFunction.TOGGLEFOCUS)
            {
                Settings.OpenKeyFunctionWhenOpen = SettingsData.KeyFunction.CLOSE;
            }
            else
            {
                Exceptions.ShowMessage(Exceptions.ExceptionCode.KeyFunctionDoesntExist);
            }
            SetOpenKeyFunctionButtonText();
        }

        private void SetOpenKeyFunctionButtonText()
        {
            if(Settings.OpenKeyFunctionWhenOpen == SettingsData.KeyFunction.CLOSE)
            {
                openKeyFunctionButton.Text = "Close";
            }
            else if(Settings.OpenKeyFunctionWhenOpen == SettingsData.KeyFunction.TOGGLEFOCUS)
            {
                openKeyFunctionButton.Text = "Toggle focus";
            }
            else
            {
                Exceptions.ShowMessage(Exceptions.ExceptionCode.KeyFunctionDoesntExist);
            }
        }
    }
}
