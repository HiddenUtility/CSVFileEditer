using System;

namespace FtpController
{
    public class DirectoryRemover : Ftp
    {
        ConnectingInformation Info;
        public DirectoryRemover(ConnectingInformation ConnectingInformation): base(ConnectingInformation)
        {
            this.Info = ConnectingInformation;
        }
    }
}
