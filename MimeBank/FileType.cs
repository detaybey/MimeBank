using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimeBank
{
    /// <summary>
    /// Just an enum to categorize the file types.
    /// </summary>
    public enum FileType
    {
        Image = 1,          
        Video = 2,
        Audio = 3,
        Swf = 4,
        Other = 255
    }

}
