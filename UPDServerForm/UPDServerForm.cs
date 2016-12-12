using System;
using System.Net;
using System.Windows.Forms;
using UDBCommon;

namespace UPDServerForm
{
    public partial class UPDServerForm : Form
    {
        public UPDServerForm()
        {
            InitializeComponent();
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            this.txtHost.Text = ips[ips.Length - 1].ToString();
            this.txtSHost.Text = "172.16.17.255";
            int port = 5110;
            this.txtPort.Text = port.ToString();
            this.txtSPort.Text = "0";
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtPort.Text))
            {
                string _host = this.txtHost.Text;
                int _port = Convert.ToInt32(this.txtPort.Text);
                if (UDPServer.Init(_host, _port, SetMsg))
                {
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
                    }
                );
        }

        private void UPDServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TaskManager.CancelTasks();
        }
    }
}
