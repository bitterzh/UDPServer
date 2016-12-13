using System;
using System.Net;
using System.Net.Sockets;

namespace UDBCommon
{
    public class UDPServer
    {

        private static UdpClient receivingUdpClient;
        public static bool Init(string host = "172.16.17.201", int port = 5001, Action<string> callback = null)
        {
            try
            {
                receivingUdpClient = new UdpClient(new IPEndPoint(IPAddress.Any, port));
                callback(string.Format("启动服务：{0}:{1}  -- {2}", host, port, DateTime.Now.ToString()));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static UdpClient Server
        {
            get
            {
                return receivingUdpClient;
            }
        }

        public static void Dispose()
        {
            if (receivingUdpClient != null)
            {
                receivingUdpClient.Close();
                receivingUdpClient = null;
                Console.WriteLine("关闭服务：{0}", DateTime.Now.ToString());
            }
        }
    }
}
