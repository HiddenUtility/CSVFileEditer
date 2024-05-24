namespace CsUtil.MyLogger
{
    [Serializable]
    public class MyLoggerError : Exception
    {
        public MyLoggerError() { }
        public MyLoggerError(string message) : base(message) { }
        public MyLoggerError(string message, Exception inner) : base(message, inner) { }

    }
}