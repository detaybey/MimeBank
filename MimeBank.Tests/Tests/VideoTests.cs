using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

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
			var path = Path.Combine(AssemblyPath, "test_file_" + type);
			var header = MimeChecker.GetFileHeader(path);
			DoTests(header, FileType.Video, type);
		}

		[Test]
		[TestCase("avi")]
		[TestCase("mpg")]
		[TestCase("mp4")]
		[TestCase("wmv")]
		[TestCase("avi")]
		[TestCase("mov")]
		[TestCase("flv")]
		[TestCase("mkv")]
		public async Task TestVideoFileAsync(string type)
		{
			var path = Path.Combine(AssemblyPath, "test_file_" + type);
			var header = await MimeChecker.GetFileHeaderAsync(path);
			DoTests(header, FileType.Video, type);
		}
	}
}
