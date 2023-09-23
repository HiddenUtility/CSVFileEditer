using System;

namespace FtpController
{
    public class FileMaker : Ftp
    {
        ConnectingInformation Info;
        public FileMaker(ConnectingInformation ConnectingInformation): base(ConnectingInformation)
        {
            this.Info = ConnectingInformation;
        }
    }
}
