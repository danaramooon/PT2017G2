using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace SNAKE_GAME
{
    public class Food
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
            x = new Random().Next(1, 60);
            y = new Random().Next(1, 20);
            location = new Point(x, y);
        }
        public void Save()
        {
            try
            {
                string D = @"C:\Users\Данара\Documents\Visual Studio 2015\Projects\SNAKE_GAME\SNAKE_GAME\bin\Debug\food.xml";
                File.Delete(D);
                FileStream fs = new FileStream("food.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(Food));
                xs.Serialize(fs, Program.food);
                fs.Close();
            }
            catch(Exception e)
            {
          
            }
        }
        public void Resume()
        {
            try
            {
                FileStream fs = new FileStream("food.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(Food));
                Program.food = (Food)xs.Deserialize(fs);
                fs.Close();
            }
            catch(Exception e) {
              
            }
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
            foreach (Point p in s.body)
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
