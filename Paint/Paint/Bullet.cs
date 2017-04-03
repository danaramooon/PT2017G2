using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
namespace Paint
{ 
    class Bullet
    {
        public GraphicsPath path = new GraphicsPath();
        public Bullet(int x, int y)
        {
            path.AddLine(x + 110, y + 70, x + 112, y + 80);
            path.AddLine(x + 112, y + 80, x + 121, y + 82);
            path.AddLine(x + 121, y + 82, x + 112, y + 84);
            path.AddLine(x + 112, y + 84, x + 110, y + 93);
            path.AddLine(x + 110, y + 93, x + 108, y + 84);
            path.AddLine(x + 108, y + 84, x + 100, y + 82);
            path.AddLine(x + 100, y + 82, x + 108, y + 80);
            path.AddLine(x + 108, y + 80, x + 110, y + 70);

        }
    }
}
