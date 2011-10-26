using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ShadowTester
{
    public class ProcessHandler : IProcessHandler
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public string GetCurrentProcess()
        {
            uint processId;
            string processName = null;
            IntPtr hWnd = GetForegroundWindow();
            if (GetWindowThreadProcessId(hWnd, out processId) != 0)
            {
                try
                {
                    Process process = Process.GetProcessById((int)processId);
                    processName = process.ProcessName;
                }
                catch (SystemException) { }
            }
            return processName;
        }

    }
}