using System;

namespace MultilayeredAppDemo
{
    internal class Program // UI
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) // UI - SRP
        {
            // accept two ints and find the sum then display the result
            int fno;
            int sno;
            int sum = 0;
            Console.Write("Enter First Number: ");
            fno = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            sno = int.Parse(Console.ReadLine());

            sum = CalculatorLibrary.Calculator.Sum(fno, sno);

            Console.WriteLine($"The sum of {fno} and {sno} is {sum}");

        }


    }


}
