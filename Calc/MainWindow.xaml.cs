using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        string number1;
        string number2;
        string operation;
        public MainWindow()
        {
            InitializeComponent();
        }

        private double tryParse(string str)
        {
            CultureInfo polish = new CultureInfo("pl-PL");
            double number = double.Parse(str, polish);
            return number;
        }


        private string isTooBig(double value)
        {
            if (Math.Abs(value) > Double.MaxValue)
                return "error";
            return value.ToString();
        }


        private void number_click(object sender, RoutedEventArgs e)
        {
            if (this.display.Text == "error" || this.display.Text == "0")
                this.display.Clear();
            var number = sender as Button;
            if (this.display.Text.Length < 15)
                this.display.Text += number.Content;
        }


        private void operation_click(object sender, RoutedEventArgs e)
        {
            if (this.display.Text == "error")
                this.display.Text = "0";
            number1 = this.display.Text;
            var operand = sender as Button;
            operation = operand.Content.ToString();
            
            this.display.Text = "0";
        }

        private void equ_click(object sender, RoutedEventArgs e)
        {
            if (this.display.Text == "error")
                this.display.Text = "0";
            else
            {
                double num1 = tryParse(number1);
                number2 = this.display.Text;
                double num2 = tryParse(number2);
                double result = 0;
                string text = "";
                switch (operation)
                {
                    case "+":
                        result = Math.Round(num1 + num2, 14);
                        text = isTooBig(result);
                        break;
                    case "-":
                        result = Math.Round(num1 - num2, 14);
                        text = isTooBig(result);
                        break;
                    case "*":
                        result = Math.Round(num1 * num2, 14);
                        text = isTooBig(result);
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            result = Math.Round(num1 / num2, 14);
                            text = isTooBig(result);
                        }
                        else
                            text = "error";
                        break;
                }
                this.display.Text = text;
            }
        }



        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            if (this.display.Text != "0")
                if(this.display.Text[0].ToString() == "-")
                    this.display.Text = this.display.Text.Remove(0, 1);
                else
                    this.display.Text = "-" + this.display.Text;
        }



        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            this.display.Text = "0";
        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (this.display.Text.Length == 2 && this.display.Text[0] == '-' || this.display.Text.Length == 1 || this.display.Text.Length == 3 && this.display.Text[0] == '0' || this.display.Text == "error")
                this.display.Text = "0";
            else
                this.display.Text = this.display.Text.Remove(this.display.Text.Length - 1, 1);
        }


        private void btnSqu_Click(object sender, RoutedEventArgs e)
        {
            number1 = this.display.Text;
            double num1 = tryParse(number1);
            double result = 0;
            string text = "";
            result = Math.Round(num1 * num1, 14);
            text = isTooBig(result);
            this.display.Text = text;
        }

        private void btn1dx_Click(object sender, RoutedEventArgs e)
        {
            number1 = this.display.Text;
            double num1 = tryParse(number1);
            double result = 0;
            string text = "";
            if (num1 != 0)
            {
                result = Math.Round(1 / num1, 14);
                text = isTooBig(result);
            }
            else
                text = "error";
            this.display.Text = text;
        }

        private void btnCom_Click(object sender, RoutedEventArgs e)
        {
            if (!this.display.Text.Contains(","))
                this.display.Text = this.display.Text + ",";
        }
    }
}
