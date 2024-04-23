using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_HW
{
    class CalculatorEventArgs : EventArgs
    {
        public double answer;
    }
    class Calculator
    {
        public event EventHandler<CalculatorEventArgs> Result;
        private double result = 0;
        Stack<double> results = new Stack<double>();

        public void StartEvent()
        {
            Result?.Invoke(this, new CalculatorEventArgs { answer = result });
        }

        public void Add(double value)
        {
            results.Push(result);
            result += value;
            StartEvent();
        }
        public void Sub(double value)
        {
            results.Push(result);
            result -= value;
            StartEvent();
        }
        public void Mul(double value)
        {
            results.Push(result);
            result *= value;
            StartEvent();
        }
        public void Div(double value)
        {
            results.Push(result);
            result /= value;
            StartEvent();
        }
        public void Cancel()
        {
            if (results.Count > 0)
            {
                result = results.Pop();
                StartEvent();
            }
        }
        public void Start()
        {
            while (true)
            {
                Console.Write("Введите число: ");
                string input = Console.ReadLine();
                double number;

                if (input == "")
                {
                    Console.WriteLine("Завершение.");
                    break;
                }
                else if (!double.TryParse(input, out number))
                {
                    Console.WriteLine($"{input} - Не число!");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Введите оператор: ");
                    string command = Console.ReadLine();
                    command?.ToLower();
                    if (command == "")
                    {
                        Console.WriteLine("Завершение.");
                        break;
                    }
                    else
                    {
                        switch (command)
                        {
                            case "+":
                                this.Add(number);
                                break;
                            case "-":
                                this.Sub(number);
                                break;
                            case "*":
                                this.Mul(number);
                                break;
                            case "/":
                                this.Div(number);
                                break;
                            case "с":
                                this.Cancel();
                                break;
                            default:
                                Console.WriteLine("Неизвестный оператор.");
                                Console.WriteLine();
                                break;
                        }
                    }
                }
            }
        }
    }
}
