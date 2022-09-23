using System;

namespace CalculatorConsoleApp
{
    internal class Program // UI
    {
        static void Main(string[] args) // UI
        {
            Console.Write("Enter First Number: ");
            int fno = int.Parse(Console.ReadLine());
            Console.Write("Enter Second Number: ");
            int sno = int.Parse(Console.ReadLine());

            Calculator p = new Calculator();
            int sum = p.Sum(fno, sno);

            Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
        }

    }

    class Calculator // BL
    {
        public int Sum(int a, int b) // BL
        {
            return a + b;
        }
    }
}
