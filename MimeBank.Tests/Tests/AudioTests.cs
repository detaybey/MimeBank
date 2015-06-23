using NUnit.Framework;

namespace MimeBank.Tests.Tests
{
    [TestFixture]
    public class AudioTests : BaseTest
    {
        [Test]
        public void Wav()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_wav");

			 DoTests(header, FileType.Audio, "wav");
        }

        [Test]
        public void Mp3()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_mp3");

			 DoTests(header, FileType.Audio, "mp3");
        }

        [Test]
        public void Ogg()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_ogg");

			 DoTests(header, FileType.Audio, "ogg");
        }

        [Test]
        public void Ra()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_ra");

			 DoTests(header, FileType.Audio, "ra");
        }
    }
}