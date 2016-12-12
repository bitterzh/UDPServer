namespace UPDClientForm
{
    partial class UPDClientForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbHost = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.txtSPort = new System.Windows.Forms.TextBox();
            this.txtSHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.plLeft = new System.Windows.Forms.Panel();
            this.plMain = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.plLeft.SuspendLayout();
            this.plMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(53, 48);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(144, 21);
            this.txtPort.TabIndex = 0;
            this.txtPort.Text = "5110";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(53, 21);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(144, 21);
            this.txtHost.TabIndex = 0;
            this.txtHost.Text = "172.16.17.201";
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(4, 75);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(193, 23);
            this.btConnect.TabIndex = 1;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(4, 353);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(193, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send Message";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 252);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 95);
            this.textBox1.TabIndex = 2;
            // 
            // lbHost
            // 
            this.lbHost.AutoSize = true;
            this.lbHost.Location = new System.Drawing.Point(12, 24);
            this.lbHost.Name = "lbHost";
            this.lbHost.Size = new System.Drawing.Size(35, 12);
            this.lbHost.TabIndex = 3;
            this.lbHost.Text = "Host:";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(12, 51);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(35, 12);
            this.lbPort.TabIndex = 3;
            this.lbPort.Text = "Port:";
            // 
            // txtSPort
            // 
            this.txtSPort.Location = new System.Drawing.Point(53, 229);
            this.txtSPort.Name = "txtSPort";
            this.txtSPort.Size = new System.Drawing.Size(144, 21);
            this.txtSPort.TabIndex = 5;
            this.txtSPort.Text = "5110";
            // 
            // txtSHost
            // 
            this.txtSHost.Location = new System.Drawing.Point(53, 202);
            this.txtSHost.Name = "txtSHost";
            this.txtSHost.Size = new System.Drawing.Size(144, 21);
            this.txtSHost.TabIndex = 4;
            this.txtSHost.Text = "172.16.17.201";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "SHost:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "SPort:";
            // 
            // plLeft
            // 
            this.plLeft.Controls.Add(this.label2);
            this.plLeft.Controls.Add(this.label1);
            this.plLeft.Controls.Add(this.txtSHost);
            this.plLeft.Controls.Add(this.txtSPort);
            this.plLeft.Controls.Add(this.lbPort);
            this.plLeft.Controls.Add(this.lbHost);
            this.plLeft.Controls.Add(this.textBox1);
            this.plLeft.Controls.Add(this.btnSend);
            this.plLeft.Controls.Add(this.btConnect);
            this.plLeft.Controls.Add(this.txtHost);
            this.plLeft.Controls.Add(this.txtPort);
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLeft.Location = new System.Drawing.Point(0, 0);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(200, 379);
            this.plLeft.TabIndex = 2;
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.txtLog);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(200, 0);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(474, 379);
            this.plMain.TabIndex = 4;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(474, 379);
            this.txtLog.TabIndex = 1;
            // 
            // UPDClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 379);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.plLeft);
            this.Name = "UPDClientForm";
            this.Text = "UPDClientForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UPDClientForm_FormClosed);
            this.plLeft.ResumeLayout(false);
            this.plLeft.PerformLayout();
            this.plMain.ResumeLayout(false);
            this.plMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbHost;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.TextBox txtSPort;
        private System.Windows.Forms.TextBox txtSHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel plLeft;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.TextBox txtLog;
    }
}

