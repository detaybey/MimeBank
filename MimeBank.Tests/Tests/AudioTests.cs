using NUnit.Framework;

namespace MimeBank.Tests
{
    [TestFixture]
    public class AudioTests : BaseTest
    {
        [Test]
		[TestCase("wav")]
		[TestCase("mp3")]
		[TestCase("ogg")]
		[TestCase("ra")]
		public void TestAudioFile(string type)
        {
			var path = SolutionPath + "test_file_" + type;
			var header = MimeChecker.GetFileHeader(path);
			DoTests(header, FileType.Audio, type);
        }
    }
}