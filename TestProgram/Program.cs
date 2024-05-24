using CsUtil.PathUtil;
using CsUtil.MyLogger;
using CsUtil.MyCompressor;
using CsUtil.DummyMaker;
using CsUtil.MySerializer;
using System.Diagnostics;
using CsUtil.HashUtil;

namespace TestProgram
{
    public class Program
    {
        private static readonly string TEST_DEST_PATH = @"./TestDest";
        public static void Main(string[] args)
        {
            DirectoryRemover.RemoveTree(TEST_DEST_PATH);
            Directory.CreateDirectory(TEST_DEST_PATH);
            TestSingletonLogger();
            TestSimpleLogger();
            TestCompresser();
            TestJsonSerializer();
            TestTaskLogger();
            TestHashUtil();



            
        }

        private static void TestSingletonLogger()
        {
            WinPath path = new(TEST_DEST_PATH);
            Console.WriteLine(path.ToString());
            path = path.JoinPath("logger.log");
            Console.WriteLine(path.ToString());
            using SingletonLogger logger = new(path.ToString(), true);
            logger.Info("Test");
            logger.Error("Test");
            logger.Error(new Exception("Exceptionもぶち込めるよ"));
            logger.Warn("Test");
            logger.Debug("Test");
        }

        private static void TestSimpleLogger()
        {
            using SinpleLogger logger = new(TEST_DEST_PATH, "SinpleLoggerTest",true);
            logger.Info("Test");
            logger.Error("Test");
            logger.Error(new Exception("Exceptionもぶち込めるよ"));
            logger.Warn("Test");
            logger.Debug("Test");
        }

        private static void TestCompresser()
        {
            WinPath path = new(TEST_DEST_PATH);
            WinPath newpath = path.JoinPath("dummy.txt");
            DummyTextFileMkaer.CreateRandomTextFile(newpath.ToString());
            ZipCompressor.ToZip(newpath);
            File.Delete(newpath.ToString());

            WinPath[] paths = path.Glob("*.log");
            foreach (WinPath p in paths)
            {
                ZipCompressor.ToZip(p);
                File.Delete(p.ToString());
            }


        }

        private static void TestJsonSerializer()
        {
            Dictionary<string, string> properties = new()
            {
                ["りんご"] = "Apple",
                ["ぶどう"] = "Grape"
            };
            MyJsonSerializer json = new(properties);
            Console.WriteLine(json.Json);
            Console.WriteLine(json.Dictionary.ToString());
            Console.WriteLine(json);

            string path = Path.Combine(TEST_DEST_PATH,"Fruts.json");
            json.Out(path);

            string[] values = ["リンゴ","ブドウ"];

            Dictionary<string, string[]> props = new()
            {
                ["Fruts"] = values,
            };

            json = new(props);
            Console.WriteLine(json.Json);
            Console.WriteLine(json.Dictionary.ToString());
            Console.WriteLine(json);
            path = Path.Combine(TEST_DEST_PATH,"Fruts2.json");
            json.Out(path);

            
        }

        private static void TestTaskLogger()
        {
            TaskLogger logger = new(TEST_DEST_PATH,"test_tasklogger",true);
            logger.Write("hoge");
            logger.Write("hogehoge");

            TaskLogger logger2 = new(TEST_DEST_PATH,"test_tasklogger",true);
            Debug.Assert(logger2.Exists("hoge"));
            Debug.Assert(logger2.Exists("hogehoge"));
        }

        private static void TestHashUtil()
        {
            HashLabelMaker label = new("hoge");
            Console.WriteLine("{0} : {1}",label.Origin, label);

            string[] paths = Directory.GetFiles(TEST_DEST_PATH);
            FileHashMaker[] makers = paths.Select(p => new FileHashMaker(p)).ToArray();

            foreach (FileHashMaker item in makers)
            {
                Console.WriteLine("{0} : {1}",item.FilePath, item);
            }


        }
    }
}