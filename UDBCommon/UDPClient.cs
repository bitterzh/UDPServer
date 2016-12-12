using System;
using System.Net;
using System.Net.Sockets;

namespace UDBCommon
{
    public class UDPClient
    {
        private static UdpClient udpClient;
        public static string IP;
        public static string Port;

        public static UdpClient Client
        {
            get
            {
                return udpClient;
            }
        }
        public static bool Init(string host = "172.16.17.201", int port = 5110)
        {
            udpClient = new UdpClient();
            try
            {
                //udpClient.JoinMulticastGroup(IPAddress.Parse(host));
                udpClient.Connect(host, port);                

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
