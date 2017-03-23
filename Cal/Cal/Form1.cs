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
        int ccal = 0;
        double value = 0;
        bool dtwo = false;
        Double memory_num = 0;
        string mem = "";
        Double memory = 0;
        Double memory_sum = 0;
        Double memory_sub = 0;
        string special_op = "";
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
                    cal = 1;
                  }
               else if(calculator.operation == Calculator.Operation.SUB)
               {
                calculator.saveFirstNumber(displa.Text);
                displa.Text = btn.Text;
                cal = 2;
               }
                else if(calculator.operation == Calculator.Operation.MUL)
            {
                calculator.saveFirstNumber(displa.Text);
                displa.Text = btn.Text;
                cal = 3;
            }
                else if(calculator.operation == Calculator.Operation.DIV)
            {
                calculator.saveFirstNumber(displa.Text);
                displa.Text = btn.Text;
                cal = 4;
            }
                else if (calculator.operation == Calculator.Operation.PRO)
            {
                calculator.saveFirstNumber(displa.Text);
                displa.Text = btn.Text;
                cal = 5;
            }
                else if(calculator.operation == Calculator.Operation.C)
            {
                calculator.saveFirstNumber(displa.Text);
                displa.Text = btn.Text;
                
                cal = 6;
            }
            
            calculator.operation = Calculator.Operation.NUMBER;
            }

            private void button26_Click(object sender, EventArgs e)
            {

            if (ccal == 0)
            {
                calculator.saveSecondNumber(displa.Text);
            }

            else
            {
                calculator.saveFirstNumber(displa.Text);
            }

            if (cal == 1)
            {
                displa.Text = calculator.getResultPlus().ToString();
                ccal++;
                calculator.firstNumber = calculator.getResultPlus();
                
            }
            if (cal == 2)
            {
                displa.Text = calculator.getResultSub().ToString();
                ccal++;
                calculator.firstNumber = calculator.getResultSub();
            }
             if (cal == 3)
            {
                displa.Text = calculator.getResultMul().ToString();
                ccal++;
                calculator.firstNumber = calculator.getResultMul();
            }
            if (cal == 4)
            {
                displa.Text = calculator.getResultDiv().ToString();
                ccal++;
                calculator.firstNumber = calculator.getResultDiv();
            }
         if(cal == 5)
            {
                displa.Text = calculator.getResultPro().ToString();
                ccal++;
                calculator.firstNumber = calculator.getResultDiv();
            }   
         if(cal == 6)
            {
                //displa.Clear();
                //displa.Text = "0";
                //calculator.secondNumber = 0;
                ccal = 0;
                
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

        private void button29_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.SQRT;
            calculator.saveFirstNumber(displa.Text);
            displa.Text = calculator.getResultSqrt().ToString();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.C;
          
        }

        private void button30_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.PRO;
        }

        private void button34_Click(object sender, EventArgs e)
        {
           
            displa.Text = (double.Parse(displa.Text)*(-1)).ToString() ;
        }
        private void dot(object sender, EventArgs e)
        {
            if (!displa.Text.Contains(","))
            {
                displa.Text += ",";
            }
            else return;
        }
        private void back_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(displa.Text))
            {
                displa.Text = displa.Text.Substring(0, displa.Text.Length - 1);
            }
            else
                displa.Text = "0";
        }
        private void button35_Click(object sender, EventArgs e)//кнопка СЕ
        {
            displa.Text = "0";
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
                    displa.Text = (memory).ToString();
                    break;
                case "M+":
                    memory_sum = Double.Parse(displa.Text);
                    displa.Text = (Double.Parse(displa.Text) + memory_sum).ToString();
                    break;
                case "M-":
                    memory_sub = Double.Parse(displa.Text);
                    displa.Text = (Double.Parse(displa.Text) - memory_sub).ToString();
                    break;
                case "MR":
                    displa.Text = displa.Text;
                    break;
                case "MC":
                    displa.Text = " ";
                    break;
                default:
                    break;
            }
        }

      
        }
    }


