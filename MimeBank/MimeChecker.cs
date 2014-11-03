/*
* Programmed by Umut Celenli umut@celenli.com
*/

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MimeBank
{
    /// <summary>
    /// This is the main class to check the file mime type
    /// Header list is loaded once
    /// </summary>
    public class MimeChecker
    {
        public MimeChecker()
        {
        }

        public FileHeader GetFileHeader(Stream stream)
        {
            var buffer = new byte[HeaderData.MaxBufferSize];
            stream.Read(buffer, 0, HeaderData.MaxBufferSize);
            return HeaderData.Items.FirstOrDefault(mime => mime.Check(buffer));
        }

        public FileHeader GetFileHeader(string file)
        {
            using (var stream = File.OpenRead(file))
            {
                return GetFileHeader(stream);
            }
        }
    }
}