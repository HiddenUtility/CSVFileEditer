namespace CsUtil.PathUtil
{
    /// <summary>
    /// ディレクトリ削除する
    /// </summary> 
    public class DirectoryRemover
    {
        /// <summary>
        /// 単純な削除
        /// 途中でコケても復元しないので注意
        /// </summary>
        /// <param name="targetDirpath"></param>
        public static void RemoveTree(string targetDirpath)
        {
            if (!Directory.Exists(targetDirpath)){return;}
            string[] dirs = Directory.GetDirectories(targetDirpath);
            string[] files = Directory.GetFiles(targetDirpath);
            foreach (string file in files)
            {
                File.Delete(file);
            }
            foreach (string dir in dirs)
            {
                RemoveTree(dir);
            }
            Directory.Delete(targetDirpath, true);

        }
        public static void RemoveTree(string targetDirpath, bool backup)
        {
            if (backup)
            {
                RemoveTreeAfterBackUp(targetDirpath);
            }
            else
            {
                RemoveTree(targetDirpath);
            }

        }

        private static void RemoveTreeAfterBackUp(string targetDirpath)
        {

            string backupName = $"__{targetDirpath}";
            string backupPath = new WinPath(targetDirpath).WithName(backupName).ToString();
            try
            {
                DirectoryCopier.CopyDirectoryTree(targetDirpath, backupPath);
            }
            catch (Exception)
            {
                
                throw new WinPathError($"{targetDirpath}のバックアップに失敗しました。");
            }

            try
            {
                RemoveTree(targetDirpath);
            }
            catch (Exception)
            {
                
                throw new WinPathError($"{targetDirpath}の削除に失敗しました。");
            }

            try
            {
                RemoveTree(backupPath);
            }
            catch (Exception)
            {
                
                throw new WinPathError($"{targetDirpath}のバックアップの削除に失敗しました。");
            }



        }




    }

}