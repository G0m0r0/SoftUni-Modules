using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace dllImport
{
    class Program
    {
        [DllImport("user32", EntryPoint = "MessageBox")]
        public static extern int ShowMessageBox(int hWnd, string text, string title, int type);

        [DllImport("user32")]
        public static extern int SetCursorPos(int x,int y);
        static void Main(string[] args)
        {
            ShowMessageBox(0, "Hello students!", "Softuni", 0);
            for (int i = 0; i < 100; i++)
            {
                SetCursorPos(i, i);
                Thread.Sleep(100);
            }
        }
    }
}
