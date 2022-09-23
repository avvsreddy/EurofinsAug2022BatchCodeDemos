using ExceptionsDemoConsoleApp1.BusinessLayer;
using System;

namespace ExceptionsDemoConsoleApp1
{
    internal class Program // UI
    {
        static void Main(string[] args) // SRP
        {
            // accept two ints and find sum continuesly

            int fno, sno, sum;
            //StreamWriter sw = null;

            while (true)
            {
                try
                {
                    Console.Write("Enter first number: ");
                    fno = int.Parse(Console.ReadLine());
                    Console.Write("Enter Second number: ");
                    sno = int.Parse(Console.ReadLine());

                    //sw = new StreamWriter("e:/abc.txt");

                    //sw.WriteLine("test");

                    //sum = fno + sno; // BL

                    Calculator calc = new Calculator();
                    sum = calc.Sum(fno, sno);

                    Console.WriteLine($"The sum of {fno} and {sno} is {sum}");


                    //sw.Close();
                }

                //catch (ZeroInputException ex)
                //{
                //    Console.WriteLine("Enter non-zero values only");
                //}
                //catch (FormatException ex)
                //{
                //    Console.WriteLine("Enter only numbers");
                //}
                catch (OverflowException ex)
                {
                    Console.WriteLine("Enter small int numbers only");
                }
                catch (Exception ex) //Catch all block
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //sw.Close();
                }
            }

        }
    }
}
