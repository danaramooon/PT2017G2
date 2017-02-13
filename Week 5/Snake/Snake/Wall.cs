using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Wall
    {
        public char sign;
        public ConsoleColor color;
        List<Point> body;

        public Wall()
        {
            sign = '*';
            color = ConsoleColor.Green;
            body = new List<Point>();
            StreamReader sr = new StreamReader("wall.txt");
            int n = int.Parse(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '*')
                        body.Add(new Point(j, i));
                }
            }
            sr.Close();
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);

            }
        }
    }
}