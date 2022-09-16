using System;
using System.Linq;

namespace CollectionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // store 5 int numbers and find sum
            int size = 10;
            int[] numbers = new int[size];
            int[] values1 = new int[3] { 1, 2, 4 };
            int[] values2 = new int[] { 1, 2, 3, 4, 5 };
            int[] values3 = { 1, 2, 3, 4 };

            // two dimentional
            int[,] twod = new int[3, 5];

            // Jagged Arrays
            // rows
            int[][] scores = new int[3][];
            // columns for each row
            scores[0] = new int[3];
            scores[1] = new int[2];
            scores[2] = new int[5];


            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Enter number {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // find sum
            int sum = numbers.Sum();
            int max = numbers.Max();
            double avg = numbers.Average();
            int min = numbers.Min();
            Array.Sort(numbers);
            Array.Reverse(numbers);
            foreach (var item in numbers)
            {
                sum += item;
            }

            Console.WriteLine($"The sum of all numbers is {sum}");

        }
    }
}
