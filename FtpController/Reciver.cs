using System;

namespace FtpController
{
    public class Receiver : Ftp
    {
        ConnectingInformation Info;
        public Receiver(ConnectingInformation ConnectingInformation): base(ConnectingInformation)
        {
            this.Info = ConnectingInformation;
        }
    }
}
