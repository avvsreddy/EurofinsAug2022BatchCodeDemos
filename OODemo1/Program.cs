using System;
using System.Linq;

namespace OODemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyApp app = new MyApp(new SuperDuperCalculator());
            //int[] numbers = { 1, 2, 3, 4, 5 };
            //Console.WriteLine(app.Sum(numbers));
            Console.WriteLine(app.Sum(234, 34, 345, 456, 56, 768, 567, 35, 234));
        }
    }

    interface ICalculator
    {
        int Sum(params int[] numbers);
    }

    class Calculator : ICalculator
    {
        public int Sum(params int[] numbers)
        {
            int sum = 0;
            foreach (var item in numbers)
            {
                sum += item;
            }
            Console.WriteLine("Using Calculator");
            return sum;
        }
    }
    class SuperCalculator : ICalculator
    {
        public int Sum(params int[] numbers)
        {
            Console.WriteLine("Using Super Calculator");
            return numbers.Sum();
        }
    }

    class SuperDuperCalculator : ICalculator
    {
        public int Sum(params int[] numbers)
        {
            Console.WriteLine("Using Super Duper Calculator");
            return numbers.Sum();
        }
    }
    class MyApp : ICalculator
    {
        ICalculator c = null;
        public MyApp(ICalculator c)
        {
            this.c = c;
        }
        public int Sum(params int[] numbers)
        {
            //Calculator c = new Calculator();
            return c.Sum(numbers);
        }
    }
}
