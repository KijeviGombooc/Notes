using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsHook;

namespace Notes
{
    static class Program
    {
        private const string fileName = "data.txt";
        private static NotesForm notesForm;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                System.Console.WriteLine();
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SetupHook();
                notesForm = new NotesForm();
                Application.Run(notesForm);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }

        private static void SetupHook()
        {
            IKeyboardEvents kbEvents = Hook.GlobalEvents();
            kbEvents.KeyDown += OnGlobalKeyDown;
        }

        private static void OnGlobalKeyDown(object sender, WindowsHook.KeyEventArgs e)
        {
            if(notesForm.Visible && (e.KeyCode == WindowsHook.Keys.F13 || e.KeyCode == WindowsHook.Keys.Escape))
            {
                File.WriteAllText(fileName, notesForm.Note);
                notesForm.Hide();
            }
            else if(!notesForm.Visible && e.KeyCode == WindowsHook.Keys.F13)
            {
                notesForm.Note = File.ReadAllText(fileName);
                notesForm.Show();
            }
        }
    }
}
