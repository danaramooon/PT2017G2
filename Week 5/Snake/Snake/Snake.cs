using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public char sign;
        public ConsoleColor color;
        public List<Point> body;
        public int cnt = 1;

        public Snake()
        {
            sign = 'o';
            color = ConsoleColor.Magenta;
            body = new List<Point>();
            body.Add(new Point(10, 10));
        }
        public void Move(int dx, int dy)
        {
            if (cnt % 10 == 0)
                body.Add(new Point(10, 10));
            for (int i = body.Count - 1; i >= 1; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x += dx;
            body[0].y += dy;

            if (body[0].x > Console.WindowWidth - 10)
                body[0].x = 1;
            if (body[0].x < 1)
                body[0].x = Console.WindowWidth - 10;

            if (body[0].y > Console.WindowHeight - 10)
                body[0].y = 1;
            if (body[0].y < 1)
                body[0].y = Console.WindowHeight - 10;
            cnt++;


        }


        public void Draw()
        {
            Console.Clear();
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);

            }
        }

    }
}