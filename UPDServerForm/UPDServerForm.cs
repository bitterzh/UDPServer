using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using UDBCommon;

namespace UPDServerForm
{
    public partial class UPDServerForm : Form
    {
        private UDPUser server;
        private List<UDPUser> _list;
        public UPDServerForm()
        {
            InitializeComponent();

            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

            server = new UDPUser();
            server.UserIP = ips[ips.Length - 1].ToString();

            UDPGlobal.ServerHost = this.txtHost.Text = server.UserIP;
            this.txtHost.Enabled = false;
            this.txtPort.Text = UDPGlobal.ServerPort.ToString();
            this.txtPort.Enabled = false;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtPort.Text))
            {
                if (UDPServer.Init(UDPGlobal.ServerHost, UDPGlobal.ServerPort, SetMsg))
                {
                    _list = new List<UDPUser>();

                    IPEndPoint _point = ((System.Net.IPEndPoint)UDPServer.Server.Client.LocalEndPoint);
                    TaskManager.NewTask(() => { UDPHelper.StartReceive(UDPServer.Server, SetMsg); });
                    this.btStart.Enabled = false;
                }
                else
                {
                    SetMsg("server启动失败！");
                }
            }
        }
        private void SetMsg(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetMsg), msg);
            }
            else
            {
                this.txtLog.Text += msg + "\r\n";
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            TaskManager.NewTask(
                    () =>
                    {
                        string _host = this.txtSHost.Text;
                        int _port = string.IsNullOrEmpty(this.txtSPort.Text) ? -1 : Convert.ToInt32(this.txtSPort.Text);
                        UDPHelper.SendMessgae(UDPServer.Server, this.textBox1.Text, SetMsg, _host, _port);
                        //UDPHelper.BroadcastMessgae()
                    }
                );
        }

        private void UPDServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TaskManager.CancelTasks();
        }
    }
}
