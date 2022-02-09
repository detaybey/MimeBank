using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace MimeBank.Tests
{
	[TestFixture]
	public class PartialSignatureTest
	{
		[Test]
		public void PartialSignature_IsDetected()
		{
			var buffer = new byte[] { 00, 00, 01, 0xB0 };
			var checker = new MimeChecker();

			for (int n = 0; n < 16; n++)
			{
				using var stream = new MemoryStream(buffer);
				buffer[3] = (byte)(0xB0 | n);
				var header = checker.GetFileHeader(stream);
				Assert.AreEqual(FileType.Video, header.Type);
				Assert.AreEqual("mpg", header.Extension);
			}
		}

		[Test]
		public async Task PartialSignature_IsDetectedAsync()
		{
			var buffer = new byte[] { 00, 00, 01, 0xB0 };
			var checker = new MimeChecker();

			for (int n = 0; n < 16; n++)
			{
				using var stream = new MemoryStream(buffer);
				buffer[3] = (byte)(0xB0 | n);
				var header = await checker.GetFileHeaderAsync(stream);
				Assert.AreEqual(FileType.Video, header.Type);
				Assert.AreEqual("mpg", header.Extension);
			}
		}
	}
}
