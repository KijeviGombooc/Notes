namespace Notes
{
    partial class SettingsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 200);
            this.Text = "Settings";

            openKeyLabel = new System.Windows.Forms.Label();
            openKeyLabel.Location = new System.Drawing.Point(0, 20);
            openKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            openKeyLabel.Size = new System.Drawing.Size(120, openKeyLabel.Size.Height);
            this.Controls.Add(openKeyLabel);

            openKeyCheckBox = new System.Windows.Forms.CheckBox();
            openKeyCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            openKeyCheckBox.Location = new System.Drawing.Point(120, 20);
            openKeyCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            openKeyCheckBox.CheckedChanged += OnKeyButtonCheckChanged;
            this.Controls.Add(openKeyCheckBox);

            openKeyFunctionLabel = new System.Windows.Forms.Label();
            openKeyFunctionLabel.Text = "Open key function:";
            openKeyFunctionLabel.Location = new System.Drawing.Point(0, 60);
            openKeyFunctionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            openKeyFunctionLabel.Size = new System.Drawing.Size(120, openKeyFunctionLabel.Size.Height);
            this.Controls.Add(openKeyFunctionLabel);

            openKeyFunctionButton = new System.Windows.Forms.Button();
            openKeyFunctionButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            openKeyFunctionButton.Location = new System.Drawing.Point(120, 60);
            openKeyFunctionButton.Size = openKeyCheckBox.Size;
            openKeyFunctionButton.Click += OnOpenKeyFunctionButtonPressed;
            this.Controls.Add(openKeyFunctionButton);
        }

        private System.Windows.Forms.Label openKeyLabel;
        private System.Windows.Forms.CheckBox openKeyCheckBox;
        private System.Windows.Forms.Label openKeyFunctionLabel;
        private System.Windows.Forms.Button openKeyFunctionButton;
        
        #endregion
    }
}

