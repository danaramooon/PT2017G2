using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Far
{
    class Program
    {
        //function to show folders and files with color(background and foreground) 
        static void LookIn(DirectoryInfo dir, int cursor)
        {
            //to clear a window when another folder was opened
            Console.Clear();
            //create a FileSystemInfo because we don't know type of the element 
            FileSystemInfo[] infos = dir.GetFileSystemInfos();
            for (int i = 0; i < infos.Length; i++)
            {
                //"?" means question whether i == or != cursor, ":" means else
                Console.BackgroundColor = (i == cursor) ? ConsoleColor.DarkGray : ConsoleColor.Black;
                Console.ForegroundColor = (infos[i].GetType() == typeof(DirectoryInfo)) ? ConsoleColor.Yellow : ConsoleColor.Magenta;
                //to display folders and files
                Console.WriteLine(infos[i].Name);
            }

        }
        static void Main(string[] args)
        {
            //makes cursor of the console invisible
            Console.CursorVisible = false;
            //initialize the datas
            int cursor = 0;
            DirectoryInfo directory = new DirectoryInfo(@"c:\git");
            //endless cycle 
            while (true)
            {
                //call function to display folders and files
                LookIn(directory, cursor);
                //initialize new instance of the ConsoleKeyInfo structure
                ConsoleKeyInfo btn = Console.ReadKey();
                //switch is a control statement that executes list of candidates
                switch (btn.Key)
                {
                    //each candidates is case(has a constant exp) and it is checked for each switch case
                    case ConsoleKey.UpArrow:
                        if (cursor > 0) cursor--;
                        //it won't go to the another candidate until the previous isn't breaked
                        break;

                    case ConsoleKey.DownArrow:
                        if (cursor < directory.GetFileSystemInfos().Length - 1) cursor++;
                        break;

                    case ConsoleKey.Enter:
                       FileSystemInfo fs = directory.GetFileSystemInfos()[cursor];
                        //to identify the type of the element use function GeTtype()
                            if (fs.GetType() == typeof(DirectoryInfo))
                            {
                            //if it is a folder, open folders in this folder 
                                directory = new DirectoryInfo(fs.FullName);
                            }
                            else
                            {
                            //try catch to excide problems
                                try
                                {
                                //if it isn't clear window
                                    Console.Clear();
                                //read from this file datas
                                    StreamReader sr = new StreamReader(fs.FullName);
                                //display this datas on console
                                    Console.Write(sr.ReadToEnd());
                                Console.ReadKey(); //wait until we won't press a key
                                    sr.Close(); //have to close StreamReader()
                                }

                                catch (Exception e)
                                {
                                    Console.WriteLine("error");
                                }
                            }
                            break;

                    case ConsoleKey.Escape:
                        //go back to the previous folder 
                        directory = directory.Parent;
                        break;
                }

            }
        }
    }
}