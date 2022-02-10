using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

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
			var path = Path.Combine(AssemblyPath, "test_file_" + type);
			var header = MimeChecker.GetFileHeader(path);
			DoTests(header, FileType.Audio, type);
		}

		[Test]
		[TestCase("wav")]
		[TestCase("mp3")]
		[TestCase("ogg")]
		[TestCase("ra")]
		public async Task TestAudioFileAsync(string type)
		{
			var path = Path.Combine(AssemblyPath, "test_file_" + type);
			var header = await MimeChecker.GetFileHeaderAsync(path);
			DoTests(header, FileType.Audio, type);
		}
	}
}
