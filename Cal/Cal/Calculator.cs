
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
            X
        };
        public Operation operation;
        public double firstNumber, secondNumber;

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
        public double getResultSqrt()
        {
            return Math.Sqrt(firstNumber);
        }
        public double getResultPro()
        {
            return firstNumber * (secondNumber / 100);
        }
        public double getResultC()
        {

            return 0;
        }
    }
}