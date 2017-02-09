using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // add IO for StreamReader and StreamWriter

namespace min_max
{
    class Program
    {
        //create a function to find min and max in array
        public static void dFile()
        {
            //read from a.txt the datas
            StreamReader sr = new StreamReader(@"C:\lab\a.txt");

            //write or display a result in b.txt
            StreamWriter sw = new StreamWriter(@"C:\lab\b.txt");

            //a string array that contains the substring of this instance, separated by "_"  
            string[] arr = sr.ReadLine().Split();
            try
            {
                //create an int array with the length of string array
                int[] h = new int[arr.Length];
                //to convert each element of the string array to int array
                for (int i = 0; i < arr.Length; i++)
                {
                    h[i] = int.Parse(arr[i]);
                }
                //annex to min and max the value of the first element 
                int min = h[0];
                int max = h[0];
                //count from 1 element,because we have already used 0 element
                for (int i = 1; i < arr.Length; i++)
                {
                    //compare the first element as min with others to find the min element,if it's smaller than the first 
                    if (h[i] < min)
                        //annex this element to min
                        min = h[i];

                    //compare the first element as max with others to find the max element,if it's bigger than the first
                    if (h[i] > max)
                        //annex this elemet to max
                        max = h[i];
                }

                //write a result in .txt file
                sw.WriteLine("min:" + min + " " + "max:" + max);
                //StreamReader and StreamWriter must be closen to work
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
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
