namespace CsUtil.PathUtil
{
    [Serializable]
    public class WinPathError : Exception
    {
        public WinPathError() { }
        public WinPathError(string message) : base(message) { }
        public WinPathError(string message, Exception inner) : base(message, inner) { }

    }
}