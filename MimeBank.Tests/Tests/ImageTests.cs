using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace MimeBank.Tests
{
	[TestFixture]
	public class ImageTests : BaseTest
	{
		[Test]
		[TestCase("jpg")]
		[TestCase("png")]
		[TestCase("gif")]
		[TestCase("heic")]
		[TestCase("heif")]
		public void TestImageFiles(string type)
		{
			var path = Path.Combine(AssemblyPath, "test_file_" + type);
			var header = MimeChecker.GetFileHeader(path);
			DoTests(header, FileType.Image, type);
		}
		
		[Test]
		[TestCase("jpg")]
		[TestCase("png")]
		[TestCase("gif")]
		[TestCase("heic")]
		[TestCase("heif")]
		public async Task TestImageFilesAsync(string type)
		{
			var path = Path.Combine(AssemblyPath, "test_file_" + type);
			var header = await MimeChecker.GetFileHeaderAsync(path);
			DoTests(header, FileType.Image, type);
		}
	}
}
