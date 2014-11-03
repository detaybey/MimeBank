/*
* Programmed by Umut Celenli umut@celenli.com 
*/

using System;
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
            Buffer = new byte[256];
        }

        public FileHeader GetFileHeader(string file)
        {
            if (!System.IO.File.Exists(file))
            {
                throw new Exception("File was not found on path " + file);
            }
            using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                fs.Read(Buffer, 0, 256);
            }
            return this.List.FirstOrDefault(mime => mime.Check(Buffer) == true);
        }

    }


}


