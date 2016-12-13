using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPDServerForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Diagnostics.Process _RunProcess = System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.Process[] _Process = System.Diagnostics.Process.GetProcessesByName(_RunProcess.ProcessName);
            if (_Process.Length == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new UPDServerForm());
            }
            else
            {
                MessageBox.Show("程序已经打开!", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
