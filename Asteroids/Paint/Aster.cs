using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Paint
{
    class Aster
    {
        public GraphicsPath path = new GraphicsPath();
        public GraphicsPath path1 = new GraphicsPath();
        public Aster(int x, int y)
        {
            Point[] p1 =
                {
                new Point(x,y-30),
                new Point(x+30,y+15),
                new Point(x-30,y+15)
                };
            Point[] p2 =
            {
                new Point(x-30,y-15),
                new Point(x+30,y-15),
                new Point(x,y+30)
            };
            path.AddPolygon(p1);
            path1.AddPolygon(p2);
        }
    }
}
