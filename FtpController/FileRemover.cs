using System;

namespace FtpController
{
    public class FileRemover : Ftp
    {
        ConnectingInformation Info;
        public FileRemover(ConnectingInformation ConnectingInformation): base(ConnectingInformation)
        {
            this.Info = ConnectingInformation;
        }
    }
}
