using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Number
{
    class Program
    {
        static bool check(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            if (n == 1)
                return false;
            return true;
        }

        public static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string[] arr = a.Split();
            for(int i = 0; i < arr.Length; i++ )
            {
                string s = arr[i];
                int p = int.Parse(s);
                if (check(p))
                    Console.WriteLine(p + " ");
            }
            Console.ReadKey();
        }
    }
}
