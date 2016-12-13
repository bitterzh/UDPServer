using System;
using System.Windows.Forms;

namespace UPDClientForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //System.Diagnostics.Process _RunProcess = System.Diagnostics.Process.GetCurrentProcess();
            //System.Diagnostics.Process[] _Process = System.Diagnostics.Process.GetProcessesByName(_RunProcess.ProcessName);
            //if (_Process.Length == 1)
            //{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UPDClientForm());
            //}
            //else
            //{
            //    MessageBox.Show("程序已经打开!", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
    }
}
