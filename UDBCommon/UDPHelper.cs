﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDBCommon
{
    public static class UDPHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        public static void StartReceive(UdpClient receivingUdpClient, Action<string> callback = null, int port = 0, string ip = "")
        {
            IPEndPoint _remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            if (!string.IsNullOrEmpty(ip))
                _remoteIpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            try
            {
                while (true)
                {
                    byte[] rData = receivingUdpClient.Receive(ref _remoteIpEndPoint);
                    if (rData.Length > 0)
                    {
                        string _rMsg = Encoding.ASCII.GetString(rData);
                        string _msg = string.Format("接收信息：{0} -- {1}", _remoteIpEndPoint.Address + ":" + _remoteIpEndPoint.Port, _rMsg);

                        if (callback != null)
                            callback(_msg);

                        string _result = DealWithRequest(_rMsg, _remoteIpEndPoint);

                        if (callback != null)
                            callback(_result);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static string DealWithRequest(string request, IPEndPoint point)
        {
            if (request == UDPAgreement.FindDevice)
            {
                FindDevices(point.Address, point.Port, request);
                return "检查内网设备";
            }
            else if (request == UDPAgreement.InitClient)
            {
                InitClient(point.Address, point.Port, request);
                return "初始化设备";
            }
            return "未处理请求：" + request;
        }

        /// <summary>
        /// UDP广播获得网内设备
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="msg"></param>
        public static void FindDevices(IPAddress ip, int port, string msg)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="msg"></param>
        public static void InitClient(IPAddress ip, int port, string msg)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendUdpClient"></param>
        /// <param name="message"></param>
        /// <param name="callback"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public static void SendMessgae(UdpClient sendUdpClient, string message, Action<string> callback = null, string ip = "", int port = 5110)
        {
            byte[] _sData = Encoding.ASCII.GetBytes(message);
            if (callback != null)
            {
                string _msg = string.Format("发送信息：{0}", message);
                callback(_msg);
            }
            int _result = -1;

            IPEndPoint host = new IPEndPoint(IPAddress.Parse(ip), port);
            if (string.IsNullOrEmpty(ip) && port > 0)
                _result = sendUdpClient.Send(_sData, _sData.Length, host);
            else
                _result = sendUdpClient.Send(_sData, _sData.Length);

            if (callback != null)
            {
                string _msg = string.Format("发送结果：{0}", _result);
                callback(_msg);
            }
        }

        public static void BroadcastMessgae(UdpClient sendUdpClient, string message, Action<string> callback = null, int port = 0)
        {
            byte[] _sData = Encoding.ASCII.GetBytes(message);
            if (callback != null)
            {
                string _msg = string.Format("广播信息：{0}", message);
                callback(_msg);
            }
            int _result = -1;

            IPEndPoint host = new IPEndPoint(IPAddress.Parse("255.255.255.255"), port);
            _result = sendUdpClient.Send(_sData, _sData.Length, host);

            if (callback != null)
            {
                string _msg = string.Format("广播结果：{0}", _result);
                callback(_msg);
            }
        }
    }
}
