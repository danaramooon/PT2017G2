using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cal
{
        public partial class Form1 : Form
        {
            public static Calculator calculator;
            public Form1()
            {
                InitializeComponent();
                calculator = new Calculator();
            }
        int cal = 0; // counter to save numbers
        int mop = 0;// counter to save second number after op
        double op = 0; 
        int equals = 0;
        bool dtwo = false;//to insert two or more numbers
        Double memory_num = 0;
        string mem = "";
        string operations = "";
        Double memory = 0;
        private void number_click(object sender, EventArgs e)
            {
                Button btn = sender as Button;
                if (calculator.operation == Calculator.Operation.NONE ||
                    calculator.operation == Calculator.Operation.NUMBER)
                {
                if ((displa.Text == "0") | (dtwo == true))
                    displa.Clear();
               
                dtwo = false;
                displa.Text += btn.Text;
               }
                else if (calculator.operation == Calculator.Operation.PLUS)
                {
                mop++;
                if (mop > 1)
                {
                    calculator.saveSecondNumber(displa.Text);
                    displa.Text = (calculator.getResultPlus()).ToString();
                }
                calculator.saveFirstNumber(displa.Text);
                displa.Text = btn.Text;
                operations = "+";
                equals = 0;
                  }
               else if(calculator.operation == Calculator.Operation.SUB)
               {
                mop++;
                if (mop > 1)
                {
                    calculator.saveSecondNumber(displa.Text);
                    displa.Text = (calculator.getResultSub()).ToString();
                }
                calculator.saveFirstNumber(displa.Text);
                displa.Text = btn.Text;
                operations = "-";
                equals = 0;
            }
                else if(calculator.operation == Calculator.Operation.MUL)
            {
                mop++;
                if (mop > 1)
                {
                    calculator.saveSecondNumber(displa.Text);
                    displa.Text = (calculator.getResultMul()).ToString();
                }
                calculator.saveFirstNumber(displa.Text);
                equals = 0;
                displa.Text = btn.Text;
                operations = "*";
            }
                else if(calculator.operation == Calculator.Operation.DIV)
            {
                mop++;
                if (mop > 1)
                {
                    calculator.saveSecondNumber(displa.Text);
                    displa.Text = (calculator.getResultDiv()).ToString();
                }
                equals = 0;
                calculator.saveFirstNumber(displa.Text);
                displa.Text = btn.Text;
                operations = "/";
            }
            calculator.operation = Calculator.Operation.NUMBER;
            }
        private void button26_Click(object sender, EventArgs e)
        {
            if (cal == 0)
                calculator.saveSecondNumber(displa.Text);
            else
            calculator.saveFirstNumber(displa.Text);
            mop = 0;
            cal++;
            equals++;
            if (equals == 1)
            {
                op = calculator.secondNumber;
            }
            if (equals > 1)
            {
                switch (operations)
                {
                    case "+":
                        displa.Text = (calculator.firstNumber + op).ToString();
                        break;
                    case "-":
                        displa.Text = (calculator.firstNumber - op).ToString();
                        break;
                    case "*":
                        displa.Text = (calculator.firstNumber * op).ToString();
                        break;
                    case "/":
                       if (calculator.secondNumber == 0)
                       {
                            displa.Text = "ERROR";
                       }
                       else
                        {
                            displa.Text = (calculator.firstNumber / op).ToString();
                        }
                        break;
                }
            }
            else
            {
                switch (operations)
                {
                    case "+":
                        displa.Text = calculator.getResultPlus().ToString();
                        break;
                    case "-":
                        displa.Text = calculator.getResultSub().ToString();
                        break;
                    case "*":
                        displa.Text = calculator.getResultMul().ToString();
                       break;
                    case "/":
                        if (calculator.secondNumber == 0)
                        {
                            displa.Text = "ERROR";
                        }
                        else
                        {
                            displa.Text = calculator.getResultDiv().ToString();
                        }
                        break;
                }
            }
            calculator.firstNumber = double.Parse(displa.Text);
            cal = 0;
        }
        private void button23_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.PLUS;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.DIV;
        }
        private void button28_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.MUL;
        }
        private void button25_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.SUB;
        }
        private void operation_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch(btn.Text)
            {
                case "x*2":
                    displa.Text = (calculator.getResultPow(displa.Text)).ToString();
                    break;
                case "%":
                    displa.Text = (calculator.firstNumber * (Double.Parse(displa.Text) / 100)).ToString();
                    break;
                case "1/x":
                    calculator.firstNumber = Double.Parse(displa.Text);
                    if (calculator.firstNumber != 0)
                        displa.Text = (1 / calculator.firstNumber).ToString();
                    else
                        displa.Text = "ERROR";
                    break;
                case "√":
                    displa.Text = (calculator.getResultSqrt(displa.Text)).ToString();
                    break;
                case "±":
                    displa.Text = (double.Parse(displa.Text) * (-1)).ToString();
                    break;
                case ",":
                    {
                        if (!displa.Text.Contains(","))
                        {
                            displa.Text += ",";
                        }
                        else return;
                        break;
                   }
              }
        }
        private void Del_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch(btn.Text)
            {
                case "Del":
                    if (displa.Text != " ")
                    {
                        // displa.Text = displa.Text.Substring(0, displa.Text.Length - 1);
                        displa.Text = calculator.Del(displa.Text);
                    }
                    else
                        displa.Text = "0";
                    break;
                case "CE":
                    displa.Clear();
                    cal = 0;
                    break;
                case "C":
                    displa.Text = "0";
                    cal = 0;
                    break;
            }
        }
        private void memory_op(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            mem = btn.Text;
            memory = Double.Parse(displa.Text);
            switch (mem)
            {
                case "MS":
                    memory_num = memory;
                    displa.Text = "0";
                    button38.Enabled = true;
                    button39.Enabled = true;
                    break;
                case "M+":
                    memory_num = (memory_num + Double.Parse(displa.Text));
                    button38.Enabled = true;
                    button39.Enabled = true;
                    break;
                case "M-":
                    memory_num = (memory_num - Double.Parse(displa.Text));
                    button38.Enabled = true;
                    button39.Enabled = true;
                    break;
                case "MR":
                    displa.Text = memory_num.ToString();
                    button38.Enabled = true;
                    button39.Enabled = true;
                    break;
                case "MC":
                    memory_num = 0;
                    displa.Text = memory_num.ToString();
                    button38.Enabled = false;
                    button39.Enabled = false;
                    break;
            }
        }
     }
 }


