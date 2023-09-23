

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
            string port = "21";
            string userName = "username";
            string password = "password";

            FtpController.ConnectingInformation info = new FtpController.ConnectingInformation(ip, port,userName, password);
            

            
        }
    }
}