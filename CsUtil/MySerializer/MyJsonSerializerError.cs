// BinaryFormatterは.NET 5.0以降では非推奨となっているため一般的なJsonSerializationし、内部で変換する。
// .NET Core 2.0 から標準搭載の System.Text.Json がデフォルトで推奨となっています。

namespace CsUtil.MySerializer


{
    [Serializable]
    public class MyJsonSerializerError : Exception
    {
        public MyJsonSerializerError() { }
        public MyJsonSerializerError(string message) : base(message) { }
        public MyJsonSerializerError(string message, Exception inner) : base(message, inner) { }

    }
}