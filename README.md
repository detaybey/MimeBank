MimeBank
=========

MimeBank is a file-type checker for dotnet.

Users upload stuff to your server. You should be checking the file type of the uploaded file. Don't take the file extension for granted. Make sure the JPG is a JPG.


Version
----

1.0.0

Usage
--------------

```sh
  MimeChecker mimeChecker = new MimeChecker();
  FileHeader header = mimeChecker.GetFileHeader("PATH_TO_FILE");
  Assert.AreEqual(header.Type, FileType.Image, "File should be an image");
  Assert.AreEqual(header.Extension, "jpg", "File format should be a jpg");
```

NuGet
--------------

To install MimeBank, run the following command in the Package Manager Console
```sh
PM> Install-Package MimeBank
```

License
----

Free
