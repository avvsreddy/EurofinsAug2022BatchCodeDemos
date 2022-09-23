using System;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            M1();
            M1();
            WriteLine("end of application");
        }

        public static void M1()
        {
            BigClass b1 = new BigClass();
            Program p1 = new Program();
            using (p1)
            {
                Console.WriteLine("end of m1");
                Console.WriteLine("b1 goes out of scope");
            }
            //BigClass b2 = new BigClass();
        }
    }

    class BigClass : IDisposable
    {
        private List<int> numbers = null;
        public BigClass()
        {
            Console.WriteLine("ctor called");
            numbers = new List<int>(100000);
        }
        ~BigClass()
        {

            Console.WriteLine("dtor called");
        }

        public void Dispose()
        {
            Console.WriteLine("BigClass Disposed");
            GC.SuppressFinalize(this);
        }
    }
}
