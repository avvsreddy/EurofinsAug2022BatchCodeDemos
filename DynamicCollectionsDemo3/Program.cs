using System.Collections;
using System.Collections.Generic;

namespace DynamicCollectionsDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>(100);
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);
            numbers.TrimExcess();

            ArrayList list = new ArrayList();
            list.Add(234234);

            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Peek();
            stack.Pop();

            Queue<int> q = new Queue<int>();
            q.Enqueue(10);
            q.Peek();
            q.Dequeue();

            Dictionary<int, string> results = new Dictionary<int, string>();
            results.Add(111, "pass");
            results.Add(222, "fail");

            string result = results[111];



            System.Console.WriteLine($"Capacity : {numbers.Capacity}");



        }
    }
}
