using NUnit.Framework;

namespace MimeBank.Tests
{
    [TestFixture]
    public class ImageTests : BaseTest
    {
        [Test]
		[TestCase("jpg")]
		[TestCase("png")]
		[TestCase("gif")]
		public void TestImageFile(string type)
        {
			var path = SolutionPath + "test_file_" + type;
			var header = MimeChecker.GetFileHeader(path);
			DoTests(header, FileType.Image, type);
        }

    }
}