using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Paint
{
    class Ship
    {
        public GraphicsPath path3 = new GraphicsPath();
        public Ship(int x, int y)
        { 
            path3.AddLine(x + 100, y + 80, x + 141, y + 100); 
            path3.AddLine(x + 141, y + 100, x + 141, y + 140); 
            path3.AddLine(x + 141, y + 140, x + 100, y + 160);
            path3.AddLine(x + 100, y + 160, x + 60, y + 140); 
            path3.AddLine(x + 60, y + 140, x + 60, y + 100); 
            path3.AddLine(x + 60, y + 100, x + 100, y + 80);
          }
    }
}
