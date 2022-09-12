
using System;

namespace MyFirstConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int fno, sno, max;
            Console.Write("Enter first number: ");
            fno = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            sno = int.Parse(Console.ReadLine());

            if (fno > sno)
                max = fno;
            else
                max = sno;

            Console.WriteLine($"The max of {fno} and {sno} is {max}");

        }
    }
}
