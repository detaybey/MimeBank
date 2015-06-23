using NUnit.Framework;

namespace MimeBank.Tests.Tests
{
   [TestFixture]
   public class VideoTests : BaseTest
   {
	  [Test]
	  public void Avi()
	  {
		 var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_avi");

		 DoTests(header, FileType.Video, "avi");
	  }

	  [Test]
	  public void Mpg()
	  {
		 var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_mpg");

		 DoTests(header, FileType.Video, "mpg");
	  }

	  [Test]
	  public void Mp4()
	  {
		 var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_mp4");

		 DoTests(header, FileType.Video, "mp4");
	  }

	  [Test]
	  public void Wmv()
	  {
		 var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_wmv");

		 DoTests(header, FileType.Video, "wmv");
	  }

	  [Test]
	  public void Mov()
	  {
		 var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_mov");

		 DoTests(header, FileType.Video, "mov");
	  }

	  [Test]
	  public void Flv()
	  {
		 var header = MimeChecker.GetFileHeader(SolutionPath + "/Files/test_file_flv");

		 DoTests(header, FileType.Video, "flv");
	  }

   }
}
