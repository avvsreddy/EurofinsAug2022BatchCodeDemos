using System;
using System.Collections.Generic;

namespace DynamicCollectionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // want to store n number of ints and display
            // want to store n number of doubles and display

            //object[] data = new object[10];
            //data[0] = 10;
            //data[1] = "ten";

            //int a = (int)data[0];


            DynamicArray<int> array = new DynamicArray<int>();

            List<int> lists = new List<int>();
            lists.Add(100);



            array.Add(100);

            DynamicArray<string> stringArray = new DynamicArray<string>();
            stringArray.Add("sdfsdfsd");


            DynamicDoubleArray dnumbers = new DynamicDoubleArray();
            dnumbers.Add(10.5);
            dnumbers.Add(34.6);

            double d = dnumbers.Get(1);


            DynamicIntArray numbers = new DynamicIntArray(100);
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(10);
            numbers.Add(200);

            // read all
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers.Get(i));
            }


        }

        class DynamicIntArray
        {

            private int[] numbers;// = new int[size];
            private int index = 0;

            public DynamicIntArray()
            {
                numbers = new int[5];
            }
            public DynamicIntArray(int size)
            {
                numbers = new int[size];
            }

            public void Add(int n)
            {
                if (index < numbers.Length) //free
                {
                    numbers[index++] = n;
                }
                else //no space
                {
                    //int[] temp = new int[numbers.Length * 2];
                    //for (int i = 0; i < numbers.Length; i++)
                    //{
                    //    temp[i] = numbers[i];
                    //}
                    //Array.Copy(numbers, temp, numbers.Length);

                    Array.Resize(ref numbers, numbers.Length * 2);
                    numbers[index++] = n;
                    //numbers = temp;
                }
            }

            public int Count
            {
                get { return index; }
            }


            public int Get(int i)
            {
                return numbers[i];
            }
        }

        class DynamicDoubleArray
        {

            private double[] numbers;// = new int[size];
            private int index = 0;

            public DynamicDoubleArray()
            {
                numbers = new double[5];
            }
            public DynamicDoubleArray(int size)
            {
                numbers = new double[size];
            }

            public void Add(double n)
            {
                if (index < numbers.Length) //free
                {
                    numbers[index++] = n;
                }
                else //no space
                {
                    //int[] temp = new int[numbers.Length * 2];
                    //for (int i = 0; i < numbers.Length; i++)
                    //{
                    //    temp[i] = numbers[i];
                    //}
                    //Array.Copy(numbers, temp, numbers.Length);

                    Array.Resize(ref numbers, numbers.Length * 2);
                    numbers[index++] = n;
                    //numbers = temp;
                }
            }

            public int Count
            {
                get { return index; }
            }


            public double Get(int i)
            {
                return numbers[i];
            }
        }

        class DynamicArray<idontknow>
        {

            private idontknow[] numbers;// = new int[size];
            private int index = 0;

            public DynamicArray()
            {
                numbers = new idontknow[5];
            }
            public DynamicArray(int size)
            {
                numbers = new idontknow[size];
            }

            public void Add(idontknow n)
            {
                if (index < numbers.Length) //free
                {
                    numbers[index++] = n;
                }
                else //no space
                {
                    //int[] temp = new int[numbers.Length * 2];
                    //for (int i = 0; i < numbers.Length; i++)
                    //{
                    //    temp[i] = numbers[i];
                    //}
                    //Array.Copy(numbers, temp, numbers.Length);

                    Array.Resize(ref numbers, numbers.Length * 2);
                    numbers[index++] = n;
                    //numbers = temp;
                }
            }

            public int Count
            {
                get { return index; }
            }


            public idontknow Get(int i)
            {
                return numbers[i];
            }
        }

    }
}
