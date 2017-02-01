using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Program
    {
        static void GetdFile(string path) //creat function to open files and folders
        {
            Stack<string> directory = new Stack<string>(); // creat a stack

            directory.Push(path); // insert path(FullName)
            while (directory.Count > 0) //until the numbers of elements in stack > 0
            {
                DirectoryInfo current = new DirectoryInfo(directory.Pop()); //pop removes and returns the object at the top of the Stack
                //if we use Peek method,the process will never stop,because it will just open without removing
                DirectoryInfo[] dir = current.GetDirectories(); //creat an array of folders
                FileInfo[] files = current.GetFiles(); // creat an array of files
                Console.WriteLine(current); // to show in which folder we're standing
                Console.WriteLine("Files:" + current.GetFiles().Length); // to show the number of files in folder
                foreach (FileInfo file in files) //rewrite from array to string elements
                {
                    Console.WriteLine("---" + file.Name);
                }
                Console.WriteLine("Directories:" + current.GetDirectories().Length); // to show the number of folders
                foreach (DirectoryInfo d in dir)
                {
                    directory.Push(d.FullName); //Get FullName of folders
                }
            }

        }
        static void Main(string[] args)
        {
            GetdFile(@"C:\lab");
            Console.ReadKey();
        }
    }
}