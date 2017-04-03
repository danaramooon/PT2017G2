using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Paint
{
    class Gun
    {
        public GraphicsPath path1 = new GraphicsPath();
        public GraphicsPath path3 = new GraphicsPath();
        public Gun(int x, int y)
        {
            path1.AddLine(x + 98, y + 70, x + 120, y + 85);
            path1.AddLine(x + 120, y + 85, x + 108, y + 85);
            path1.AddLine(x + 108, y + 85, x + 108, y + 115);
            path1.AddLine(x + 108, y + 115, x + 90, y + 115);
            path1.AddLine(x + 90, y + 115, x + 90, y + 85);
            path1.AddLine(x + 90, y + 85, x + 78, y + 85);
        }
    }
}
