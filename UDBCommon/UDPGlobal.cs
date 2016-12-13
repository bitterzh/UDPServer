using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDBCommon
{
    public class UDPGlobal
    {
        public static string ServerHost = "172.16.17.201";
        public static int ServerPort = 5001;
        public static int StartClientPort = 5002;
        public static List<int> ClientPorts = new List<int>();
        public static int NewClientPort()
        {
            if (ClientPorts.Count > 0)
            {
                int _port = ClientPorts[ClientPorts.Count - 1];
                ClientPorts.Add(_port + 1);
                return _port + 1;
            }

            return StartClientPort;
        }
    }
}
