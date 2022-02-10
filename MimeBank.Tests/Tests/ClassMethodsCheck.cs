using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace MimeBank.Tests
{
	[TestFixture]
	public class MethodTests
	{
		[Test]
		[TestCase("avi", FileType.Video, true)]
		[TestCase("jpg", FileType.Image, true)]
		[TestCase("mp3", FileType.Audio, true)]
		[TestCase("gif", FileType.Video, false)]
		[TestCase("mov", FileType.Image, false)]
		[TestCase("png", FileType.Audio, false)]
		public void TestFile(string type, FileType expectedFileType, bool expectedResult)
		{
			var path = Path.Combine(BaseTest.GetFilesPath(), "test_file_" + type); 
			var testResult = MimeChecker.Check(path, expectedFileType);
			Assert.AreEqual(expectedResult, testResult);
		}

		[Test]
		[TestCase("avi", FileType.Video, true)]
		[TestCase("jpg", FileType.Image, true)]
		[TestCase("mp3", FileType.Audio, true)]
		[TestCase("gif", FileType.Video, false)]
		[TestCase("mov", FileType.Image, false)]
		[TestCase("png", FileType.Audio, false)]
		public async Task TestFileAsync(string type, FileType expectedFileType, bool expectedResult)
		{
			var path = Path.Combine(BaseTest.GetFilesPath(), "test_file_" + type);
			var testResult = await MimeChecker.CheckAsync(path, expectedFileType);
			Assert.AreEqual(expectedResult, testResult);
		}
	}
}
