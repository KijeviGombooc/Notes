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
        private static IntPtr lastWindow;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //Init app
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                //Setup hooks
                IKeyboardEvents kbEvents = Hook.GlobalEvents();
                kbEvents.KeyDown += OnGlobalKeyDown;
                WindowHook.Instance.WindowChanged += OnWindowChanged;
                lastWindow = WindowHook.Instance.GetForegroundWindowHandle();
            
                //Load icon
                Assembly assembly = typeof(NotesForm).GetTypeInfo().Assembly;
                Stream iconByteStream = assembly.GetManifestResourceStream(iconResource);
                Icon icon = new Icon(iconByteStream);

                //Init notes form
                notesForm = new NotesForm();
                notesForm.NoteIcon = icon;
                if(File.Exists(fileName))
                    notesForm.Note = File.ReadAllText(fileName);

                //Run the app
                Application.Run();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void OnWindowChanged(object sender, WindowHook.WindowChangedEventArgs e)
        {
            if(e.handle != notesForm.Handle)
                lastWindow = e.handle;
        }

        private static void OnGlobalKeyDown(object sender, WindowsHook.KeyEventArgs e)
        {
            e.Handled = true;
            if(e.KeyCode == Settings.OpenKey)
            {
                if(notesForm.Visible)
                {
                    if(Settings.OpenKeyFunctionWhenOpen == SettingsData.KeyFunction.CLOSE)
                        HideAndSaveForm();
                    else if(Settings.OpenKeyFunctionWhenOpen == SettingsData.KeyFunction.TOGGLEFOCUS)
                    {
                        if(WindowHook.Instance.GetForegroundWindowHandle() == notesForm.Handle)
                            WindowHook.Instance.SetForegroundWindowByHandle(lastWindow);
                        else
                            ShowForm();
                    }
                    else
                    {
                        Exceptions.ShowMessage(Exceptions.ExceptionCode.KeyFunctionDoesntExist);
                    }
                }
                else
                    ShowAndLoadForm();
            }
            else if(e.KeyCode == WindowsHook.Keys.Escape)
            {
                if(notesForm.Visible)
                    HideAndSaveForm();
                else
                    e.Handled = false;
            }
            else
            {
                e.Handled = false;
            }
        }

        private static void ShowForm()
        {
            WindowHook.Instance.GrabInputFocus(IntPtr.Zero);
            notesForm.Show();
            notesForm.Activate();
        }

        private static void ShowAndLoadForm()
        {
            if(File.Exists(fileName))
                notesForm.Note = File.ReadAllText(fileName);
            notesForm.SelectionStart = Settings.SelectionStart;
            notesForm.SelectionLength = Settings.SelectionLength;
            ShowForm();
        }

        private static void HideAndSaveForm()
        {
            File.WriteAllText(fileName, notesForm.Note);
            Settings.SelectionStart = notesForm.SelectionStart;
            Settings.SelectionLength = notesForm.SelectionLength;
            notesForm.Hide();
        }
    }
}
