

using System;
using FtpController;


//csc Program.cs

namespace Test
{
    public class Test
    {
        public static void Main(string[] args)
        {
            string ip = "192.168.10.10";
            string userName = "username";
            string password = "password";

            FtpController.FtpConnectedInformation info = new FtpController.FtpConnectedInformation(ip, userName, password);
            FtpController.FtpController controller = new FtpController.FtpController(ip, userName, password);

            
        }
    }
}