using NUnit.Framework;

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
			var path = BaseTest.GetFilesPath() + "test_file_" + type; 
			var testResult = MimeChecker.Check(path, expectedFileType);
			Assert.AreEqual(expectedResult, testResult);
		}
	}
}
