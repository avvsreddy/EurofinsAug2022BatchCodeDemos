using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DelegatesDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // client 1 - show all process
            //ProcessManager.ShowProcessList();
            ProcessManager.ShowProcessList(p => true);

            // client 2 - show all process with starting char S
            //ProcessManager.ShowProcessList("S");
            FilterDelegate filter = new FilterDelegate(FilterByName);
            ProcessManager.ShowProcessList(filter);

            // client 3 - show all big process (50MB)
            //ProcessManager.ShowProcessList(500 * 1024 * 1024);
            ProcessManager.ShowProcessList(FilterBySize);


            // Anonymous Delegates
            ProcessManager.ShowProcessList(delegate (Process p)
                {
                    return p.WorkingSet64 >= 500 * 1024 * 1024;
                });

            // Lambda - Statement
            ProcessManager.ShowProcessList((Process p) =>
            {
                return p.WorkingSet64 >= 500 * 1024 * 1024;
            });

            // Lambda Expression - Light Weight Syntax for Anonymous Delegates
            ProcessManager.ShowProcessList((Process p) =>

                p.WorkingSet64 >= 500 * 1024 * 1024
            );

            // Lambda Expression - Light Weight Syntax for Anonymous Delegates
            ProcessManager.ShowProcessList(x => x.WorkingSet64 >= 500 * 1024 * 1024);

            List<int> numbers = new List<int>() { 123, 23, 24, 53, 42, 5, 56, 352, 536 };
            var sum = numbers.Sum();


            Func<int, bool> numberFilter = new Func<int, bool>(IsEven);
            var evenSum = numbers.Where(numberFilter).Sum();
            var evenSum2 = numbers.Where((x) => true).Sum();



        }


        static bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        // client 3 - filter by size
        static bool FilterBySize(Process p)
        {
            return p.WorkingSet64 >= 500 * 1024 * 1024;
        }
        // client 1 - no filter

        //static bool FilterByNone(Process p)
        //{
        //    return true;
        //}



        // client 2 filter  - get by name

        static bool FilterByName(Process p)
        {
            if (p.ProcessName.StartsWith("S"))
                return true;
            else
                return false;

        }


    }

    // delcare the delegate

    public delegate bool FilterDelegate(Process p);

    class ProcessManager
    {
        public static void ShowProcessList(FilterDelegate filter)
        {
            foreach (var p in Process.GetProcesses())
            {
                if (filter(p))
                    System.Console.WriteLine(p.ProcessName);
            }
        }
    }
}
