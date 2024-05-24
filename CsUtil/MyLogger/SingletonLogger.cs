using System.Text;




namespace CsUtil.MyLogger
{
    /// <summary>
    /// シングルトーンタイプのロガー
    /// 
    /// </summary>
    public class SingletonLogger  : ILogger,  IDisposable
    {

        private static readonly string LOG_FORMAT = "{0} {1} {2}";
        private static readonly string DATETIME_FORMAT = "yyyy/MM/dd HH:mm:ss.fff";
        private readonly StreamWriter _stream;
        private readonly bool _consoleOut;
        private static SingletonLogger? _singleon;   
        private readonly object _locking = new object();     
        private readonly string _logFilePath;

        public string LogFilePath => _logFilePath;

        /// <summary>
        /// インスタンス
        /// </summary>
        public static SingletonLogger GetInstance(string logFilePath , bool consoleOut = false)
        {
            if (_singleon == null)
            {
                _singleon = new SingletonLogger(logFilePath, consoleOut);
            }
            
            return _singleon;
        }

        public SingletonLogger(string logFilePath, bool consoleOut)
        {
            if (string.IsNullOrWhiteSpace(logFilePath))
            {
                throw new Exception("logFilePath is empty.");
            }

            var logFile = new FileInfo(logFilePath);
            if (!Directory.Exists(logFile.DirectoryName))
            {
                if (logFile.DirectoryName != null)
                { 
                    Directory.CreateDirectory(logFile.DirectoryName);
                }
            }

            _stream = new StreamWriter(logFile.FullName, true, Encoding.Default)
            {
                AutoFlush = true
            };
            _consoleOut = consoleOut;
            _logFilePath = logFilePath;
        }

        public void Dispose()
        {
            _stream.Close();
        }

        public void Close()
        {
            Dispose();
        }


        /// <summary>
        /// ログ書き込み
        /// </summary>
        
        private void Write(LogLevel level, string text)
        {
            string log = string.Format(LOG_FORMAT, DateTime.Now.ToString(DATETIME_FORMAT), level.ToString(), text);

            lock (_locking){
                _stream.WriteLine(log);
            }

            if (_consoleOut)
            {
                Console.WriteLine(log);
            }
        }


        public void Error(string text)
        {
            Write(LogLevel.ERROR, text);
        }

        public void Error(Exception ex)
        {
            Write(LogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
        }

        public void Error(string format, object arg)
        {
            Error(string.Format(format, arg));
        }

        public void Error(string format, params object[] args)
        {
            Error(string.Format(format, args));
        }

        public void Warn(string text)
        {
            Write(LogLevel.WARNING, text);
        }

        public void Warn(string format, object arg)
        {
            Warn(string.Format(format, arg));
        }

        public void Warn(string format, params object[] args)
        {
            Warn(string.Format(format, args));
        }

        public void Info(string text)
        {
            Write(LogLevel.INFO, text);
        }

        public void Info(string format, object arg)
        {
            Info(string.Format(format, arg));
        }

        public void Info(string format, params object[] args)
        {
            Info(string.Format(format, args));
        }

        public void Debug(string text)
        {
            Write(LogLevel.DEBUG, text);
        }

        public void Debug(string format, object arg)
        {
            Debug(string.Format(format, arg));
        }

        public void Debug(string format, params object[] args)
        {
            Debug(string.Format(format, args));
        }

    }
}