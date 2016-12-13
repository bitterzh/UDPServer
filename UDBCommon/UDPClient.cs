using System;
using System.Net;
using System.Net.Sockets;

namespace UDBCommon
{
    public class UDPClient
    {
        private static UdpClient udpClient;
        private static IPEndPoint server;
        public static string IP;
        public static string Port;

        public static UdpClient Client
        {
            get
            {
                return udpClient;
            }
        }
        public static IPEndPoint Server
        {
            get
            {
                return server;
            }
        }
        public static bool Init(int cport, string shost = "172.16.17.201", int sport = 5001)
        {
            try
            {
                //udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, port));
                server = new IPEndPoint(IPAddress.Parse(shost), sport);
                try
                {
                    udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, cport));
                }
                catch
                {
                    udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, cport + 1));
                }
                //udpClient = new UdpClient();
                //udpClient.Connect(host, port);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void Dispose()
        {
            if (udpClient != null)
            {
                udpClient.Close();
                udpClient = null;
                Console.WriteLine("下线：{0}", DateTime.Now.ToString());
            }
        }
    }
}
