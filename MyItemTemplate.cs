using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class MyItemTemplate : UserControl
    {
        public string Desc
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }

        public byte[] ImageBytes
        {
            set
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(value);
                this.pictureBox1.Image = Image.FromStream(ms);
            }
        }

        public string ImagePath
        {
            set
            {
                this.pictureBox1.Load(value);
            }
        }

        public MyItemTemplate()
        {
            InitializeComponent();

            this.pictureBox1.MouseEnter += PictureBox1_MouseEnter;
            this.pictureBox1.MouseLeave += PictureBox1_MouseLeave;
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Width -= 7;
            this.pictureBox1.Height -= 7;
            this.pictureBox1.BackColor = Color.Gray;
            //throw new NotImplementedException();
        }

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.Width += 7;
            this.pictureBox1.Height += 7;
            this.pictureBox1.BackColor = Color.Red;
            
            
            //throw new NotImplementedException();
        }
    }
    
}
