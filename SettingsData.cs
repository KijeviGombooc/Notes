namespace Notes
{
    public class SettingsData
    {
        public enum KeyFunction
        {
            CLOSE,
            TOGGLEFOCUS
        }

        public WindowsHook.Keys OpenKey { get; set; }
        public int SelectionStart { get; set; }
        public int SelectionLength { get; set; }
        public KeyFunction OpenKeyFunctionWhenOpen { get; set; }
    }
}