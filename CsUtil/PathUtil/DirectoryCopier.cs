namespace CsUtil.PathUtil
{
    public class DirectoryCopier
    {
        public static void CopyDirectoryTree(string sourceDirPath, string targetDirPath)
        {
            DirectoryInfo dir = new(sourceDirPath);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    $"ソースが存在しません。: {sourceDirPath}"
                    );
            }

            if (!Directory.Exists(targetDirPath))
            {
                Directory.CreateDirectory(targetDirPath);
            }

            FileInfo[] fileInfos = dir.GetFiles();
            foreach (FileInfo file in fileInfos)
            {
                string temppath = Path.Combine(targetDirPath, file.Name);
                file.CopyTo(temppath, false);
            }

            DirectoryInfo[] dirInfos = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirInfos)
            {
                string temppath = Path.Combine(targetDirPath, subdir.Name);
                CopyDirectoryTree(subdir.FullName, temppath);
            }
        }
    }

}