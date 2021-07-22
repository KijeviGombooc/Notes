using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsHook;

namespace Notes
{
    public partial class NotesForm : Form
    {
        public string Note
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
        private TextBox textBox;

        public NotesForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            SetupTextBox();
            SetupNotifyIcon();
            ShowNotes();
        }

        private void SetupNotifyIcon()
        {
            NotifyIcon notifyIcon = new NotifyIcon(this.components);
            notifyIcon.Icon = new Icon("note_icon.ico");
            notifyIcon.Visible = true;
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem exitToolStripMenuItem = new ToolStripMenuItem("Exit", null, (sender, e) => this.Close(), "Exit");
            contextMenuStrip.Items.Add(exitToolStripMenuItem);
            notifyIcon.ContextMenuStrip = contextMenuStrip;
        }
        
        private void SetupTextBox()
        {
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Size = new Size(this.Size.Width, this.Size.Height);
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.AcceptsTab = true;
            this.Controls.Add(textBox);
        }

        private void ShowNotes()
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width + 5, workingArea.Bottom - Size.Height + 5);
        }
    }
}
