
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cal
{
    public class Calculator
    {
        public enum Operation
        {
            NONE,
            NUMBER,
            PLUS,
            EQUAL,
            DIV,
            MUL,
            SUB,
            SQRT,
            PRO,
            C,
            CE
        };  
        public Operation operation;
        public double firstNumber, secondNumber;
        string y;

        public Calculator()
        {
            operation = Operation.NONE;
            firstNumber = 0;
            secondNumber = 0;
        }
        public void saveFirstNumber(string s)
        {
            firstNumber = double.Parse(s);
        }

        public void saveSecondNumber(string s)
        {
            secondNumber = double.Parse(s);
        }
        public double getResultPlus()
        {
            return firstNumber + secondNumber;
        }
        public double getResultSub()
        {
            return firstNumber - secondNumber;
        }
        public double getResultMul()
        {
            return firstNumber * secondNumber;
        }
        public double getResultDiv()
        {
            return firstNumber / secondNumber;
        }
        public double getResultSqrt(string s)
        {
            double n = double.Parse(s);
            return Math.Sqrt(n);
        }
        public string Del(string s)
        {
            string text = "";
            char[] c = s.ToCharArray();
            for (int i = 0; i < s.Length - 1; i++)
            {
                text = text + c[i];
            }
            return text;
        }
        public double getResultPow(string s)
        {
            double n = double.Parse(s);
            return Math.Pow(n, 2);
        }
        public double Plus(string a)
        {
            firstNumber = Double.Parse(a);
            return firstNumber * 2;
        }
       
    }
}
