using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FUI_Label_Finder.Handlers
{
    public class LabelHandler
    {
        public void WriteLabel(string dir, string label)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                Directory.CreateDirectory(dir + "\\Images\\");
                File.AppendAllText(dir + "\\Labels.txt", label + "\n");
            }
        }
    }
}
