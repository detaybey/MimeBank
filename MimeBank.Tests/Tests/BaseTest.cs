using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace MimeBank.Tests
{
	public class BaseTest
	{
		public MimeChecker MimeChecker { get; set; }

		public string AssemblyPath { get; set; }
		
		public BaseTest()
		{
			MimeChecker = new MimeChecker();
			AssemblyPath = GetFilesPath(); 
		}

		public static string GetFilesPath()
		{
			var testDir = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
			return Path.Combine(testDir, "Files");
		}

		protected static void DoTests(FileHeader header, FileType expectedFileType, string expectedExtension)
		{
			string fileTypeErrorMessage = expectedFileType switch
			{
				FileType.Image => "Should be an image file",
				FileType.Video => "Should be a video file",
				FileType.Audio => "Should be an audio file",
				FileType.Swf => "Should be a flash file",
				_ => "Unknown file type",
			};
			var extensionErrorMessage = "File format should be " + expectedExtension;
		
		   Assert.NotNull(header, "File header returned null");
		   Assert.AreEqual(header.Type, expectedFileType, fileTypeErrorMessage);
		   Assert.AreEqual(header.Extension, expectedExtension, extensionErrorMessage);
		}
	}
}
