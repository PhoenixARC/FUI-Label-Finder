using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace FUI_Label_Finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static byte[] HexStringToByteArray(string Hex)
        {
            byte[] Bytes = new byte[Hex.Length / 2];
            int[] HexValue = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
       0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
       0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            for (int x = 0, i = 0; i < Hex.Length; i += 2, x += 1)
            {
                Bytes[x] = (byte)(HexValue[Char.ToUpper(Hex[i + 0]) - '0'] << 4 |
                                  HexValue[Char.ToUpper(Hex[i + 1]) - '0']);
            }

            return Bytes;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Fj Universal Image | *.fui";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                string fileuri = opf.FileName;

                treeView1.Nodes.Clear();
                LoadFUI(fileuri, opf.SafeFileName, opf.FileName.Replace(opf.SafeFileName,""));
            }
        }

        public void LoadFUI(string fileuri, string shortfilenom, string initDir)
        {
            TreeNode newfile = new TreeNode(shortfilenom);
            newfile.Tag = fileuri;
            TreeNode labels = new TreeNode("Labels");
            TreeNode images = new TreeNode("Images");
            string raw = System.BitConverter.ToString(File.ReadAllBytes(fileuri)).Replace('-', ' ');
            string[] data = raw.Split(new[] { "00 " }, StringSplitOptions.None);
            string[] dataimg = raw.Split(new[] { "89 50 " }, StringSplitOptions.None);
            int t = 0;
            foreach (string axl in data)
            {
                if (!string.IsNullOrEmpty(axl.Replace("FF FF ", "")) && axl.StartsWith("FF FF "))
                {
                    string newdata = System.Text.Encoding.Default.GetString(HexStringToByteArray((axl.Replace("FF FF ", "").Replace(" ", ""))));
                    if (newdata.StartsWith("A") || newdata.StartsWith("B") || newdata.StartsWith("C") || newdata.StartsWith("D") || newdata.StartsWith("E") || newdata.StartsWith("F") || newdata.StartsWith("G") || newdata.StartsWith("H") || newdata.StartsWith("I") || newdata.StartsWith("J") || newdata.StartsWith("K") || newdata.StartsWith("L") || newdata.StartsWith("M") || newdata.StartsWith("N") || newdata.StartsWith("O") || newdata.StartsWith("P") || newdata.StartsWith("Q") || newdata.StartsWith("R") || newdata.StartsWith("S") || newdata.StartsWith("T") || newdata.StartsWith("U") || newdata.StartsWith("V") || newdata.StartsWith("W") || newdata.StartsWith("X") || newdata.StartsWith("Y") || newdata.StartsWith("Z") || newdata.StartsWith("a") || newdata.StartsWith("b") || newdata.StartsWith("c") || newdata.StartsWith("d") || newdata.StartsWith("e") || newdata.StartsWith("f") || newdata.StartsWith("g") || newdata.StartsWith("h") || newdata.StartsWith("i") || newdata.StartsWith("j") || newdata.StartsWith("k") || newdata.StartsWith("l") || newdata.StartsWith("m") || newdata.StartsWith("n") || newdata.StartsWith("o") || newdata.StartsWith("p") || newdata.StartsWith("q") || newdata.StartsWith("r") || newdata.StartsWith("s") || newdata.StartsWith("t") || newdata.StartsWith("u") || newdata.StartsWith("v") || newdata.StartsWith("w") || newdata.StartsWith("x") || newdata.StartsWith("y") || newdata.StartsWith("z"))
                    {
                        if (newdata.Length >= 4)
                        {
                            //MessageBox.Show(newdata);
                            TreeNode newdat = new TreeNode("Label" + t + ":" + newdata);
                            newdat.Tag = newdata;
                            labels.Nodes.Add(newdat);
                            t++;
                        }
                    }
                    //MessageBox.Show(System.Text.Encoding.Default.GetString(HexStringToByteArray((axl.Replace(" ","").Replace("FF FF ","")))));
                }
                if (axl.StartsWith("41 ") || axl.StartsWith("42 ") || axl.StartsWith("43 ") || axl.StartsWith("44 ") || axl.StartsWith("45 ") || axl.StartsWith("46 ") || axl.StartsWith("47 ") || axl.StartsWith("48 ") || axl.StartsWith("49 ") || axl.StartsWith("4A ") || axl.StartsWith("4B ") || axl.StartsWith("4C ") || axl.StartsWith("4D ") || axl.StartsWith("4E ") || axl.StartsWith("4F ") || axl.StartsWith("50 ") || axl.StartsWith("51 ") || axl.StartsWith("52 ") || axl.StartsWith("53 ") || axl.StartsWith("54 ") || axl.StartsWith("55 ") || axl.StartsWith("56 ") || axl.StartsWith("57 ") || axl.StartsWith("58 ") || axl.StartsWith("59 ") || axl.StartsWith("5A ") || axl.StartsWith("61 ") || axl.StartsWith("62 ") || axl.StartsWith("63 ") || axl.StartsWith("64 ") || axl.StartsWith("65 ") || axl.StartsWith("66 ") || axl.StartsWith("67 ") || axl.StartsWith("68 ") || axl.StartsWith("69 ") || axl.StartsWith("6A ") || axl.StartsWith("6B ") || axl.StartsWith("6C ") || axl.StartsWith("6D ") || axl.StartsWith("6E ") || axl.StartsWith("6F ") || axl.StartsWith("70 ") || axl.StartsWith("71 ") || axl.StartsWith("72 ") || axl.StartsWith("73 ") || axl.StartsWith("74 ") || axl.StartsWith("75 ") || axl.StartsWith("76 ") || axl.StartsWith("77 ") || axl.StartsWith("78 ") || axl.StartsWith("79 ") || axl.StartsWith("7A "))
                {
                    string newdata = System.Text.Encoding.Default.GetString(HexStringToByteArray((axl.Replace("FF FF ", "").Replace(" ", ""))));
                    if (newdata.StartsWith("A") || newdata.StartsWith("B") || newdata.StartsWith("C") || newdata.StartsWith("D") || newdata.StartsWith("E") || newdata.StartsWith("F") || newdata.StartsWith("G") || newdata.StartsWith("H") || newdata.StartsWith("I") || newdata.StartsWith("J") || newdata.StartsWith("K") || newdata.StartsWith("L") || newdata.StartsWith("M") || newdata.StartsWith("N") || newdata.StartsWith("O") || newdata.StartsWith("P") || newdata.StartsWith("Q") || newdata.StartsWith("R") || newdata.StartsWith("S") || newdata.StartsWith("T") || newdata.StartsWith("U") || newdata.StartsWith("V") || newdata.StartsWith("W") || newdata.StartsWith("X") || newdata.StartsWith("Y") || newdata.StartsWith("Z") || newdata.StartsWith("a") || newdata.StartsWith("b") || newdata.StartsWith("c") || newdata.StartsWith("d") || newdata.StartsWith("e") || newdata.StartsWith("f") || newdata.StartsWith("g") || newdata.StartsWith("h") || newdata.StartsWith("i") || newdata.StartsWith("j") || newdata.StartsWith("k") || newdata.StartsWith("l") || newdata.StartsWith("m") || newdata.StartsWith("n") || newdata.StartsWith("o") || newdata.StartsWith("p") || newdata.StartsWith("q") || newdata.StartsWith("r") || newdata.StartsWith("s") || newdata.StartsWith("t") || newdata.StartsWith("u") || newdata.StartsWith("v") || newdata.StartsWith("w") || newdata.StartsWith("x") || newdata.StartsWith("y") || newdata.StartsWith("z"))
                    {
                        if (newdata.Length >= 4 && Regex.IsMatch(newdata, @"^[a-zA-Z0-9_.]+$") && !newdata.Contains(".swf"))
                        {
                            //MessageBox.Show(newdata);
                            TreeNode newdat = new TreeNode("Label" + t + ":" + newdata);
                            newdat.Tag = newdata;
                            labels.Nodes.Add(newdat);
                            t++;
                        }
                    }
                    //MessageBox.Show(System.Text.Encoding.Default.GetString(HexStringToByteArray((axl.Replace(" ","").Replace("FF FF ","")))));
                }
                if (axl.Contains("2E 73 77 66"))
                {
                    string newdata = System.Text.Encoding.Default.GetString(HexStringToByteArray((axl.Replace("FF FF ", "").Replace(" ", ""))));
                    if (newdata.Replace(".swf", ".fui") != shortfilenom && File.Exists(initDir + newdata.Replace(".swf", ".fui")))
                    {

                        if (checkBox1.Checked == true)
                        {
                            LoadFUI(initDir + newdata.Replace(".swf", ".fui"), newdata.Replace(".swf", ".fui"), initDir);
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show("Dependent on:" + newdata.Replace(".swf", ".fui") + "\nLoad File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if(dr == DialogResult.Yes)
                            {
                                LoadFUI(initDir + newdata.Replace(".swf", ".fui"), newdata.Replace(".swf", ".fui"), initDir);
                            }
                        }
                        
                    }
                }
            }
            int imgnum = 0;
            foreach(string image in dataimg)
            {
                    List<string> imglist = new List<string>();
                try
                {
                    if (image.StartsWith("4E 47"))
                    {
                        imglist.Add("89 50 4E 47 " + newstring(image, "4E 47 ", " 49 45 4E 44 AE 42 60 82") + " 49 45 4E 44 AE 42 60 82");
                    }
                    foreach (string img in imglist)
                    {
                        TreeNode img1 = new TreeNode("Image" + imgnum.ToString());
                        img1.Tag = img;
                        images.Nodes.Add(img1);

                        imgnum++;
                    }
                }
                catch
                {

                }

            }
            newfile.Nodes.Add(labels);
            newfile.Nodes.Add(images);
            treeView1.Nodes.Add(newfile);

        }

        public string newstring(string St, string start, string end)
        {
            //MessageBox.Show(St);
            int pFrom = St.IndexOf(start) + start.Length;
            int pTo = St.LastIndexOf(end);

            String result = St.Substring(pFrom, pTo - pFrom);
            return result;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Text.StartsWith("Label") && treeView1.SelectedNode.Text != "Labels")
            {
                try
                {
                    //MessageBox.Show(treeView1.SelectedNode.Tag.ToString());
                    richTextBox1.Text = treeView1.SelectedNode.Tag.ToString();
                }
                catch
                {

                }
            }
            else if (treeView1.SelectedNode.Text.StartsWith("Image") && treeView1.SelectedNode.Text != "Images")
            {
                Stream stream = new MemoryStream(HexStringToByteArray(treeView1.SelectedNode.Tag.ToString().Replace(" ", "")));
                Image currimg = Image.FromStream(stream);
                pictureBox1.Image = currimg;
                if (currimg.Width < pictureBox1.Width && currimg.Height < pictureBox1.Height)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                }
                else
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    
                }
            }
        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Handlers.LabelHandler lb = new Handlers.LabelHandler() ;
                Handlers.ImageHandler Ib = new Handlers.ImageHandler() ;
                switch (treeView1.SelectedNode.Text)
                {
                    case ("Images"):
                        string dir2 = treeView1.SelectedNode.Parent.Tag.ToString().Replace(".fui", "_FUI") + "\\";
                        int i = 0;
                        foreach (TreeNode exdata in treeView1.SelectedNode.Nodes)
                        {
                            //MessageBox.Show(exdata.Tag.ToString());
                            Ib.WriteImage(dir2, HexStringToByteArray(exdata.Tag.ToString().Replace(" ","")), i);
                            i++;
                        }
                        break;


                    case ("Labels"):
                        string dir = treeView1.SelectedNode.Parent.Tag.ToString().Replace(".fui", "_FUI") + "\\";
                        foreach (TreeNode exdata in treeView1.SelectedNode.Nodes)
                        {
                            lb.WriteLabel(dir, exdata.Tag.ToString());
                        }
                        break;


                    default:
                        if (treeView1.SelectedNode.Text.StartsWith("Label") && treeView1.SelectedNode.Text != "Labels")
                        {
                            string dir1 = treeView1.SelectedNode.Parent.Tag.ToString().Replace(".fui", "_FUI") + "\\";
                            string labeltext = treeView1.SelectedNode.Tag.ToString();
                                lb.WriteLabel(dir1, labeltext);
                        }
                        else if (treeView1.SelectedNode.Text.StartsWith("Image") && treeView1.SelectedNode.Text != "Images")
                        {

                            string dir3 = treeView1.SelectedNode.Parent.Parent.Tag.ToString().Replace(".fui", "_FUI") + "\\";
                                Ib.WriteImage(dir3, HexStringToByteArray(treeView1.SelectedNode.Tag.ToString().Replace(" ", "")), int.Parse(treeView1.SelectedNode.Text.Replace("Image","")));
                            
                        }
                        else
                        {
                            MessageBox.Show("Cannot Extract this entry!");
                        }
                        break;
                }
            }
            catch(IOException err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            catch
            {

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            treeView1.Nodes.Clear();
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string file2 = file.Replace("\\", "/");
                Console.WriteLine(file2);
                //MessageBox.Show(file2);
                //MessageBox.Show(file2.Replace("\\", "/").Split('/').Length.ToString());
                string shortnom = file2.Replace("\\","/").Split('/')[file2.Split('/').Length - 1];
                string IDir = file2.Replace(shortnom, "");
                LoadFUI(file2, shortnom, IDir);
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.About ab = new Forms.About();
            ab.Show();
        }
    }
}
