
using System.Text;
using System.Security.Cryptography;



namespace CsUtil.HashUtil
{
    public class HashLabelMaker
    {
        private readonly string _label;
        private readonly byte[] _bytes;
        private readonly string _origin;

        public HashLabelMaker(string str)
        {
            _origin = str;

            _bytes = SHA256.HashData(Encoding.UTF8.GetBytes(str));
            StringBuilder builder = new();
            foreach (byte b in _bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            _label = builder.ToString();
        }

        public string Label => _label;

        public string Origin => _origin;

        public override bool Equals(object? obj)
        {
            if (obj == null){return false;}
            try
            {
                
                HashLabelMaker tryCasting = (HashLabelMaker)obj; // asによるキャストの方が高速だがnull返る
            }
            catch (InvalidCastException)
            {
                
                return false;
            }
            HashLabelMaker myclass = (HashLabelMaker)obj;
            return myclass.Label == _label;
        }


        public static bool operator ==(HashLabelMaker lhs, HashLabelMaker rhs)
        {
            return lhs.Label == rhs.Label;
        }


        public static bool operator !=(HashLabelMaker lhs, HashLabelMaker rhs)
        {
            return lhs.Label != rhs.Label;
        }




        public override int GetHashCode()
        {
            return _label.GetHashCode();
        }

        public override string ToString()
        {
            return _label;
        }




    }
}