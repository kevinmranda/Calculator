using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double operandOne;
        private double operandTwo;
        private double results;
        private string currentOperation;
        private bool isNewOperation = true;


        private void button35_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                string buttonText = btn.Text;

                if (char.IsDigit(buttonText[0]) || buttonText == ".")
                {
                    if (isNewOperation)
                    {
                        display.Text = buttonText;
                        isNewOperation = false;
                    }
                    else
                    {
                        display.Text += buttonText;
                    }
                }
                else
                {
                    if (double.TryParse(display.Text, out double number))
                    {
                        operandOne = number;
                        currentOperation = buttonText;
                        lblOperation.Text = operandOne + " " + currentOperation;
                        isNewOperation = true;
                    }
                }
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            if (double.TryParse(display.Text, out double number))
            {
                operandTwo = number;
                PerformOperation();
                lblOperation.Text += " " + operandTwo + " = ";
                display.Text = results.ToString();
                isNewOperation = true;
            }
        }

        private void PerformOperation()
        {
            switch (currentOperation)
            {
                case "+":
                    results = operandOne + operandTwo;
                    break;
                case "-":
                    results = operandOne - operandTwo;
                    break;
                case "x":
                    results = operandOne * operandTwo;
                    break;
                case "/":
                    if (operandTwo != 0)
                    {
                        results = Math.Round(operandOne / operandTwo, 4);
                    }
                    else
                    {
                        // Handle division by zero case
                        results = 0; // or any other value indicating an error
                        MessageBox.Show("Cannot divide by Zero!");
                    }
                    break;
                default:
                    // Handle unexpected currentOperation values
                    throw new InvalidOperationException("Invalid operation");
            }
        }

    }
}
