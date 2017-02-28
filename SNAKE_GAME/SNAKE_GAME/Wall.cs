using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SNAKE_GAME
{
    public class Wall
    {
        //add datas
        public char sign = '#';
        //creat list of points
        public List<Point> body = new List<Point>();
        public ConsoleColor color = ConsoleColor.Red;
        public Wall() { }
        public Wall(int level)
        {

            DirectoryInfo dr = new DirectoryInfo(@"LVL");
            FileInfo[] f = dr.GetFiles();
            StreamReader sr = new StreamReader(f[level].FullName);
            int n = int.Parse(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j < line.Length; j++)
                    if (line[j] == '#')
                        body.Add(new Point(j, i));
            }
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
        public void Save()
        {
            try
            {
                FileStream fs = new FileStream("wall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(Wall));
                xs.Serialize(fs, this);
                fs.Close();
            }
            catch(Exception e) { }
        }
        public void Resume()
        {
            try
            {
                FileStream fs = new FileStream("wall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(Wall));
                Program.wall = (Wall)xs.Deserialize(fs);
                fs.Close();
            }
            catch(Exception e) { }
        }
    }
}
