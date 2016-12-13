using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using UDBCommon;

namespace UPDClientForm
{
    public partial class UPDClientForm : Form
    {
        private int myport = 0;
        public UPDClientForm()
        {
            InitializeComponent();

            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

            this.txtHost.Text = UDPGlobal.ServerHost;
            this.txtPort.Text = UDPGlobal.ServerPort.ToString();

            this.txtSHost.Text = ips[ips.Length - 1].ToString();
            myport = UDPGlobal.NewClientPort();
            this.txtSPort.Text = myport.ToString();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtPort.Text))
            {
                string _host = this.txtHost.Text;
                int _port = Convert.ToInt32(this.txtPort.Text);
                if (UDPClient.Init(myport, _host, _port))
                {
                    SetMsg("连接成功！");

                    TaskManager.NewTask(
                            () =>
                            {
                                IPEndPoint _point = ((System.Net.IPEndPoint)UDPClient.Client.Client.LocalEndPoint);
                                UDPHelper.SendMessgae(UDPClient.Client, "1002", SetMsg, _host, _port);
                                UDPHelper.StartReceive(UDPClient.Client, SetMsg);
                            }
                        );
                    this.btConnect.Enabled = false;
                }
                else
                {
                    SetMsg("连接失败！");
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
                        UDPHelper.SendMessgae(UDPClient.Client, this.textBox1.Text, SetMsg, _host, _port);
                    }
                );
        }

        private void UPDClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TaskManager.CancelTasks();
        }
    }
}
