using System.IO;
using System.Text;


namespace Maker
{

    public class DummiyFileMaker
    {
        public static void MakeDummiy(string filePath, string text)
        {
            // FileStreamを作成
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                // 文字列をバイト配列に変換
                byte[] data = Encoding.UTF8.GetBytes(text);

                // ファイルに書き込み
                fs.Write(data, 0, data.Length);
            }
        }
    }

}