using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace MimeBank.Tests
{
    [TestFixture]
    public class DocumentFileTests : BaseTest
    {
        [Test]
        [TestCase("pdf")]
        public void TestDocumentFiles(string type)
        {
            var path = Path.Combine(AssemblyPath, "test_file_" + type);
            var header = MimeChecker.GetFileHeader(path);
            DoTests(header, FileType.Document, type);
        }
		
        [Test]
        [TestCase("pdf")]
        public async Task TestDocumentFilesAsync(string type)
        {
            var path = Path.Combine(AssemblyPath, "test_file_" + type);
            var header = await MimeChecker.GetFileHeaderAsync(path);
            DoTests(header, FileType.Document, type);
        }
    }
}
