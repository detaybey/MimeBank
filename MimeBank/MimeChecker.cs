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
        private const int maxBufferSize = 256;

        private static List<FileHeader> list { get; set; }
        private List<FileHeader> List
        {
            get
            {
                if (list == null)
                {
                    list = HeaderData.GetList();
                }
                return list;
            }
        }
        private byte[] Buffer;

        public MimeChecker()
        {
            Buffer = new byte[maxBufferSize];
        }

        public FileHeader GetFileHeader(Stream stream)
        {
            stream.Read(Buffer, 0, maxBufferSize);
            return this.List.FirstOrDefault(mime => mime.Check(Buffer));
        }

        public FileHeader GetFileHeader(string file)
        {
            using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                return GetFileHeader(stream);
            }
        }
    }
}