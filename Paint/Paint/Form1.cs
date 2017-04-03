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

namespace Paint
{
    public partial class Form1 : Form
    {
        Bitmap btm;
        Bullet b;
       public  Graphics g;
        Gun gun;
        Ship s;
        SolidBrush brush;
        SolidBrush brush1;
        SolidBrush brush2, brush3;
        public Form1()
        {
            InitializeComponent();
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            btm = new Bitmap(@"C:\Users\Данара\Pictures\Saved Pictures\h.jpg");
            g = Graphics.FromImage(btm);
            pictureBox1.Image = btm;
            b = new Bullet(300, 105);
            gun = new Gun(300, 150);
            brush = new SolidBrush(Color.White);
            brush1 = new SolidBrush(Color.Red);
            brush3 = new SolidBrush(Color.Green);
            brush2 = new SolidBrush(Color.Yellow);
            s = new Ship(297, 125);
         }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Point[] draw_asteroids(int n)
        {
            int x = 0, y = 0;
            switch (n)
            {
                case 1:
                    x = 110;
                    y = 269;
                    break;
                case 2:
                    x = 211;
                    y = 123;
                    break;
                case 3:
                    x = 484;
                    y = 121;
                    break;
                case 4:
                    x = 500;
                    y = 334;
                    break;
                case 5:
                    x = 219;
                    y = 340;
                    break;
            }
            Point asteroids_p1 = new Point(x, y);
            Point asteroids_p2 = new Point(x - 10, y - 10);
            Point asteroids_p3 = new Point(x - 20, y - 10);
            Point asteroids_p4 = new Point(x - 10, y - 20);
            Point asteroids_p5 = new Point(x - 20, y - 30);
            Point asteroids_p6 = new Point(x - 10, y - 30);
            Point asteroids_p7 = new Point(x, y - 40);
            Point asteroids_p8 = new Point(x + 10, y - 30);
            Point asteroids_p9 = new Point(x + 20, y - 30);
            Point asteroids_p10 = new Point(x + 10, y - 20);
            Point asteroids_p11 = new Point(x + 20, y - 10);
            //Point asteroids_p12 = new Point(x + 10, y - 10);
            Point[] asteroid_points = { asteroids_p1, asteroids_p2, asteroids_p3, asteroids_p4, asteroids_p5, asteroids_p6, asteroids_p7, asteroids_p8, asteroids_p9, asteroids_p10, asteroids_p11 };//, asteroids_p12 };
            return asteroid_points;
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                g.FillPolygon(brush1, draw_asteroids(i + 1));
            }
            g.DrawPath(new Pen(Color.Green),b.path);
            g.FillPath(brush3, b.path);
            g.DrawPath(new Pen(Color.Yellow), s.path3);
            g.FillPath(brush2, s.path3);
            g.DrawPath(new Pen(Color.Green), gun.path1);
            g.FillPath(brush3, gun.path1);

            g.FillEllipse(brush, 100, 410, 25, 25);
            g.FillEllipse(brush, 350, 400, 25, 25);
            g.FillEllipse(brush, 100, 150, 25, 25);
            g.FillEllipse(brush, 330, 120, 25, 25);
            g.FillEllipse(brush, 490, 170, 25, 25);
            g.FillEllipse(brush, 600, 400, 25, 25);
            g.FillEllipse(brush, 550, 310, 25, 25);
            g.FillEllipse(brush, 640, 240, 25, 25);
        }
    }
}
