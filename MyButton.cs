using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public class MyButton : Control
    {

        public MyButton()
        {
            this.FillColor1 = Color.Black;
            this.FillColor2 = Color.Blue;
            this.FillShpae = Shape.Ellipse;
        
        }

        private void MyButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
        }

        public Color FillColor1 { get; set; }
        //public Color FillColor2 { get; set; }

        private Color m_FillColor2;
        public Color FillColor2
        {
            get
            {
                //....
                return m_FillColor2;
            }
            set
            {
                //......
                m_FillColor2 = value;
                this.Invalidate();
            }
        }

        public enum Shape { Rectangle, Ellipse}

        public Shape FillShpae {get;set;}

        protected override void OnPaint(PaintEventArgs e)
        {
            //GDI+ => WPF

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            LinearGradientBrush brush1 = new LinearGradientBrush(new PointF(0, 0), 
                                                                 new Point(0, this.ClientRectangle.Height), 
                                                                 this.FillColor1, 
                                                                 this.FillColor2);

            switch ( this.FillShpae)
            {
                case Shape.Ellipse:
                    e.Graphics.FillEllipse(brush1, this.ClientRectangle);
                    break;

                case Shape.Rectangle:
                    e.Graphics.FillRectangle(brush1, this.ClientRectangle);
                    break;
            }

            //Draw String
            Graphics g = e.Graphics;
            float x, y;
            x = (this.ClientRectangle.Width - g.MeasureString(base.Text, base.Font).Width) / 2;
            y = (this.ClientRectangle.Height - g.MeasureString(base.Text, base.Font).Height) / 2;
            g.DrawString(base.Text, base.Font, Brushes.White, x, y);

        }
    }
}
