using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Number
{
    class Program
    {
        // function for checking a number to determine whether a number is a prime or not
        static bool check(int n)
        {
            //to define whether 'x' is divided into 'i'
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    //it is not a prime number,a program has to finish cycle
                    return false;
            }
            // '1' is not a prime number
            if (n == 1)
                return false;
            return true;
        }

        public static void Main(string[] args)
        {
            //enter data
            string a = Console.ReadLine();
            //rewrite elements from string a to array arr
            string[] arr = a.Split();
            for(int i = 0; i < arr.Length; i++ )
            {
                //to assign each element of the array to a string
                string s = arr[i];
                //to convert string to integer
                int p = int.Parse(s);
                //check it whether it is a prime number or not
                if (check(p))
                    //display it
                    Console.WriteLine(p + " ");
            }
            //program will not finish until we press any key
            Console.ReadKey();
        }
    }
}
