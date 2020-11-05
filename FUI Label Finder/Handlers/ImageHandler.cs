using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FUI_Label_Finder.Forms;

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
        public void addimage(string name, string data, TreeNode tn)
        {
            Form1 f1 = new Form1();
            TreeNode a = new TreeNode(name);
            a.Tag = data;
            tn.Nodes.Add(a);
        }
    }
}
