using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using String.operations;
using System.Drawing;

namespace FUI_Label_Finder.Handlers
{
    public class FuiUtils
    {
        Form1 f1 = new Form1();

        public static Image streamToImage(string data)
        {
            Stream s = new MemoryStream(StringOperations.HexStringToByteArray(data.Replace(" ", "")));
            Image img = Image.FromStream(s);
            return img;
        }
    }
}
