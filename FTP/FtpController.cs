using System;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;


//csc -target:library FtpController.cs

namespace FtpController
{
    public interface Api
    {

    }

    public class FtpController : Api
    {
        FtpConnectedInformation Info;
        public FtpController(string ip, string userName, string password)
        {
            this.Info = new FtpConnectedInformation(ip, userName, password);
        }
    }

    public class FtpConnectedInformation
    {
        private string ip;
        private string userName;
        private string password;

        public FtpConnectedInformation(string ip, string userName, string password)
        {
            this.ip = ip;
            this.userName = userName;
            this.password = password;
        }

        public string Ip
        {
            get{return this.ip;}
        }

        public string Username
        {
            get{return this.userName;}
        }

        public string Password
        {
            get{return this.password;}
        }

    }

    public class Ftp
    {
        FtpConnectedInformation Info;
        bool Connecting;
        public Ftp(FtpConnectedInformation ftpConnectedInformation)
        {
            this.Info = ftpConnectedInformation;
            this.Connecting = false;
        }

        public void connect()
        {
            Uri rootUri = new Uri(string.Format("ftp://{}", Info.Ip));
            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(rootUri);
            ftpWebRequest.Credentials = new NetworkCredential(Info.Username, Info.Password);
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpWebRequest.KeepAlive = true;
            ftpWebRequest.UseBinary = true;
            //ftpReq.UsePassive = false;
            ftpWebRequest.Proxy = null;

            try
            {
                using(FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
                {
                    Console.WriteLine("接続に成功しました。");
                    this.Connecting = true;
                }
            }
            catch
            {
                Console.WriteLine("接続できませんでした。");

            }
        }
        public void disconnect()
        {
            Uri rootUri = new Uri(string.Format("ftp://{}", Info.Ip));
            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(rootUri);
            ftpWebRequest.Credentials = new NetworkCredential(Info.Username, Info.Password);
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpWebRequest.KeepAlive = false;


            try
            {
                using(FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
                {
                    Console.WriteLine("接続を解除しました。");
                    this.Connecting = false;
                }
            }
            catch
            {
                

            }
        }

        public bool isConnecting()
        {
            return Connecting;
        }


    }


    public class Receiver : Ftp
    {
        FtpConnectedInformation Info;
        public Receiver(FtpConnectedInformation ftpConnectedInformation): base(ftpConnectedInformation)
        {
            this.Info = ftpConnectedInformation;
        }
    }

    public class Sender : Ftp
    {
        FtpConnectedInformation Info;
        public Sender(FtpConnectedInformation ftpConnectedInformation): base(ftpConnectedInformation)
        {
            this.Info = ftpConnectedInformation;
        }
    }
    public class FileMaker : Ftp
    {
        FtpConnectedInformation Info;
        public FileMaker(FtpConnectedInformation ftpConnectedInformation): base(ftpConnectedInformation)
        {
            this.Info = ftpConnectedInformation;
        }
    }
    public class DirectoryMaker : Ftp
    {
        FtpConnectedInformation Info;
        public DirectoryMaker(FtpConnectedInformation ftpConnectedInformation): base(ftpConnectedInformation)
        {
            this.Info = ftpConnectedInformation;
        }
    }

    public class FileRemover : Ftp
    {
        FtpConnectedInformation Info;
        public FileRemover(FtpConnectedInformation ftpConnectedInformation): base(ftpConnectedInformation)
        {
            this.Info = ftpConnectedInformation;
        }
    }

    public class DirectoryRemover : Ftp
    {
        FtpConnectedInformation Info;
        public DirectoryRemover(FtpConnectedInformation ftpConnectedInformation): base(ftpConnectedInformation)
        {
            this.Info = ftpConnectedInformation;
        }
    }



}



