using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project
{
    public partial class TextEditor : Form
    {
        int sorCount = 0;
        StreamReader sr;
        StreamWriter sw;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public TextEditor()
        {
            InitializeComponent();
        }

        private void mentésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void TextEditor_Load(object sender, EventArgs e)
        {
            
        }

        private void TextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            MenuPage menuPage = new MenuPage();
            menuPage.Show();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;
                ofd.FilterIndex = 2;

                var filepath = string.Empty;
                var fileContent = string.Empty;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    label2.Text = ofd.FileName;
                    label1.Text = ofd.SafeFileName;
                }

                filepath = label1.Text;
                var filestream = ofd.OpenFile();

                using(StreamReader sr=new StreamReader(filestream))
                {
                    fileContent = sr.ReadToEnd();
                }

                txtSandbox.Text = fileContent;
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                txtSandbox.Font = font.Font;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "text files (*.txt)|*.txt";
            save.FilterIndex = 1;
            save.Title = "Save text files";
            save.ShowDialog();

            if (save.FileName != "")
            {
                using(FileStream fs = (FileStream)save.OpenFile())
                {
                    string fileContent = txtSandbox.Text;
                    using(StreamWriter sw=new StreamWriter(fs))
                    {
                        sw.Write(fileContent);
                        sw.Close();
                    }
                    fs.Close();
                }
            }
            
            /*
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.button2.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.button2.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        this.button2.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();*/
            }
        }
    }

