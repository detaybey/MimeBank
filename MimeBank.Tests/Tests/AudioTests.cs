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
    public class AudioTests : BaseTest
    {

        [Test]
        public void Wav()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_wav");

            Assert.NotNull(header, "File header returned null");
            Assert.AreEqual(header.Type, FileType.Audio, "Should be an audio file");
            Assert.AreEqual(header.Extension, "wav", "File format should be wav");
        }

        [Test]
        public void Mp3()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_mp3");

            Assert.NotNull(header, "File header returned null");
            Assert.AreEqual(header.Type, FileType.Audio, "Should be an audio file");
            Assert.AreEqual(header.Extension, "mp3", "File format should be mp3");
        }

        [Test]
        public void Ogg()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_ogg");

            Assert.NotNull(header, "File header returned null");
            Assert.AreEqual(header.Type, FileType.Audio, "Should be an audio file");
            Assert.AreEqual(header.Extension, "ogg", "File format should be ogg");
        }

        [Test]
        public void Ra()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_ra");

            Assert.NotNull(header, "File header returned null");
            Assert.AreEqual(header.Type, FileType.Audio, "Should be an audio file");
            Assert.AreEqual(header.Extension, "ra", "File format should be ra");
        }
    }
}
