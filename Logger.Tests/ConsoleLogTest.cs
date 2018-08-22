using System;
using NUnit.Framework;
using LoggerBusiness;
using LoggerBusiness.Factories;

namespace Logger.Tests
{
    [TestFixture]
    public class ConsoleLogTest
    {
        [Test]
        public void CanConsoleLogError()
        {
            LoggerBusiness.Logger log = (LoggerBusiness.Logger)LoggerFactory.Resolve<ILogger>();
            string message = "Hello Error";
            log.LogError(message);
            Assert.That(ConsoleColor.Red == Console.ForegroundColor);
        }
        [Test]
        public void CanConsoleLogWarning()
        {
            LoggerBusiness.Logger log = (LoggerBusiness.Logger)LoggerFactory.Resolve<ILogger>();
            string message = "Hello Warning";
            log.LogError(message);
            Assert.That(ConsoleColor.Yellow == Console.ForegroundColor);
        }
        [Test]
        public void CanConsoleLogMessage()
        {
            LoggerBusiness.Logger log = (LoggerBusiness.Logger)LoggerFactory.Resolve<ILogger>();
            string message = "Hello Message";
            log.LogError(message);
            Assert.That(ConsoleColor.White == Console.ForegroundColor);
        }
    }
}
