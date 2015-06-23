using NUnit.Framework;

namespace MimeBank.Tests.Tests
{
    [TestFixture]
    public class ImageTests : BaseTest
    {
        [Test]
        public void Jpeg()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_jpg");

			 DoTests(header, FileType.Image, "jpg");
        }

        [Test]
        public void Png()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_png");

			 DoTests(header, FileType.Image, "png");
        }

        [Test]
        public void Gif()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_gif");

			 DoTests(header, FileType.Image, "gif");
        }
    }
}