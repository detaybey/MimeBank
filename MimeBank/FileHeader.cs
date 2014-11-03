using System;
using System.Linq;

namespace MimeBank
{
    /// <summary>
    /// This is a data structure for holding the header byte sequences of each file format
    /// </summary>
    public class FileHeader
    {
        private const int skipValue = -1;
        // The enum type of the file
        public FileType Type { get; private set; }

        // Extension of the file
        public string Extension { get; private set; }

        // Byte sequence in hex string delimeted with space
        // if there are unpredicted bytes in the sequence, they can be defined using ??
        // for example WAV files have their 5th to 8th bytes different for each file
        // so in it's definition, the header bytes are as follows
        // "52 49 46 46 ?? ?? ?? ?? 57 41 56 45 66 6D 74 20"
        protected int[] Header { get; private set; }

        public int HeaderLength { get { return Header.Length; } }

        public FileHeader(FileType type, string extension, string header)
        {
            this.Type = type;
            this.Extension = extension;
            this.Header = parsePattern(header);
        }

        private int[] parsePattern(string header)
        {
            const char skipChar = '?';
            const string skipMarker = "??";
            return header.Split(' ')
                .Select(part =>
                {
                    if (part == skipMarker)
                    {
                        return skipValue;
                    }
                    if (part[0] == skipChar || part[1] == skipChar)
                    {
                        return -1 * Convert.ToInt32(part.Replace(skipChar, '0'), 16);
                    }
                    return Convert.ToInt32(part, 16);
                })
                .ToArray();
        }

        /// <summary>
        /// Checks the byte array against the sent file buffer
        /// </summary>
        /// <param name="buffer">the first 256 bytes sent from file</param>
        /// <returns>true if the type is correct</returns>
        public bool Check(byte[] buffer)
        {
            int headerLength = Header.Length;
            if (headerLength > buffer.Length)
            {
                return false;
            }
            for (int i = 0; i < headerLength; i++)
            {
                int headerValue = Header[i];
                if (headerValue == skipValue)
                {
                    continue;
                }
                if (headerValue < 0)
                {
                    byte b = (byte)(-1 * headerValue);
                    if ((buffer[i] & b) != b)
                    {
                        return false;
                    }
                }
                else if (buffer[i] != headerValue)
                {
                    return false;
                }
            }
            return true;
        }
    }
}