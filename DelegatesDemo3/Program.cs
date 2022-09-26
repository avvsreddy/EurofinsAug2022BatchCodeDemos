using System.Diagnostics;

namespace DelegatesDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // client 1 - show all process
            //ProcessManager.ShowProcessList();
            ProcessManager.ShowProcessList(FilterByNone);

            // client 2 - show all process with starting char S
            //ProcessManager.ShowProcessList("S");
            //FilterDelegate filter = new FilterDelegate(FilterByName);
            //ProcessManager.ShowProcessList(filter);

            // client 3 - show all big process (50MB)
            //ProcessManager.ShowProcessList(500 * 1024 * 1024);
            //ProcessManager.ShowProcessList(FilterBySize);


        }

        // client 1 - no filter

        static bool FilterByNone(Process p)
        {
            return true;
        }



        // client 2 filter  - get by name

        static bool FilterByName(Process p)
        {
            if (p.ProcessName.StartsWith("S"))
                return true;
            else
                return false;

        }

        // client 3 - filter by size
        static bool FilterBySize(Process p)
        {
            return p.WorkingSet64 >= 500 * 1024 * 1024;
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
