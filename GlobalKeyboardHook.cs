using KDR_Calculator;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/// <summary>
/// ChatGPT Generated Code for keypress detection.
/// Modifed by me to make events and detection work better.
/// Also modified to turn it into a static helper class.
/// </summary>
public static class GlobalKeyboardHook
{
    //Chat GPT Generated Constants
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private const int WM_KEYUP = 0x0101;

    private static LowLevelKeyboardProc _proc;
    private static IntPtr _hookID = IntPtr.Zero;

    /// <summary>
    /// This event is called when a key is pressed down on the keyboard
    /// </summary>
    public static event EventHandler<KeyPressedEventArgs> keyPressed;

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN))
        {
            int vkCode = Marshal.ReadInt32(lParam);
            Keys key = (Keys)vkCode;
            var eventInfo = new KeyPressedEventArgs() { keyPressed = key };
            keyPressed.Invoke(null,eventInfo);

            int supressKey = eventInfo.ShouldSupressKey == true ? 1 : 0;

            return (IntPtr)supressKey;
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    public static void HookKeyboard()
    {
        _proc = HookCallback;
        if (_hookID == IntPtr.Zero)
        {
            _hookID = SetHook(_proc);
        }
    }

    public static void UnhookKeyboard()
    {
        if (_hookID != IntPtr.Zero)
        {
            UnhookWindowsHookEx(_hookID);
            _hookID = IntPtr.Zero;
        }
    }

    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
}
