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
        bool dtwo = false;
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
                if (displa.Text == calculator.getResultPro().ToString())
                {
                    calculator.firstNumber = calculator.getResultPro(); 
                }
                else
                { }
                
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
            displa.Text = "";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.PRO;
            calculator.saveFirstNumber(displa.Text);
            displa.Text = calculator.getResultPro().ToString();
            
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            displa.Text = (double.Parse(displa.Text)*(-1)).ToString() ;
        }



        /*
        private void button1_Click(object sender, EventArgs e)
        {
            display.Text += "1";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            display.Text += "0";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            display.Text += "2";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            display.Text += "3";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            display.Text += "4";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            display.Text += "5";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            display.Text += "6";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            display.Text += "7";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            display.Text += "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            display.Text += "9";
        }
         */
    }


    }

