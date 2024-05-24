using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsUtil.PathUtil
{
    public class WinPath(string path)
    {

        private readonly string _path = path;

        /// <summary>
        /// 親のディレクトリを得る
        /// </summary>
        /// <returns></returns>
        public WinPath Parent => ToParent();
        /// <summary>
        /// パスが存在するか
        /// </summary>
        /// <returns></returns>
        public bool Exists()
        {
            if (IsFile())
            {
                return true;
            }
            if (IsDirectory())
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// ファイルかどうか
        /// </summary>
        public bool IsFile()
        {
            return File.Exists(_path);
        }
        /// <summary>
        /// ディレクトリかどうか
        /// </summary>
        /// <returns></returns>
        public bool IsDirectory()
        {
            return Directory.Exists(_path);
        }

        public WinPath JoinPath(string name)
        {
            return new WinPath(System.IO.Path.Combine(_path, name));
        }
        /// <summary>
        /// パスを返す
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return _path;
        }
        /// <summary>
        /// ディレクトリを作る
        /// </summary>

        public void MakeDirectory()
        {
            if (IsFile())
            {
                throw new WinPathError($"{_path}はファイルパスです。");
            }
            if (!Directory.Exists(_path))
            {
                DirectoryCreator.MakeDirecotry(_path);
            }
        }
        /// <summary>
        /// 親のWinPathを返す
        /// </summary>
        /// <returns></returns>

        private WinPath ToParent()
        {
            if (IsFile())
            {
                FileInfo fileInfo = new FileInfo(_path) ?? throw new Exception("");
                if (fileInfo.DirectoryName == null)
                {
                    throw new WinPathError($"{_path}は親が存在しません。");
                }
                return new WinPath(fileInfo.DirectoryName);
            }


            DirectoryInfo directoryInfo = new DirectoryInfo(_path) ?? throw new Exception("");
            if (directoryInfo.Parent == null)
            {
                throw new WinPathError($"{_path}は親が存在しません。");
            }
            return new WinPath(directoryInfo.Parent.FullName);
        }
        /// <summary>
        /// 該当するファイルパスを得る
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public WinPath[] Glob(string pattern)
        {
            IEnumerable<string> paths = Directory.EnumerateFiles(_path, pattern,SearchOption.TopDirectoryOnly);
            return paths.Select(p => new WinPath(p)).ToArray();
        }
        /// <summary>
        /// サブフォルダも含めた該当するファイルパスを得る
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="allSearch">true</param>
        /// <returns>サブフォルダも含める</returns> <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="allSearch">false</param>
        /// <returns>サブフォルダは含めない</returns>
        public WinPath[] Glob(string pattern, bool allSearch)
        {
            if (!allSearch)
            {
                return Glob(pattern);
            }
            IEnumerable<string> paths = Directory.EnumerateFiles(_path, pattern, SearchOption.AllDirectories);
            return paths.Select(p => new WinPath(p)).ToArray();
        }
        /// <summary>
        /// 拡張子を変更する。
        /// /// </summary>
        /// <param name="newSuffix"></param>
        /// <returns></returns>
        public WinPath WithSuffix(string newSuffix)
        {
            string pattern = @"^\.[a-zA-Z0-9]+$";
            if (!Regex.IsMatch(newSuffix, pattern))
            {
                throw new WinPathError($"{newSuffix}は拡張子として不正です。");
            }
            return new WinPath(Path.ChangeExtension(_path, newSuffix));
        }

        /// <summary>
        /// 名前のみ変更する。
        /// </summary>
        /// <param name="newName"></param>
        /// <returns>名前を変更したWinPathを返す</returns>
        public WinPath WithName(string newName)
        {
            string parentPath = ToParent().ToString();
            return new WinPath(Path.Combine(parentPath, newName));
        }

        /// <summary>
        /// 名前を変更する。
        /// </summary>
        /// <param name="newName">変更したい名前</param> <summary>
    
        public void Rename(string newName)
        {
            WinPath newPath = WithName(newName);
            if (newPath.IsFile())
            {
                File.Move(_path, newPath.ToString());
            }
            if (newPath.IsDirectory())
            {
                Directory.Move(_path, newPath.ToString());
            }

        }



        
    }
}