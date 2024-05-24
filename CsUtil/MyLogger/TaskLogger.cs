
using System.Text;
using CsUtil.PathUtil;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;


// BinaryFormatterは.NET 5.0以降では非推奨となっているため一般的なJsonSerializationし、内部で変換する。
// .NET Core 2.0 から標準搭載の System.Text.Json がデフォルトで推奨となっています。


namespace CsUtil.MyLogger
{
    /// <summary>
    /// 処理結果を保存する
    /// </summary> <summary>
    /// 非推奨のBinaryFormatterは使わない
    /// </summary>

    public partial class TaskLogger  
    {

        private static readonly string LOG_FILE_NAME_FORMAT = "{0}.json";

        private readonly bool _consoleOut; 
        private readonly string _loggerName;
        private readonly string _logfilePath;
        private  HashSet<string> _logs;
        private readonly JsonSerializerOptions _option = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true,
        };

        public string LogfilePath => _logfilePath;

        public bool ConsoleOut => _consoleOut;

        public string LoggerName => _loggerName;

        public TaskLogger(string dirpath, string name, bool consoleOut)
        {
            MakeDirecotry(dirpath);
            _consoleOut = consoleOut;
            _loggerName = string.Format(LOG_FILE_NAME_FORMAT, name);
            _logfilePath = new WinPath(dirpath).JoinPath(_loggerName).ToString();
            _logs = [];
            try
            {
                if (File.Exists(_logfilePath))
                {
                    Load();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                File.Delete(_logfilePath);
            }

        }
        
        public TaskLogger(string dirpath, bool consoleOut) : this(dirpath, "TaskLogger", consoleOut){}
        public TaskLogger(string dirpath) : this(dirpath, "TaskLogger", true){}
        public TaskLogger(string dirpath, string name) : this(dirpath, name, true){}

        public override string ToString()
        {

            return string.Join(", ", [.. _logs]);
        }


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
        /// ログを記録する。
        /// </summary>
        /// <param name="text">ログ内容</param>
        /// <param name="output">ファイル出力するかどうか</param>
        public void Write(string text, bool output)
        {
            _logs.Add(text);
            if (output)
            {
                Out();
            }
            if (_consoleOut)
            {
                Console.WriteLine($"{text}を登録しました。");
            }
        }
        public void Write(string text)
        {
            Write(text, true);
        }
        /// <summary>
        /// Jsonでシリアライズ
        /// </summary>
        public void Out()
        {
            TaskLoggerProperties props = new(LoggerName, _logs);
            string json = JsonSerializer.Serialize(props, _option);
            File.WriteAllText(_logfilePath, json);
        }
        /// <summary>
        /// デシリアライズ
        /// </summary>
        private void Load()
        {
            using StreamReader sr = new(_logfilePath, Encoding.UTF8);
            string json = sr.ReadToEnd();
            TaskLoggerProperties logs = JsonSerializer.Deserialize<TaskLoggerProperties>(json) ?? throw new MyLoggerError("不正なTaskファイルです");
            _logs = logs.Logs;
            if (_consoleOut)
            {
                Console.WriteLine($"{_logfilePath}を読み取りました。");
            }
        }

        /// <summary>
        /// ログに含まれているか
        /// </summary>
        /// <param name="txet"></param>
        /// <returns></returns> <summary>

        public bool Exists(string txet)
        {
            return _logs.Contains(txet);
        }





    }

}