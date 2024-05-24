
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text;

// BinaryFormatterは.NET 5.0以降では非推奨となっているため一般的なJsonSerializationし、内部で変換する。
// .NET Core 2.0 から標準搭載の System.Text.Json がデフォルトで推奨となっています。

namespace CsUtil.MySerializer


{
    /// <summary>
    /// 単純なjson構造
    /// 複雑なものは自分でクラス定義したほうが良い。
    /// </summary>
    public class MyJsonSerializer : ISerializer
    {

        private readonly string _json;
        private readonly Dictionary<string, string> _dictionary;

        /// <summary>
        /// 日本語対応
        /// </summary> <summary>
        private readonly JsonSerializerOptions _option = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true,
        };

        public MyJsonSerializer()
        {
            _json = string.Empty;
            _dictionary = [];
        }

        public MyJsonSerializer(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new MyJsonSerializerError("nullは出来ません。");
            }

            _json = json;
            _dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json, _option) ?? throw new MyJsonSerializerError("不正なjsonです。");
        }

        public MyJsonSerializer(Dictionary<string,string> dict)
        {

            _dictionary = dict;
            _json = JsonSerializer.Serialize(dict, _option);
        }

        public MyJsonSerializer(Dictionary<string,string[]> dict)
        {
            Dictionary<string, string> data = [];

            foreach (string key in dict.Keys)
            {
                string[] values = dict[key];
                data[key] = string.Join(",", values); 
            }
            _dictionary = data;
            _json = JsonSerializer.Serialize(dict, _option);
        }

        public MyJsonSerializer(Dictionary<string,int[]> dict)
        {
            Dictionary<string, string> data = [];

            foreach (string key in dict.Keys)
            {
                int[] values = dict[key];
                data[key] = string.Join(",", values); 
            }
            _dictionary = data;
            _json = JsonSerializer.Serialize(dict, _option);
        }


        public void Out(string filepath)
        {
            using FileStream fs = new(filepath, FileMode.Create, FileAccess.Write);
            byte[] data = Encoding.UTF8.GetBytes(_json);
            fs.Write(data, 0, data.Length);
        }



        public string Json => _json;

        public Dictionary<string, string> Dictionary => _dictionary;

        public override string ToString()
        {
            return Json;
        }
    }
}