using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDBCommon
{
    public class UDPUser
    {
        #region 属性

        /// <summary>
        /// ip地址
        /// </summary>
        private string userIP;
        public string UserIP
        {
            get { return userIP; }
            set { userIP = value; }
        }

        private int userPort;
        public int UserPort
        {
            get { return userPort; }
            set { userPort = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        #endregion

        public UDPUser()
        {
        }

        public UDPUser(string ip, int port)
        {
            UserIP = ip;
            UserPort = port;
        }

        public UDPUser(string name, string ip, int port)
        {
            UserName = name;
            UserIP = ip;
            UserPort = port;
        }

        public override bool Equals(object obj)
        {
            UDPUser user = (UDPUser)obj;
            if (null == user)
                return false;
            return userIP == user.userIP && userPort == user.userPort;
        }
    }
}
