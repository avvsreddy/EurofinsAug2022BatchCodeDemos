using System;

namespace DelegatesDemo1
{

    //class MyDelegate : MulticastDelegate
    //{

    //}

    // Step 1: delegates declaration
    delegate void MyDelegate(string str);



    internal class Program
    {
        static void Main(string[] args)
        {
            // direct
            //Program.Greeting("Hello");
            // indirect
            // Step 2: Instantiate and initialize
            Program p = new Program();
            MyDelegate delObj = new MyDelegate(p.Hello);

            delObj += Greeting; // subscribing
            delObj -= p.Hello; // unsubscribing

            // Step 3: Delegate Invoking/Calling
            //delObj.Invoke("Hello");
            delObj("Ramesh");
        }

        public static void Greeting(string msg)
        {
            Console.WriteLine($"Greeting: {msg}");
        }

        public void Hello(string name)
        {
            Console.WriteLine($"Hello: {name}");
        }
    }
}
