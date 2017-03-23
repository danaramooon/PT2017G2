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


        int cal = 0;
        bool dtwo = false;
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
                calculator.saveFirstNumber(displa.Text);
                displa.Text = btn.Text;
                operations = "+";
                  }
               else if(calculator.operation == Calculator.Operation.SUB)
               {
                calculator.saveFirstNumber(displa.Text);
                displa.Text = btn.Text;
                operations = "-";
            }
                else if(calculator.operation == Calculator.Operation.MUL)
            {
                calculator.saveFirstNumber(displa.Text);
                displa.Text = btn.Text;
                operations = "*";
            }
                else if(calculator.operation == Calculator.Operation.DIV)
            {
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
            switch (operations)
            {
                case "+":
                    displa.Text = calculator.getResultPlus().ToString();
                    calculator.firstNumber = calculator.getResultPlus();
                    dtwo = true;
                    cal++;
                    break;
                case "-":
                    displa.Text = calculator.getResultSub().ToString();
                    calculator.firstNumber = calculator.getResultSub();
                    dtwo = true;
                    cal++;
                    break;
                case "*":
                    displa.Text = calculator.getResultMul().ToString();
                    calculator.firstNumber = calculator.getResultMul();
                    dtwo = true;
                    cal++;
                    break;
                case "/":
                    if (calculator.secondNumber == 0)
                    {
                        displa.Text = "ERROR";
                    }
                    else
                    {
                        displa.Text = calculator.getResultDiv().ToString();
                        calculator.firstNumber = calculator.getResultDiv();
                        cal++;
                        dtwo = true;
                        
                    }
                    break;

            }
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

        private void button29_Click(object sender, EventArgs e)//Sqrt
        {
            calculator.operation = Calculator.Operation.SQRT;
            calculator.saveFirstNumber(displa.Text);
            displa.Text = calculator.getResultSqrt().ToString();
        }

        private void button32_Click(object sender, EventArgs e)//CE
        {
            displa.Clear();
            cal = 0;
        }

        private void button30_Click(object sender, EventArgs e)//pro cent
        { 
            displa.Text = (calculator.firstNumber * (Double.Parse(displa.Text)/ 100)).ToString();

        }

        private void button34_Click(object sender, EventArgs e)//+-
        {
           
            displa.Text = (double.Parse(displa.Text)*(-1)).ToString() ;
        }
        private void dot(object sender, EventArgs e)//,
        {
            if (!displa.Text.Contains(","))
            {
                displa.Text += ",";
            }
            else return;
        }
        private void back_Click(object sender, EventArgs e)//delete
        {
            if (!string.IsNullOrEmpty(displa.Text))
            {
                displa.Text = displa.Text.Substring(0, displa.Text.Length - 1);
            }
            else
                displa.Text = "0";
        }
        private void button35_Click(object sender, EventArgs e)//button С
        {
            displa.Text = "0";
            cal = 0;
           
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
                    displa.Clear();
                    break;
                case "M+":
                    memory_num = (memory_num + Double.Parse(displa.Text));
                    break;
                case "M-":
                    memory_num = (memory_num - Double.Parse(displa.Text));
                    break;
                case "MR":
                    displa.Text = memory_num.ToString();
                    
                   break;
                case "MC":
                   memory_num = 0;
                   displa.Text = "";
                    break;
            }
        }

        private void button37_Click(object sender, EventArgs e)//x*2
        {
            calculator.firstNumber = double.Parse(displa.Text);
            displa.Text = Math.Pow(calculator.firstNumber,2).ToString();
        }

        private void button31_Click(object sender, EventArgs e)//1/x
        {
            calculator.firstNumber = Double.Parse(displa.Text);
            displa.Text = (1 / calculator.firstNumber).ToString();
        }
    }
    }


