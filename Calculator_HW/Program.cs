
using System.Collections;
using System.ComponentModel;

namespace Calculator_HW
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.Result += Calculator_Result;

            calculator.Start();
        }
        private static void Calculator_Result(object? sender, CalculatorEventArgs e)
        {
            Console.WriteLine($"Текущее значение: {e.answer}");
            Console.WriteLine();
        }
    }
}
