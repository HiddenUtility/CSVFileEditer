using System.IO.Compression;
using CsUtil.PathUtil;

namespace CsUtil.MyCompressor
{
    public class DirecotryCompressor(string dirPath, string destZipPath)
    {

        private readonly string _dirPath = dirPath;
        private readonly string _destZipPath = destZipPath;
        private readonly string _tempZipPath = new WinPath(destZipPath).WithSuffix(".tmp").ToString();

        private void RemoveOldFile()
        {

            if (File.Exists(_destZipPath))
            {
                File.Delete(_destZipPath);
            }
            if (File.Exists(_tempZipPath))
            {
                File.Delete(_tempZipPath);
            }

        }

        private void Compress()
        {
            ZipFile.CreateFromDirectory(_dirPath, _tempZipPath);
            if (File.Exists(_tempZipPath))
            {
                File.Move(_tempZipPath,_destZipPath);
            }
        }

        public void Run()
        {
            try
            {
                RemoveOldFile();
            }
            catch (Exception)
            {
                
                throw new ZipCompressorError($"{_destZipPath}の削除に失敗しました。");
            }

            if (!Directory.Exists(_dirPath))
            {
                throw new ZipCompressorError($"Folder '{_dirPath}' not found!");
            }

            try
            {
                Compress();
            }
            catch (Exception)
            {
                throw new ZipCompressorError($"{_dirPath}の圧縮に失敗しました。");
            }



        }
    }
}
