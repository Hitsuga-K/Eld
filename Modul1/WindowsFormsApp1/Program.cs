using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        // Унаследованный код: вызовы функций Windows API через P/Invoke.
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint message, IntPtr wParam, string lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool Beep(uint frequency, uint duration);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MessageBeep(uint type);

        internal static void ShowPersonalInfo()
        {
            MessageBox(IntPtr.Zero, "ФИО: Максим\nГруппа: укажите свою группу", "Информация обо мне", 0);
            MessageBox(IntPtr.Zero, "Специальность: программирование\nЯ изучаю Windows API и Windows Forms.", "Информация обо мне", 0);
            MessageBox(IntPtr.Zero, "Моё учебное приложение демонстрирует вызовы функций Windows API.", "Информация обо мне", 0);
        }

        internal static IntPtr FindDemoWindow(string title) => FindWindow(null, title);
        internal static void SetWindowTitle(IntPtr handle, string title) => SendMessage(handle, 0x000C, IntPtr.Zero, title); // WM_SETTEXT
        internal static void CloseWindow(IntPtr handle) => SendMessage(handle, 0x0010, IntPtr.Zero, null); // WM_CLOSE
        internal static void PlayBeeps(int count, int interval)
        {
            for (int i = 0; i < count; i++)
            {
                Beep((uint)(500 + i * 150), 250);
                Thread.Sleep(interval);
            }
            MessageBeep(0xFFFFFFFF);
        }
    }
}
