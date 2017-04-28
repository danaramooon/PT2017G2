using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Paint_sample
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Graphics gPic;
        Color origincolor;
        Color curcolor;
        Queue<Point> q;
        bool fill = false;
        public static Paint paint;

        public Form1()
        {
            InitializeComponent();
            paint = new Paint();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            gPic = pictureBox1.CreateGraphics();
            pictureBox1.Image = bmp;
            q = new Queue<Point>();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            paint.shape = Paint_sample.Paint.Shape.PEN;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint.mouseClicked = true;
            paint.prevpoint = e.Location;
            if(paint.shape == Paint_sample.Paint.Shape.FILL)
            {
                q.Enqueue(e.Location);
                origincolor = bmp.GetPixel(e.Location.X, e.Location.Y);
                curcolor = paint.pen.Color;
            }

                while(q.Count > 0)
            {
                Point curPoint = q.Dequeue();
                Step(curPoint.X + 1, curPoint.Y);
                Step(curPoint.X - 1, curPoint.Y);
                Step(curPoint.X, curPoint.Y + 1);
                Step(curPoint.X , curPoint.Y - 1);
            }
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint.mouseClicked)
            {
                pictureBox1.Refresh();
                paint.Draw(g, e.Location);
                paint.Draw1(pictureBox1.CreateGraphics(), e.Location);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint.Draw1(g, e.Location);
            paint.mouseClicked = false;
            pictureBox1.Refresh();

        }
        private void Step(int x, int y)
        {
            if (x < 0) return;
            if (y < 0) return;
            if (x >= bmp.Width) return;
            if (y >= bmp.Height) return;
            if (bmp.GetPixel(x, y) != origincolor) return;
            bmp.SetPixel(x, y, curcolor);
            q.Enqueue(new Point(x, y));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            paint.pen.Width = trackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paint.pen = new Pen(Color.White, trackBar1.Value);
            paint.shape = Paint_sample.Paint.Shape.PEN;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            paint.shape = Paint_sample.Paint.Shape.RECTANGLE;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            paint.shape = Paint_sample.Paint.Shape.ELLIPSE;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            paint.pen.Color = (colorDialog1.Color);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            paint.pen = new Pen(Color.Red, trackBar1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paint.pen = new Pen(Color.Fuchsia, trackBar1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paint.pen = new Pen(Color.Aqua, trackBar1.Value);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            paint.pen = new Pen(Color.Yellow, trackBar1.Value);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            paint.pen = new Pen(Color.Lime, trackBar1.Value);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            paint.pen = new Pen(Color.Blue, trackBar1.Value);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("image");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("image");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            paint.shape = Paint_sample.Paint.Shape.FILL;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            paint.shape = Paint_sample.Paint.Shape.LINE;
        }
    }
}
