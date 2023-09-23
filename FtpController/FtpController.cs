using System;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;




//csc -target:library FtpController.cs

namespace FtpController
{


    public class FtpController
    {
        ConnectingInformation Info;
        public FtpController(string ip, string port, string userName, string password)
        {
            this.Info = new ConnectingInformation(ip, port, userName, password);
        }
    }















}



