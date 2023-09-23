using System;

namespace FtpController
{
    public class DirectoryMaker : Ftp
    {
        ConnectingInformation Info;
        public DirectoryMaker(ConnectingInformation ConnectingInformation): base(ConnectingInformation)
        {
            this.Info = ConnectingInformation;
        }
    }
}
