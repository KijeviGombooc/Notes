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

            checkBox = new System.Windows.Forms.CheckBox();
            checkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            checkBox.Location = new System.Drawing.Point(120, 20);
            checkBox.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox.CheckedChanged += OnKeyButtonCheckChanged;
            this.Controls.Add(checkBox);

            openKeyLabel = new System.Windows.Forms.Label();
            openKeyLabel.Location = new System.Drawing.Point(0, 20);
            openKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            openKeyLabel.Size = new System.Drawing.Size(120, openKeyLabel.Size.Height);
            this.Controls.Add(openKeyLabel);
        }

        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label openKeyLabel;
        
        #endregion
    }
}

