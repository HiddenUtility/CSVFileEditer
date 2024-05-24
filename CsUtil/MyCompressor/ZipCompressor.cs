using System;
using System.IO;
using System.Security.Cryptography;

using CsUtil.PathUtil;

namespace CsUtil.MyCompressor
{
    /// <summary>
    ///　zipに圧縮する。
    /// </summary>
    public class ZipCompressor
    {
        /// <summary>
        ///　指定したパス名で圧縮する。
        /// </summary>
        /// <param name="srcPath">圧縮対象のパス</param>
        /// <param name="destZipPath">圧縮後のパス</param>
        public static void ToZip(string srcPath, string destZipPath){
            WinPath src = new(srcPath);
            if (src.IsFile())
            {
                new FileCompressor(srcPath, destZipPath).Run();
                return;
            }
            if (src.IsDirectory())
            {
                new DirecotryCompressor(srcPath, destZipPath).Run();
                return ;
            }

            throw new ZipCompressorError("無効なsrcPashです");
        }
        /// <summary>
        /// 同一ディレクトリに出力する。
        /// </summary>
        public static void ToZip(string srcPath)
        {
            string destZipPath = Path.ChangeExtension(srcPath, ".zip");
            ToZip(srcPath, destZipPath);
        }
        /// <summary>
        /// 同一ディレクトリに出力する。
        /// </summary>
        public static void ToZip(WinPath srcPath)
        {
            string src = srcPath.ToString();
            string destZipPath = Path.ChangeExtension(src, ".zip");
            ToZip(src, destZipPath);
        }



        
    }
}
