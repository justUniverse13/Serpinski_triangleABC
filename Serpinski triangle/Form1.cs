using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serpinski_triangle
{
    public partial class Form1 : Form
    {
        public int deep = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnDraw_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height,
                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));

            SetupSierpinski(700, 10, 10, g, deep);

            pictureBox1.Image = bmp;
            label1.Text = $"Your deep is {deep}. ";
            deep++;
        }
        private void SetupSierpinski(float width, int x, int y, Graphics g, int deep)
        {
            float height = (float)(Math.Sqrt(3.0)) / 2.0f * width;         

            int xA = x, yA = y;                      
            int xB = (int)(x + width), yB = y;                     
            int xC = (int)(x + width / 2.0f), yC = (int)(y + height);       

            Sierpinski(xA, yA, xB, yB, xC, yC, g, deep);
        }

        private void Sierpinski(float xA, float yA, float xB, float yB, float xC, float yC, Graphics g, int deep)
        {
            if (deep > 0)
            {
                deep--;
                float xMa = (xB + xC) / 2, yMa = (yB + yC) / 2;
                float xMb = (xA + xC) / 2, yMb = (yA + yC) / 2;
                float xMc = (xA + xB) / 2, yMc = (yA + yB) / 2;

                Sierpinski(xA, yA, xMb, yMb, xMc, yMc, g, deep);
                Sierpinski(xMc, yMc, xMa, yMa, xB, yB, g, deep);
                Sierpinski(xMb, yMb, xMa, yMa, xC, yC, g, deep);
            }
            else
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                PointF P1 = new PointF(xA, yA);
                PointF P2 = new PointF(xB, yB);
                PointF P3 = new PointF(xC, yC);
                PointF[] Points = new PointF[] { P1, P2, P3 };
                g.FillPolygon(Brushes.Black, Points);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
