using System;
using System.IO;
using NUnit.Framework;

namespace MimeBank.Tests.Tests
{
    [TestFixture]
    public class BaseTest
    {
        public MimeChecker MimeChecker { get; set; }
        public string SolutionPath { get; set; }

        public BaseTest()
        {
            MimeChecker = new MimeChecker();
            SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        }
    }
}