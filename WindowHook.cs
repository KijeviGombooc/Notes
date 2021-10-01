using System;
using System.Runtime.InteropServices;

class WindowHook
{
    public EventHandler<WindowChangedEventArgs> WindowChanged;

    public static WindowHook Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new WindowHook();
                Instance.dele = new WinEventDelegate(WinEventProc);
                IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, Instance.dele, 0, 0, WINEVENT_OUTOFCONTEXT);
            }
            return instance;
        }
    }

    public bool SetWindowTopMost(IntPtr handle)
    {
        Rect r = new Rect();
        GetWindowRect(handle, ref r);
        return SetWindowPos(handle, HWND_TOPMOST, r.left, r.top, r.right - r.left, r.bottom - r.top, SWP_NOMOVE | SWP_NOSIZE);
    }

    public IntPtr GetForegroundWindowHandle()
    {
        return GetForegroundWindow();
    }

    public bool SetForegroundWindowByHandle(IntPtr handle)
    {
        return SetForegroundWindow(handle);
    }

    public void GrabInputFocus(IntPtr handle)
    {
        IntPtr foregroundWindowHandle = GetForegroundWindow();
        IntPtr appThread = GetCurrentThreadId();
        IntPtr foregroundThread = GetWindowThreadProcessId(foregroundWindowHandle, IntPtr.Zero);
        AttachThreadInput(foregroundThread, appThread, true);
    }
    
    public class WindowChangedEventArgs : EventArgs
    {
        public IntPtr handle;
    }

    private static WindowHook instance;

    private static void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
    {
        WindowChangedEventArgs e = new WindowChangedEventArgs();
        e.handle = GetForegroundWindow();
        Instance.WindowChanged!.Invoke(Instance, e);
    } 

    private WinEventDelegate dele = null;
    private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
    private const uint WINEVENT_OUTOFCONTEXT = 0;
    private const uint EVENT_SYSTEM_FOREGROUND = 3;
    private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    private const UInt32 SWP_NOSIZE = 0x0001;
    private const UInt32 SWP_NOMOVE = 0x0002;
    [DllImport("user32.dll")] 
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr handle);
    [DllImport("user32.dll")]
    private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr lpdwProcessId);
    [DllImport("Kernel32.dll")]
    private static extern IntPtr GetCurrentThreadId();
    [DllImport("user32.dll")]
    private static extern bool AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, bool fAttach);

    [DllImport("user32.dll")]
    static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

    private struct Rect
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
}