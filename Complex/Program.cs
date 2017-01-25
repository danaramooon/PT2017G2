using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        class Complex //creat a class
        {
            //added datas
            public int x;
            public int y;
            public Complex(int x, int y) //creat a constructor
            {
                //initialize class attributes
                this.x = x;
                this.y = y;
            }
            //rewrite function ToString()
            public override string ToString()
            {
                return x + "/" + y;
            }
            //function to find gcd of two complex numbers
            static int gcd(int x, int y)
            {
                if (x == 0)
                    return y;
                return gcd(y % x, x);
            }
            //provide overload a binary operator +
            public static Complex operator +(Complex x, Complex y)
            {
                //changed the purpose of  +  by adding new class 
                Complex c = new Complex(x.x * y.y + y.x * x.y, x.y * y.y);
                return c;
            }
            static void Main(string[] args)
            {
                string s = Console.ReadLine();
                string[] arr = s.Split();
                Complex sum = new Complex(0, 1);
                foreach (string ss in arr)
                {
                    string[] t = ss.Split('/');
                    Complex p = new Complex(int.Parse(t[0]), int.Parse(t[1]));
                    sum = sum + p;
                }
                //new variables to save the attributes
                int z = sum.x;
                int l = sum.y;
                //devide to gcd(z,l) to get an abbreviated complex number
                Console.WriteLine(z / gcd(z, l) + "/" + l / gcd(z, l));
                Console.ReadKey();

            }
        }
    }
}
