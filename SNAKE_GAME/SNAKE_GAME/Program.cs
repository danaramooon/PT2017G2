using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace SNAKE_GAME
{
    class Program
    {
        static bool GameOver = false;
        public static Snake snake = new Snake();
        public static Food food = new Food();
        public static Wall wall;
        public static int d = 0;
        public static int u = 1;
        public static int r = 0;
        public static int i = 0;
        public static int l = 300;
        static void Save()
        {
            snake.Save();
            food.Save();
            wall.Save();

        }
        static void Resume()
        {
            snake.Resume();
            food.Resume();
            wall.Resume();
        }
      public static void MoveSnake()
        {
            while (true)
            {
                if (d == 0)
                {
                    snake.Move(0, 0);
                }
                if (d == 1)
                {
                    snake.Move(1, 0);
                }
                if (d == 2)
                {
                    snake.Move(0, 1);
                }
                if (d == 3)
                {
                    snake.Move(-1, 0);
                }
                if (d == 4)
                {
                    snake.Move(0, -1);
                }
                if (d == 6)
                {
                    FileStream fs = new FileStream("score.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    XmlSerializer xs = new XmlSerializer(typeof(int));
                    xs.Serialize(fs, r);
                    fs.Close();
                    FileStream fz = new FileStream("level.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    XmlSerializer xz = new XmlSerializer(typeof(int));
                    xz.Serialize(fz, u);
                    fz.Close();
                    Save();
                }
                if(d == 7)
                {
                    FileStream fs = new FileStream("score.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    XmlSerializer xs = new XmlSerializer(typeof(int));
                    r = (int)xs.Deserialize(fs);
                    fs.Close();
                    FileStream fz = new FileStream("level.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    XmlSerializer xz = new XmlSerializer(typeof(int));
                    u = (int)xz.Deserialize(fz);
                    fz.Close();
                    Resume();
                    Console.Clear();
                    snake.body.Remove(snake.body[0]);
                }
                if (GameOver = snake.CollistionWithWall(wall) || snake.CollisionWithSnake(snake))
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, 10);
                    Console.WriteLine("GAMEOVER");
                    Console.ReadKey();
                    return;
                }
                if (snake.CanEat(food))
                {
                    food.SetRandomPosition();
                    r++;
                }

                snake.Draw();
                wall.Draw();
                food.Draw();
                if (food.foodinwall(wall))
                {
                    while (food.foodinwall(wall))
                    {

                        food.SetRandomPosition();
                    }
                }
                if (food.foodInSnake(snake))
                {
                    while (food.foodInSnake(snake))
                    {
                        food.SetRandomPosition();
                    }
                }

                if (snake.body.Count == 4)
                {
                    for (int i = snake.body.Count() - 1; i >= 0; i--)
                    {
                        Console.SetCursorPosition(snake.body[i].x, snake.body[i].y);
                        Console.Write(' ');
                    }
                    snake = new Snake();
                    i++;
                    d = 0;

                    if (i == 3)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine("Winner!");
                        Console.ReadKey();
                        return;

                    }
                    wall = new Wall(i);
                    u++;
                }

                Console.SetCursorPosition(10, 18);
                Console.WriteLine("Current Level:" + u);
                Console.SetCursorPosition(10, 20);
                Console.WriteLine("Score:" + r);
                Thread.Sleep(500 - u * 100);
            }
        }
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 25);
            Console.SetCursorPosition(27, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("$---WELCOME---$");
            Console.SetCursorPosition(32, 11);
            Console.WriteLine("--->");
            Console.SetCursorPosition(22, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WANNA PLAY? PRESS ANY KEY!");
            Console.ReadKey();
            Console.Clear();
            Thread t = new Thread(MoveSnake);
             t.Start();

            while (!GameOver) // GameOver == false
        {

            wall = new Wall(i);
            ConsoleKeyInfo btn = Console.ReadKey();

            if (btn.Key == ConsoleKey.UpArrow )
            {
                 if(d != 2 | snake.body.Count <= 1)
                d = 4;
                //snake.Move(0, -1);
            }
            else if (btn.Key == ConsoleKey.DownArrow)
            {
                    if(d != 4 | snake.body.Count <= 1)
                d = 2;
                //snake.Move(0, 1);
            }
            else if (btn.Key == ConsoleKey.LeftArrow)
            {
                    if(d != 1 | snake.body.Count <= 1)
                d = 3;
                //snake.Move(-1, 0);
            }
            else if (btn.Key == ConsoleKey.RightArrow)
            {
                    if(d != 3 | snake.body.Count <= 1)
                d = 1;
                //snake.Move(1, 0);
            }

            if (btn.Key == ConsoleKey.F2)
            {
                    d = 6;
               // Save();
            }
            if (btn.Key == ConsoleKey.F3)
            {
                    d = 7;   
                //Resume();
            }
                }

            }

        }
    }
