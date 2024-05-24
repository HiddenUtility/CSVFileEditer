
using System.Text;
using CsUtil.PathUtil;




namespace CsUtil.MyLogger
{
    public partial class SinpleLogger  : ILogger, IDisposable
    {
        private static readonly string LOG_FILE_NAME_FORMAT = "{0}_{1}.log";
        private static readonly string LOG_DATE_FORMAT = "yyyy-MM-dd-ddd";
        private static readonly string LOG_FORMAT = "{0} {1} {2}";
        private static readonly string DATETIME_FORMAT = "yyyy/MM/dd HH:mm:ss.fff";
        private readonly StreamWriter _stream;
        private readonly bool _consoleOut; 
        private readonly string _loggerName;
        private readonly string _logfilePath;
        private readonly object _locking = new object();

        public string LogfilePath => _logfilePath;

        /// <summary>
        /// シンプルなロガー
        /// </summary>
        /// <param name="logFilePath"></param>
        /// <param name="consoleOut"></param>
        /// <exception cref="Exception"></exception> <summary>
        /// 
        /// </summary>
        /// <param name="logFilePath">出力したいファイルパス</param>
        /// <param name="consoleOut">コンソールに出力するか</param>
        public SinpleLogger(string dirpath, string name, bool consoleOut)
        {
            MakeDirecotry(dirpath);
            _consoleOut = consoleOut;
            _loggerName = string.Format(LOG_FILE_NAME_FORMAT, name , DateTime.Now.ToString(LOG_DATE_FORMAT));
            _logfilePath = new WinPath(dirpath).JoinPath(_loggerName).ToString();
            _stream = new StreamWriter(_logfilePath, true, Encoding.Default)
            {
                AutoFlush = true
            };
        }
        
        public void Dispose()
        {
            _stream.Close();
        }

        public void Close()
        {
            Dispose();
        }


        public SinpleLogger(string dirpath, bool consoleOut) : this(dirpath, "SimpleLogger", consoleOut){}

        private static void MakeDirecotry(string dirpath)
        {

            if (!Directory.Exists(dirpath))
            {
                try
                {
                    
                    Directory.CreateDirectory(dirpath);
                }
                catch (Exception)
                {
                    
                    throw new MyLoggerError($"{dirpath}はディレクトリパスとして不正です。");
                }
            }
        }

        /// <summary>
        /// ログ書き込み
        /// </summary>
        
        private void  Write(LogLevel level, string text)
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