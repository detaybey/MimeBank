using NUnit.Framework;

namespace MimeBank.Tests
{
   [TestFixture]
   public class VideoTests : BaseTest
   {
		[Test]
		[TestCase("avi")]
		[TestCase("mpg")]
		[TestCase("mp4")]
		[TestCase("wmv")]
		[TestCase("avi")]
		[TestCase("mov")]
		[TestCase("flv")]
		[TestCase("mkv")]
		public void TestVideoFile(string type)
		{
			var path = SolutionPath + "test_file_" + type;
			var header = MimeChecker.GetFileHeader(path);
			DoTests(header, FileType.Video, type);
		}
   }
}
