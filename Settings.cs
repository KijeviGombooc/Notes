using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Notes
{
    static class Settings
    {
        private const string settingsFileName = "settings.json";
        private static SettingsData _settingsData;
        private static SettingsData SettingsData
        {
            get
            {
                if(_settingsData == null)
                {
                    if(File.Exists(settingsFileName))
                    {
                        _settingsData = JsonSerializer.Deserialize<SettingsData>(File.ReadAllText(settingsFileName));
                    }
                    else
                    {
                        _settingsData = new SettingsData
                        {
                            OpenKey = WindowsHook.Keys.F13
                        };
                    }
                }
                return _settingsData;
            }
        }
        public static WindowsHook.Keys OpenKey
        {
            get 
            {
                return SettingsData.OpenKey;
            }
            set
            {
                SettingsData.OpenKey = value;
                string data = JsonSerializer.Serialize(SettingsData);
                File.WriteAllText(settingsFileName, data);
            }
        }

        public static int SelectionStart
        {
            get 
            {
                return SettingsData.SelectionStart;
            }
            set
            {
                SettingsData.SelectionStart = value;
                string data = JsonSerializer.Serialize(SettingsData);
                File.WriteAllText(settingsFileName, data);
            }
        }

        public static int SelectionLength
        {
            get 
            {
                return SettingsData.SelectionLength;
            }
            set
            {
                SettingsData.SelectionLength = value;
                string data = JsonSerializer.Serialize(SettingsData);
                File.WriteAllText(settingsFileName, data);
            }
        }
    }
}