MimeBank
=========

MimeBank is a file-type checker for c#.

Users upload stuff to your server. You should be checking the file type of the uploaded file. Don't take the file extension for granted. Make sure the JPG is a JPG.


Version
----

0.1

Usage
--------------

```sh
  MimeChecker mimeChecker = new MimeChecker();
  FileHeader header = MimeChecker.GetFileHeader("PATH_TO_FILE");
  Assert.AreEqual(header.Type, FileType.Image, "File should be an image");
  Assert.AreEqual(header.Extension, "jpg", "File format should be a jpg");
```

License
----

Free
