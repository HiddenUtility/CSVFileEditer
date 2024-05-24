
using System.Text;
using System.Security.Cryptography;



namespace CsUtil.HashUtil
{
    public class FileHashMaker
    {
        private readonly string _label;
        private readonly byte[] _bytes;
        private readonly string _filePath;

        public FileHashMaker(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"{filePath} does not exist");
            }
            _filePath = filePath;

            using FileStream fs = new(filePath,FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, (int)fs.Length);

            _bytes = SHA256.HashData(bytes);
            StringBuilder builder = new();
            foreach (byte b in _bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            _label = builder.ToString();
        }


        public override bool Equals(object? obj)
        {
            if (obj == null){return false;}
            try
            {
                
                FileHashMaker tryCasting = (FileHashMaker)obj; // asによるキャストの方が高速だがnull返る
            }
            catch (InvalidCastException)
            {
                
                return false;
            }
            HashLabelMaker myclass = (HashLabelMaker)obj;
            return myclass.Label == _label;
        }


        public static bool operator ==(FileHashMaker lhs, FileHashMaker rhs)
        {
            return lhs.Label == rhs.Label;
        }


        public static bool operator !=(FileHashMaker lhs, FileHashMaker rhs)
        {
            return lhs.Label != rhs.Label;
        }

        public override int GetHashCode()
        {
            return _label.GetHashCode();
        }



        public string Label => _label;

        public string FilePath => _filePath;


        public override string ToString()
        {
            return _label;
        }
    }
}