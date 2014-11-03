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

            Assert.NotNull(header, "File header returned null");
            Assert.AreEqual(header.Type, FileType.Image, "File should be an image");
            Assert.AreEqual(header.Extension, "jpg", "File format should be a jpg");
        }

        [Test]
        public void Png()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_png");

            Assert.NotNull(header, "File header returned null");
            Assert.AreEqual(header.Type, FileType.Image, "File should be an image");
            Assert.AreEqual(header.Extension, "png", "File format should be a png");
        }

        [Test]
        public void Gif()
        {
            var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_gif");

            Assert.NotNull(header, "File header returned null");
            Assert.AreEqual(header.Type, FileType.Image, "File should be an image");
            Assert.AreEqual(header.Extension, "gif", "File format should be a gif");
        }
    }
}