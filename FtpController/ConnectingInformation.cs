using System;

namespace FtpController
{
    public class ConnectingInformation
    {
        private string ip;
        private string port;
        private string userName;
        private string password;

        public ConnectingInformation(string ip, string port,string userName, string password)
        {
            this.ip = ip;
            this.port = port;
            this.userName = userName;
            this.password = password;
        }

        public string Ip
        {
            get{return this.ip;}
        }
        public string Port
        {
            get{return this.port;}
        }


        public string Username
        {
            get{return this.userName;}
        }

        public string Password
        {
            get{return this.password;}
        }

    }
}
