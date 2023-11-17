![Static Badge](https://img.shields.io/badge/build-headers-brightgreen?label=check%20your&labelColor=ffcc00&color=000000)
![GitHub Workflow Status (with event)](https://img.shields.io/github/actions/workflow/status/detaybey/MimeBank/main.yml)
![github workflow](https://github.com/detaybey/MimeBank/actions/workflows/main.yml/badge.svg)
![tests](https://raw.githubusercontent.com/gist/detaybey/2fedd2a36dc6905b3cda91d58d1a5fc0/raw/dfbda6c2fe64e715599e637cbc6cab9ce237bf53/badge.svg)
![Nuget](https://img.shields.io/nuget/dt/MimeBank)

MimeBank
=========

MimeBank is a file-type checker for dotnet.

Users upload stuff to your server. You should be checking the file type of the uploaded file. Don't take the file extension for granted. Make sure the JPG is a JPG.


Versions
----

1.0.2 (legacy)

2.0.0 (netstandard2.1;net6.0)  

2.0.1 (netstandard2.1;net6.0;net7.0)  

Usage
--------------

```c#
  MimeChecker mimeChecker = new MimeChecker();
  FileHeader header = mimeChecker.GetFileHeader("PATH_TO_FILE");
  Assert.AreEqual(header.Type, FileType.Image, "File should be an image");
  Assert.AreEqual(header.Extension, "jpg", "File format should be a jpg");
  
  // or simply a boolean check
  var check = MimeChecker.check("PATH_TO_FILE", FileType.EXPECTED_FILE_TYPE); 
```

NuGet
--------------

To install MimeBank, run the following command in the Package Manager Console
```sh
PM> Install-Package MimeBank
```


Thanks
----
[ScottMB](https://github.com/scottmb) (MKV Support)

[Zach Meyers](https://github.com/zach-meyers) (net6.0 Support)

[gokceyucel](https://github.com/gokceyucel) (fixes & additional tests)

[SSG](https://github.com/ssg) (fixes)

License
----
Apache License 2.0
