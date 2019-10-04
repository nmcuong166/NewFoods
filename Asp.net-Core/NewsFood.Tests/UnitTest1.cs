using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        public LogAnalyzer analyzer;
        [SetUp]
        public void Setup()
        {
            analyzer = new LogAnalyzer();
        }

        [Test]
        public void Test1()
        {
            //act
            bool reasult = analyzer.IsValidLogFileName("whatever.slf");

            //assert
            Assert.IsTrue(reasult, "find name should be vaild");
        }

        [Test]
        public void IsValidFileName_EmptyFileName_ThrowsException()
        {
            bool reasult = analyzer.IsValidLogFileName(string.Empty);

            Assert.IsFalse(reasult, "filename null or empty");
        }

        [Test]
        public void IsValidFileName_VaildName_CheckPropotyName()
        {
            analyzer.IsValidLogFileName("somefile.slf");
            Assert.IsTrue(analyzer.wasLastFileNameValid);
        }

    }

    public class LogAnalyzer
    {
        public bool wasLastFileNameValid { get; set; }
        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }

            if (!fileName.EndsWith(".slf"))
            {
                wasLastFileNameValid = false;
                return false;
            }
            wasLastFileNameValid = true;
            return true;
        }
    }
}