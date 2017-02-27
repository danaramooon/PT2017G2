using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zmaika
{
    class Program
    {
        static bool GameOver = false;
        static Snake snake = new Snake();
        static Food food = new Food();
        static void Main(string[] args)
        {
            int u = 0;
            Console.SetCursorPosition(27, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("$---WELCOME---$");
            Console.SetCursorPosition(32,11);
            Console.WriteLine("--->");
            Console.SetCursorPosition(22, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WANNA PLAY? PRESS ANY KEY!");

            
            int i = 0;
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 25);


            while (!GameOver) // GameOver == false
            {
                Wall wall = new Wall(i);
                ConsoleKeyInfo btn = Console.ReadKey();
                if(btn.Key == ConsoleKey.UpArrow)
                {
                    snake.Move(0, -1);
                }
                else if(btn.Key == ConsoleKey.DownArrow )
                {
                    snake.Move(0, 1);
                }
                else if (btn.Key == ConsoleKey.LeftArrow )
                {
                    snake.Move(-1, 0);
                }
                else if(btn.Key == ConsoleKey.RightArrow )
                {
                    snake.Move(1, 0);
                }
             

                GameOver = snake.CollistionWithWall(wall) || snake.CollisionWithSnake(snake);
                if (snake.CanEat(food))
                {
                    food.SetRandomPosition();
                }
                
                Console.Clear();
                snake.Draw();
                wall.Draw();
                food.Draw();
                if (food.foodinwall(wall))
                {
                    while(food.foodinwall(wall))
                    
                        food.SetRandomPosition();
                    
                }
                if(food.foodInSnake(snake))
                {
                    while (food.foodInSnake(snake))
                        food.SetRandomPosition();
                }
                if (i == 4)
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, 10);
                    Console.WriteLine("Winner!");
                    Console.ReadKey();
                    break;

                }
                if (snake.body.Count == 8)
                {
                    snake.DrawSnake();
                    i++;
                    wall = new Wall(i);
                }
                

            }
            
            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("GAMEOVER");
            Console.ReadKey();

        }
    }
}