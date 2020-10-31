using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FUI_Label_Finder.Handlers
{
    public class ImageHandler
    {
        public void WriteImage(string dir, byte[] label, int i)
        {
                Directory.CreateDirectory(dir);
                Directory.CreateDirectory(dir + "\\Images\\");
                //MessageBox.Show(dir + "\\Images\\");
                File.WriteAllBytes(dir + "\\Images\\Image"+i.ToString()+".png", label);
          
        }
    }
}
