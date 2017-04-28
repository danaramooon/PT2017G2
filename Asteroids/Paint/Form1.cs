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
        public enum Direction
        {
            UP,
            RIGHT,
            DOWN,
            LEFT,
            NONE
        };
        Direction dir; 
        Bitmap btm;
        Bullet b;
       public  Graphics g;
        Gun gun;
        Ship s;
        SolidBrush brush;
        SolidBrush brushR;
        SolidBrush brush2, brush3;
        Random r;
        Aster as1, as2, as3, as4;
        bool q = false;
        public Point[] asteroid_points;
        public int x = 300, y = 125;
        public int b1 = 300, b2 = 150, b3 = 105;
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
            brushR = new SolidBrush(Color.Red);
            brush3 = new SolidBrush(Color.Green);
            brush2 = new SolidBrush(Color.Yellow);
            s = new Ship(300, 125);
            as1 = new Aster(180, 200);
            as2 = new Aster(220, 450);
            as3 = new Aster(800, 170);
            as4 = new Aster(610, 510);
            dir = Direction.NONE;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                dir = Direction.UP;
            }
            if (e.KeyCode == Keys.Down)
            {
                dir = Direction.DOWN;
            }
            if (e.KeyCode == Keys.Right)
            {
                dir = Direction.RIGHT;
            }
            if (e.KeyCode == Keys.Left)
            {
                dir = Direction.LEFT;
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static int x1 = 180, x2 = 220, x3 = 800, x4 = 610;
        static int y1 = 200, y2 = 450, y3 = 170, y4 = 510;
        private void timer1_Tick(object sender, EventArgs e)
        {
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            btm = new Bitmap(@"C:\Users\Данара\Pictures\Saved Pictures\h.jpg");
            g = Graphics.FromImage(btm);
            pictureBox1.Image = btm;
          
            x1++; // asteroids
            y1++;
            if (x1 == 984)
                x1 = 0;
            if (y1 == 650)
                y1 = 0;
            x2++;
            y2--;
            if (x2 == 984)
                x2 = 0;
            if (y2 == 0)
                y2 = 650;
            x3--;
            y3++;
            if (x3 == 0)
                x3 = 984;
            if (y3 == 650)
                y3 = 0;
            x4--;
            y4--;
            if (x4 == 0)
                x4 = 984;
            if (y4 == 0)
                y4 = 650;
            as1 = new Aster(x1, y1);
            as2 = new Aster(x2, y2);
            as3 = new Aster(x3, y3);
            as4 = new Aster(x4, y4);
            if (dir == Direction.UP)
            {
                s = new Ship(x, y -= 10);
                gun = new Gun(b1, b2 -= 10);
                b = new Bullet (b1, b3 -= 10);
            }
            if (dir == Direction.DOWN)
            {
                s = new Ship(x, y += 10);
                gun = new Gun(b1, b2 += 10);
                b = new Bullet(b1, b3+= 10);
            }
            if (dir == Direction.RIGHT)
            {
                s = new Ship(x += 10, y);
                gun = new Gun(b1 +=2, b2 );
                b = new Bullet(b1+=10, b3);

            }
            if (dir == Direction.LEFT)
            {
                s = new Ship(x -= 10, y);
                gun = new Gun(b1 -=2, b2 );
                b = new Bullet(b1 -=10, b3 );

            }

            Paint1();
      
        }
        private void Paint1()
        {
            g.FillPath(brushR, as1.path); // asteroids
            g.FillPath(brushR, as1.path1);
            g.FillPath(brushR, as2.path);
            g.FillPath(brushR, as2.path1);
            g.FillPath(brushR, as3.path);
            g.FillPath(brushR, as3.path1);
            g.FillPath(brushR, as4.path);
            g.FillPath(brushR, as4.path1);
            g.DrawPath(new Pen(Color.Green), b.path);
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
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
