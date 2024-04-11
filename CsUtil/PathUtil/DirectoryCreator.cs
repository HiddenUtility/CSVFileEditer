using System;
using System.IO;

namespace CsUtil.PathUtil
{
    public class DirectoryCreator
    {
        public static void MakeDirectory(string dirpath)
        {
            string pearentPath = Path.GetDirectoryName(dirpath);
            if (!Directory.Exists(pearentPath))
            {
                MakeDirectory(pearentPath);
            }
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
        }
    }
}
