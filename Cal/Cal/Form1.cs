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
                displa.Text = "0";
        }
        int ccal = 0; // to insert number after memory_op
        Double memory_num = 0;
        int mop = 0; // press many operations
        string mem = ""; 
        string operations = "";
        string secondop = "";
        Double memory = 0;
        static bool NumberPressed = false;
        bool OpNot = false;
        int EN = 0;
        private void number_click(object sender, EventArgs e)
            {
            Button btn = sender as Button;
            if (calculator.operation == Calculator.Operation.EQUAL)
            {
                if (EN == 0)
                {
                    OpNot = true;
                    NumberPressed = true;
                    calculator.operation = Calculator.Operation.NUMBER;
                    secondop = "";
                    operations = "";
                    mop = 0;
                    calculator.firstNumber = calculator.secondNumber;
                    displa.Text = " ";
                    EN= 1;
                }
                else
                {
                    OpNot = true;
                    NumberPressed = false;
                    calculator.operation = Calculator.Operation.EQUAL;
                    displa.Text = "";
                    displa.Text += btn.Text;
                }
            }

            if (calculator.operation == Calculator.Operation.NONE ||
                    calculator.operation == Calculator.Operation.NUMBER)
                {
                NumberPressed = true;
                if ((displa.Text == "0"))
                    displa.Clear();
                displa.Text += btn.Text;
               }
                else if (calculator.operation == Calculator.Operation.PLUS)
                {
                displa.Text = btn.Text;
                }
               else if(calculator.operation == Calculator.Operation.SUB)
               {
                    displa.Text = btn.Text;
                }
                else if(calculator.operation == Calculator.Operation.MUL)
            {
                displa.Text = btn.Text;
            }
                else if(calculator.operation == Calculator.Operation.DIV)
            {
                displa.Text = btn.Text;
            }
            if (displa.Text.Contains("ER"))
            {
                displa.Clear();
                displa.Text = btn.Text;
            }
            if(button38.Enabled == true | ccal != 0)
            {
                //displa.Clear();
                displa.Text = "0";
                displa.Text = btn.Text;
                ccal = 0;
                button38.Enabled = false;
            }
            if (calculator.operation == Calculator.Operation.C)
            {
                displa.Text = btn.Text;
               
            }
            mop = 1;
            calculator.operation = Calculator.Operation.NUMBER;
            }
        private void button26_Click(object sender, EventArgs e)
        {
            mop = 0;
            {
                if (calculator.operation == Calculator.Operation.NUMBER|calculator.operation == Calculator.Operation.C | calculator.operation == Calculator.Operation.CE|| calculator.operation == Calculator.Operation.PLUS || calculator.operation == Calculator.Operation.MUL || calculator.operation == Calculator.Operation.DIV | calculator.operation == Calculator.Operation.SUB)
                {
                    calculator.saveSecondNumber(displa.Text);
                }
                else if (calculator.operation == Calculator.Operation.EQUAL)
                {
                    if (OpNot == false)
                        calculator.saveFirstNumber(displa.Text);
                    else
                        calculator.saveSecondNumber(displa.Text);
                }
                {
                    switch (secondop)
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
                    if (calculator.secondNumber != 0)
                    calculator.firstNumber = double.Parse(displa.Text);
                calculator.operation = Calculator.Operation.EQUAL;
            }
        }
        private void press_button(object sender, EventArgs e)
        {
            Button b = (Button)sender;
           
            if (mop == 0)
            {
                switch (b.Text)
                {
                    case "+":
                        calculator.operation = Calculator.Operation.PLUS;
                        operations = "+";
                        secondop = "+";
                        break;
                    case "-":
                        calculator.operation = Calculator.Operation.SUB;
                        operations = "-";
                        secondop = "-";
                        break;
                    case "*":
                        calculator.operation = Calculator.Operation.MUL;
                        operations = "*";
                        secondop = "*";
                        break;
                    case "/":
                        calculator.operation = Calculator.Operation.DIV;
                        operations = "/";
                        secondop = "/";
                        break;
                }
            }
           else if(mop == 1)
            {
                switch (b.Text)
                {
                    case "+":
                        calculator.operation = Calculator.Operation.PLUS;
                        secondop = "+";
                        break;
                    case "-":
                        calculator.operation = Calculator.Operation.SUB;
                        secondop = "-";
                        break;
                    case "*":
                        calculator.operation = Calculator.Operation.MUL;
                        secondop = "*";
                        break;
                    case "/":
                        calculator.operation = Calculator.Operation.DIV;
                        secondop = "/";
                        break;
                }
            }
             if(mop == 1)
            {
                switch (secondop)
                {
                    case "+":
                        if (secondop == operations)
                            displa.Text = (calculator.firstNumber + Double.Parse(displa.Text)).ToString();
                        else
                        {
                            if (operations == "-")
                            {
                                displa.Text = (calculator.firstNumber - Double.Parse(displa.Text)).ToString();
                            }
                            if (operations == "*")
                            {
                                displa.Text = (calculator.firstNumber * Double.Parse(displa.Text)).ToString();
                            }
                            if (operations == "/")
                            {
                                if (displa.Text == "0")
                                    displa.Text = "ERROR";
                                else
                                displa.Text = (calculator.firstNumber / Double.Parse(displa.Text)).ToString();
                            }
                        }
                        operations = secondop;
                        break;
                    case "-":
                        if ( secondop== operations)
                            displa.Text = (calculator.firstNumber - Double.Parse(displa.Text)).ToString();
                        else
                        {
                            if(operations == "+")
                            {
                                displa.Text = (calculator.firstNumber + Double.Parse(displa.Text)).ToString();
                            }
                            if (operations == "*")
                            {
                                displa.Text = (calculator.firstNumber * Double.Parse(displa.Text)).ToString();
                            }
                            if (operations == "/")
                            {
                                if (displa.Text == "0")
                                    displa.Text = "ERROR";
                                else
                                    displa.Text = (calculator.firstNumber / Double.Parse(displa.Text)).ToString();
                            }
                        }
                           
                        operations = secondop;
                        break;
                    case "*":
                        if (secondop == operations)
                            displa.Text = (calculator.firstNumber * Double.Parse(displa.Text)).ToString();
                        else
                        {
                            if (operations == "+")
                            {
                                displa.Text = (calculator.firstNumber + Double.Parse(displa.Text)).ToString();
                            }
                            if (operations == "-")
                            {
                                displa.Text = (calculator.firstNumber - Double.Parse(displa.Text)).ToString();
                            }
                            if (operations == "/")
                            {
                                if (displa.Text == "0")
                                    displa.Text = "ERROR";
                                else
                                    displa.Text = (calculator.firstNumber / Double.Parse(displa.Text)).ToString();
                            }
                        }
                        operations = secondop;
                        break;
                    case "/":
                        if (secondop == operations)
                            if (displa.Text == "0")
                                displa.Text = "ERROR";
                            else
                                displa.Text = (calculator.firstNumber / Double.Parse(displa.Text)).ToString();
                        else
                        {
                            if (operations == "+")
                            {
                                displa.Text = (calculator.firstNumber + Double.Parse(displa.Text)).ToString();
                            }
                            if (operations == "-")
                            {
                                displa.Text = (calculator.firstNumber - Double.Parse(displa.Text)).ToString();
                            }
                            if (operations == "*")
                            {
                                displa.Text = (calculator.firstNumber * Double.Parse(displa.Text)).ToString();
                            }
                        }
                        operations = secondop;
                        break;
                }
                mop = 0;
                calculator.saveFirstNumber(displa.Text);
               
            }
  
            calculator.saveFirstNumber(displa.Text);
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
            switch (btn.Text)
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
                    calculator.operation = Calculator.Operation.CE;
                    break;
                case "C":
                    displa.Text = "0";
                    EN = 0;
                    NumberPressed = false;
                    OpNot = false;
                    operations = "";
                    secondop = "";
                    mop = 0;
                    calculator.firstNumber = 0;
                    calculator.secondNumber = 0;
                    calculator.operation = Calculator.Operation.NONE;
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
                    //displa.Text = "0";
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
                    ccal = 1;
                    button38.Enabled = false;
                    button39.Enabled = false;
                    break;
            }
        }
     }
 }


