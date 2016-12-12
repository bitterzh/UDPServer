using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer
{
    public partial class SmartYunShangService : ServiceBase
    {
        public SmartYunShangService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            UDBCommon.UDPServer.Init();
        }

        protected override void OnStop()
        {
            UDBCommon.UDPServer.Dispose();
        }
    }
}
