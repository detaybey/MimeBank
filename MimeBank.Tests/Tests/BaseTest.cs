using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
