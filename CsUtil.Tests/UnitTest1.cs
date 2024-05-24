namespace CsUtil.Tests;

using CsUtil.PathUtil;
using CsUtil.MyLogger;
using System.Diagnostics;

[TestClass]
public class UnitTest1
{

    [TestMethod]
    public void TestWinPath()
    {
        WinPath path = new(Directory.GetCurrentDirectory());
        Debug.Assert(path.IsDirectory());
        Debug.Assert(!path.IsFile());
        path = path.JoinPath("logger.log");
    }

    [TestMethod]
    public void TestSingletonLogger()
    {
        // bin/Debug/net*.*がカレント
        WinPath path = new(Directory.GetCurrentDirectory());
        string logfilePath = path.JoinPath("logger.log").ToString();
        SingletonLogger logger = new SingletonLogger(logfilePath, true);
        logger.Info("Test");
        logger.Error("Test");
        logger.Warn("Test");
        logger.Debug("Test");

    }

    [TestMethod]
    public void TestSingleLogger()
    {
        // bin/Debug/net*.*がカレント
        SinpleLogger logger = new(Directory.GetCurrentDirectory(), "SinpleLoggerTest",true);
        logger.Info("Test");
        logger.Error("Test");
        logger.Error(new Exception("Exceptionもぶち込めるよ"));
        logger.Warn("Test");
        logger.Debug("Test");

    }
}