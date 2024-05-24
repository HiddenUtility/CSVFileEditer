using System.IO.Compression;
using CsUtil.PathUtil;

namespace CsUtil.MyCompressor
{
    public class FileCompressor(string filePath, string destZipPath)
    {
        
        private readonly string _filePath = filePath;
        private readonly string _destZipPath = destZipPath;

        private readonly string _tempPath = new WinPath(destZipPath).WithSuffix(".tmp").ToString();

        private void RemoveOldFile()
        {
            if (File.Exists(_destZipPath))
            {
                File.Delete(_destZipPath);
            }
            if (File.Exists(_tempPath))
            {
                File.Delete(_tempPath);
            }

        }

        private void Compress()
        {
            string zipDirPath = Path.GetDirectoryName(_destZipPath) ?? throw new ZipCompressorError($"{_destZipPath}無効なパスです。");
            DirectoryCreator.MakeDirecotry(zipDirPath);
            string fileName = Path.GetFileName(_filePath);
            // 一時名でファイルを圧縮ファイルを生成する。
            using ZipArchive archive = ZipFile.Open(_tempPath, ZipArchiveMode.Create);
            // 途中
            archive.CreateEntryFromFile(_filePath, fileName);
        }
        
        public void Run()
        {
            try{
                RemoveOldFile();
            }
            catch (Exception)
            {             
                throw new ZipCompressorError("旧ファイルの削除に失敗しました。");
            }

            if (!File.Exists(_filePath))
            {
                throw new ZipCompressorError($"File '{_filePath}' not found!");
            }
            try
            {
                Compress();
            }
            catch (Exception e)
            {
                throw new ZipCompressorError($"{_filePath}の圧縮に失敗しました。{e}");
            }

            // TODO 圧縮チェック

            if (File.Exists(_tempPath))
            {
                File.Move(_tempPath, _destZipPath);
            }




        }
    }
}
