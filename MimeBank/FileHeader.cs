namespace MimeBank
{
    /// <summary>
    /// This is a data structure for holding the header byte sequences of each file format
    /// </summary>
    public class FileHeader
    {
        public const string hex = "0123456789ABCDEF?";

        // The enum type of the file
        public FileType Type { get; set; }

        // Extension of the file
        public string Extension { get; set; }

        // Byte sequence in hex string delimeted with space
        // if there are unpredicted bytes in the sequence, they can be defined using ??
        // for example WAV files have their 5th to 8th bytes different for each file
        // so in it's definition, the header bytes are as follows
        // "52 49 46 46 ?? ?? ?? ?? 57 41 56 45 66 6D 74 20"

        public string Header { get; set; }

        public FileHeader(FileType type, string ext, string data)
        {
            this.Type = type;
            this.Extension = ext;
            this.Header = data;
        }

        /// <summary>
        /// Checks the byte array against the sent file buffer
        /// </summary>
        /// <param name="buffer">the first 256 bytes sent from file</param>
        /// <returns>true if the type is correct</returns>
        public bool Check(byte[] buffer)
        {
            var index = 0;
            foreach (var bytestring in Header.Split(' '))
            {
                var hi = hex.IndexOf(bytestring[0]) * 16;
                var lo = hex.IndexOf(bytestring[1]);
                int check = buffer[index];
                if (!bytestring.Contains("?"))
                {
                    var value = hi + lo;
                    if (check != value)
                    {
                        return false;
                    }
                }
                else
                {
                    if (bytestring != "??" && (check < hi || check > hi + lo))
                    {
                        return false;
                    }
                }
                index += 1;
            }
            return true;
        }
    }
}