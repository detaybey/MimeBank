using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace MimeBank.Tests
{
    [TestFixture]
    public class CompressedFileTests : BaseTest
    {
        [Test]
        [TestCase("7z")]
        [TestCase("zip")]
        [TestCase("rar")]
        public void TestCompressedFile(string type)
        {
            var path = Path.Combine(AssemblyPath, "test_file_" + type);
            var header = MimeChecker.GetFileHeader(path);
            DoTests(header, FileType.Compressed, type);
        }

        [Test]
        [TestCase("7z")]
        [TestCase("zip")]
        [TestCase("rar")]
        public async Task TestCompressedFilesAsync(string type)
        {
            var path = Path.Combine(AssemblyPath, "test_file_" + type);
            var header = await MimeChecker.GetFileHeaderAsync(path);
            DoTests(header, FileType.Compressed, type);
        }
    }
}
