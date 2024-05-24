namespace CsUtil.MyCompressor
{
    [System.Serializable]
    public class ZipCompressorError : Exception
    {
        public ZipCompressorError() { }
        public ZipCompressorError(string message) : base(message) { }
        public ZipCompressorError(string message, Exception inner) : base(message, inner) { }

    }
}
