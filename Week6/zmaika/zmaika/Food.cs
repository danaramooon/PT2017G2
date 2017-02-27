using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zmaika
{
    class Food
    {
        public Point location;
        public int x, y;
        public char sign = '$';
        public ConsoleColor color = ConsoleColor.Magenta;
      
         public Food()
        {
            SetRandomPosition();
        }
         public void SetRandomPosition()
        {
             x = new Random().Next(5, 49);
             y = new Random().Next(5, 13);
            location = new Point(x, y);
        }


       
        public bool foodinwall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (location.x == p.x & location.y == p.y)
                {
                    return true;
                }
            }
                return false;
            
        }
        public bool foodInSnake(Snake s)//проверка не появляется ли еда в змейке
        {
            foreach(Point p in s.body)
            {
                if (location.x == p.x && p.y == location.y)
                {
                    return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(sign);
        }
    }
}
