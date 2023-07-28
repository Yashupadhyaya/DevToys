using System.Diagnostics;
using NUnit.Framework;

namespace YourNamespace
{
    [TestFixture]
    public class DebugLoggerTests
    {
        [Test]
        public void TestDebugLogger_Log_DebugMode_Enabled()
        {
            string message = "Test Message";
            DebugLogger logger = new DebugLogger();
            logger.Log(message);
        }

        [Test]
        public void TestDebugLogger_Log_DebugMode_Disabled()
        {
            string message = "Test Message";
            DebugLogger logger = new DebugLogger();
            logger.Log(message);
        }
    }

    public class DebugLogger
    {
        public void Log(string message)
        {
#if DEBUG
            Debug.WriteLine(message);
#endif
        }
    }
}
