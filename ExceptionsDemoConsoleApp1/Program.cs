using System;

namespace ExceptionsDemoConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // accept two ints and find sum continuesly

            int fno, sno, sum;

            while (true)
            {
                try
                {
                    Console.Write("Enter first number: ");
                    fno = int.Parse(Console.ReadLine());
                    Console.Write("Enter Second number: ");
                    sno = int.Parse(Console.ReadLine());

                    sum = fno + sno;
                    Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
                }

                catch (FormatException ex)
                {
                    Console.WriteLine("Enter only numbers");
                }
                //catch (OverflowException ex)
                //{
                //    Console.WriteLine("Enter small int numbers only");
                //}
                catch (Exception ex) //Catch all block
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
