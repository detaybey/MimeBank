using System;
using System.IO;
using NUnit.Framework;

namespace MimeBank.Tests.Tests
{
    public class BaseTest
    {
        public MimeChecker MimeChecker { get; set; }
        public string SolutionPath { get; set; }

        public BaseTest()
        {
            MimeChecker = new MimeChecker();
            SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        }

		protected void DoTests(FileHeader header, FileType expectedFileType, string expectedExtension)
		{
		   string fileTypeErrorMessage;
		   switch (expectedFileType)
		   {
			  default:
			  case FileType.Other:
				 fileTypeErrorMessage = "Unknown file type";
				 break;
			  case FileType.Image:
				 fileTypeErrorMessage = "Should be an image file";
				 break;
			  case FileType.Video:
				 fileTypeErrorMessage = "Should be a video file";
				 break;
			  case FileType.Audio:
				 fileTypeErrorMessage = "Should be an audio file";
				 break;
			  case FileType.Swf:
				 fileTypeErrorMessage = "Should be a flash file";
				 break;
		   }
		
		   var extensionErrorMessage = "File format should be " + expectedExtension;
		
		   Assert.NotNull(header, "File header returned null");
		   Assert.AreEqual(header.Type, expectedFileType, fileTypeErrorMessage);
		   Assert.AreEqual(header.Extension, expectedExtension, extensionErrorMessage);
		}
   }
}