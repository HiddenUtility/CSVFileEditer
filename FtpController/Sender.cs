using System;

namespace FtpController
{
    public class Sender : Ftp
    {
        ConnectingInformation Info;
        public Sender(ConnectingInformation ConnectingInformation): base(ConnectingInformation)
        {
            this.Info = ConnectingInformation;
        }
    }
}
