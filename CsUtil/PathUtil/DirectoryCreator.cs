namespace CsUtil.PathUtil
{
    /// <summary>
    /// ディレクトリを作る
    /// </summary>
    public class DirectoryCreator
    {
        /// <summary>
        ////ディレクトリを全階層作る。あれば作らない
        /// </summary>
        /// <param name="dirpath"></param>
        public static void MakeDirecotry(string dirpath)
        {
            if (!Directory.Exists(dirpath))
            {
                try
                {
                    
                    Directory.CreateDirectory(dirpath);
                }
                catch (Exception)
                {
                    
                    throw new WinPathError($"{dirpath}はディレクトリパスとして不正です。");
                }
            }
        }
    }

}