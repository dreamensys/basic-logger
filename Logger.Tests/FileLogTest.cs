using System;
using NUnit.Framework;

namespace Logger.Tests
{
    [TestFixture]
    public class FileLogTest
    {
        [Test]
        public void TestMethod1()
        {
            bool result = true;
            Assert.That(result, Is.True);
        }
    }
}
