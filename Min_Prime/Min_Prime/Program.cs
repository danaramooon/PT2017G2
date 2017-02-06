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
        //function to check whether number is prime or not
        static bool check(int n)
        {
            for(int i = 2; i < n; i++)
            {
                if (n % i == 0) return false;
            }
            //it has to be a natural number more than 1
            if (n <= 1) return false;
            return true;
        }
        //create a function to find min and max in array
        public static void dFile()
        {
            //read from a.txt the datas
            StreamReader sr = new StreamReader(@"C:\lab\a.txt");

            //write or display a result in b.txt
            StreamWriter sw = new StreamWriter(@"C:\lab\c.txt");

            //a string array that contains the substring of this instance, separated by "_"  
            string[] arr = sr.ReadLine().Split();
            //try catch to excide problems
            try
            {
                //create an int array with the length of string array
                int[] h = new int[arr.Length];
                //to convert each element of the string array to int array
                for (int i = 0; i < arr.Length; i++)
                {
                    h[i] = int.Parse(arr[i]);
                }
                Array.Sort(h); // sort this array
                //annex to min and max the value of the first element 
                int min = 0; // initialize data
               for (int i = 0; i < h.Length; i++)
                { 
                    // check whether is prime number or not
                    if (check(h[i]) == true)
                    {  
                        //annex this element to min
                        min = h[i];
                        break;
                    }    
                }
                    //write a result in .txt file
                    sw.WriteLine("min:" + min);
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
