

using System;
using FtpController.FtpConnectionInfo;


//csc Program.cs

namespace Test
{
    public class Test
    {
        public static void Main(string[] args)
        {

            FtpConnectionInfo info = new FtpConnectionInfo("192.168.10.10", "test", "password");
            
        }
    }
}