using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WindowsHook;

namespace Notes
{
    static class Program
    {
        private const string fileName = "data.txt";
        private const string iconResource = "Notes.note_icon.ico";
        private static NotesForm notesForm;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                SetupHook();

                Assembly assembly = typeof(NotesForm).GetTypeInfo().Assembly;
                Stream iconByteStream = assembly.GetManifestResourceStream(iconResource);
                Icon icon = new Icon(iconByteStream);

                notesForm = new NotesForm();
                notesForm.NoteIcon = icon;

                if(File.Exists(fileName))
                    notesForm.Note = File.ReadAllText(fileName);
                Application.Run();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void SetupHook()
        {
            IKeyboardEvents kbEvents = Hook.GlobalEvents();
            kbEvents.KeyDown += OnGlobalKeyDown;
        }

        private static void OnGlobalKeyDown(object sender, WindowsHook.KeyEventArgs e)
        {
            if(notesForm.Visible && (e.KeyCode == Settings.OpenKey || e.KeyCode == WindowsHook.Keys.Escape))
            {
                e.Handled = true;
                File.WriteAllText(fileName, notesForm.Note);
                Settings.SelectionStart = notesForm.SelectionStart;
                Settings.SelectionLength = notesForm.SelectionLength;
                notesForm.Hide();
            }
            else if(!notesForm.Visible && e.KeyCode == Settings.OpenKey)
            {
                e.Handled = true;
                if(File.Exists(fileName))
                    notesForm.Note = File.ReadAllText(fileName);
                notesForm.SelectionStart = Settings.SelectionStart;
                notesForm.SelectionLength = Settings.SelectionLength;
                notesForm.Show();
                notesForm.Activate();
            }
        }
    }
}
