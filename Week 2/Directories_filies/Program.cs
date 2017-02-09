using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Directories_filies
{
    class Program
    {
        //function to display with "-"
        static void emptyspace(int level)
        {
            for(int i = 0; i < level;i++)
            {
                Console.Write("-");
            }
        }
        //recurtion function that opens a directories
        static void recur(string path, int level)
        {
            //display with only 3 "-"
            if (level > 3)
                return;
            //try{} and catch{"Error"} for files or directories that are not avaible,error for users are invisible
            try
            {
                //creat a new variable
                DirectoryInfo directory = new DirectoryInfo(path);
                //to get all directories
                DirectoryInfo[] directories = directory.GetDirectories();
                //to get all files from folders
                FileInfo[] files = directory.GetFiles();
                //to show how many Files in directory
                Console.WriteLine("Files:" + directory.GetFiles().Length);
                foreach (FileInfo file in files)
                {
                    emptyspace(level);
                    //to get Names of files
                    Console.WriteLine(file.Name);
                }
                //to show how many directories in directories
                Console.WriteLine("Directories:" + directories.Length);
                foreach (DirectoryInfo dInfo in directories)
                {
                    emptyspace(level);
                    //to get fullName (or path)
                    Console.WriteLine(dInfo.FullName);
                    //use function to open directories in the directories
                    //level + 1 to open folder in this folder
                    recur(dInfo.FullName, level + 1);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error");
            }
        }

        public static void Main(string[] args)
        {
            recur(@"c:\distr",0);
            Console.ReadKey();
        }
    }
}
