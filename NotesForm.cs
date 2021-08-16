using System.Drawing;
using System.Windows.Forms;

namespace Notes
{
    public partial class NotesForm : Form
    {
        public string Note
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
        public Icon NoteIcon
        {
            get { return noteIcon; }
            set { SetupNotifyIcon(value); noteIcon = value; } 
        }
        private TextBox textBox;
        private Icon noteIcon;

        public NotesForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            SetupTextBox();
            SetupNotifyIcon(null);
        }

        private void SetupNotifyIcon(Icon icon)
        {
            NotifyIcon notifyIcon = new NotifyIcon(this.components);
            notifyIcon.Icon = icon;
            notifyIcon.Visible = true;
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem settingsToolStripMenuItem = new ToolStripMenuItem("Settings", null,
            (sender, e) =>
            {
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.Show();
            });
            ToolStripMenuItem exitToolStripMenuItem = new ToolStripMenuItem("Exit", null,
            (sender, e) =>
            {
                Application.Exit();
                notifyIcon.Dispose();
            });
            contextMenuStrip.Items.Add(settingsToolStripMenuItem);
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
    }
}
