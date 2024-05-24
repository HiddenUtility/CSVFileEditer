using System;
using System.Text;

namespace CsUtil.DummyMaker
{
    public class DummyTextFileMkaer
    {
        public static void CreateRandomTextFile(string filepath)
        {
            CreateRandomTextFile(filepath, 100);
        }

        public static void CreateRandomTextFile(string filepath, int number)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var randomString = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                randomString.Append(chars[random.Next(chars.Length)]);
            }
            File.WriteAllText(filepath, randomString.ToString());
        }

    }
}
