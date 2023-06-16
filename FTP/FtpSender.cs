using System;
using System.
using System.Net;

namespace FtpController
{
    public class FtpSender
    {
        public string IP { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void FtpSender()
        {

        }

        public void setToConnect(string ip, string username, string password)
        {
            try
            {
                // FTPサーバに接続
                
                var request = (FtpWebRequest)WebRequest.Create("ftp://" + IP);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Username, Password);

                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine("接続成功");
                    return true;
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("接続エラー: " + ex.Message);
                return false;
            }
        }

    }
}



