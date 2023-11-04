using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsciiGen2
{
    
    public partial class Form1 : Form 
    {
        protected int Xsize = 0;
        protected int Ysize = 0;
        protected Bitmap image1;
        string asciiArt;
        delegate void strDelegate(string strFinal);

        public Form1()
        {
            InitializeComponent();
        }

        protected  void AsciitizeButton()
        {
            BitmapAscii bit = new BitmapAscii(Xsize, Ysize);
            
            asciiArt = bit.Asciitize(image1);

        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                image1 = new Bitmap(open.FileName);
                pictureBox1.Image = image1;
            }
            
        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor= Color.MediumSlateBlue;
        }

        //Kernel X size
        private void numericUpDown1_Validated(object sender, EventArgs e)
        {
            Xsize = Convert.ToInt32(numericUpDown1.Value);
            
        }

        //Kernel Y size
        private void numericUpDown2_Validated(object sender, EventArgs e)
        {
            Ysize = Convert.ToInt32(numericUpDown2.Value);
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            AsciitizeButton();
            richTextBox1.Text = asciiArt;

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
