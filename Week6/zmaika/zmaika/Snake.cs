using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zmaika
{
    class Snake
    {
        public char sign = 'o';
        public ConsoleColor color;
        public List<Point> body;
        public int cnt = 1;
        public Snake()
        {
            DrawSnake();
        }

        public void DrawSnake()
        {
            color = ConsoleColor.Yellow;
            body = new List<Point>();
            body.Add(new Point(10,10 ));
        }
        public void Move(int dx, int dy)
        {

            for (int i = body.Count - 1; i >= 1; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x += dx;
            body[0].y += dy;

            if (body[0].x > Console.WindowWidth)
                body[0].x = 1;
            if (body[0].x < 1)
                body[0].x = Console.WindowWidth;

            if (body[0].y > Console.WindowHeight)
                body[0].y = 1;
            if (body[0].y < 1)
                body[0].y = Console.WindowHeight;
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
        public bool CanEat(Food food)
        {
            if (body[0].x == food.x & body[0].y == food.y)
            {
                body.Add(new Point (food.x, food.y));
                return true;
            }
            return false;
        }
        public bool CollistionWithWall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }
        public bool CollisionWithSnake(Snake s)
        {
            for(int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            return false;
        }
        
    }
}
