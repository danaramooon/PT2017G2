using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // add IO for StreamReader and StreamWriter

namespace Work_with_file
{
    class Program
    {
        //creat a function to find min and max in array
        public static void dFile ()
        {
            //read from a.txt datas
            StreamReader sr = new StreamReader(@"C:\lab\a.txt");

            //write or display a result in b.txt
            StreamWriter sw = new StreamWriter(@"C:\lab\b.txt");

            //a string array that contains the substring of this instance, separated by "_"  
            string[] arr = sr.ReadLine().Split();

            //creat new, the biggest variable to find min 
            int x = 320000;

            //creat new, the smallest variable to find max
            int y = -1;

            //convert array to string 
            foreach(string p in arr)
            {
                //convert string to integer
                int h = int.Parse(p);

                //check the max
                    if (h > y)
                        y = h; //if it is the max number assign a value to y

                    //check the min
                    if (h < x)
                        x = h; //if it is the min number assign a value to x
            }
            //write a result in .txt file
            sw.WriteLine("min:" + x + " " + "max:" + y);

            //StreamReader and StreamWriter must be closen to work
            sw.Close();
            sr.Close();
        }
        static void Main(string[] args)
        {
            //call a function
            dFile();
            //window will not close until we will not press any key
            Console.ReadKey();
        }
    }
}
