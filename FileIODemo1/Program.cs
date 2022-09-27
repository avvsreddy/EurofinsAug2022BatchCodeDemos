using System;
using System.IO;

namespace FileIODemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("e:\\sample.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                System.Console.WriteLine(line);
            }
            sr.Close();

        }

        private static void ReadAll()
        {
            StreamReader sr = new StreamReader("e:\\sample.txt");
            try
            {
                string allData = sr.ReadToEnd();
                System.Console.WriteLine(allData);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }
        }

        private static void Write()
        {
            string data = "some other extra data";
            // write into file
            StreamWriter sw = new StreamWriter("e:\\sample.txt", true);
            sw.WriteLine(data);
            sw.Close();
        }
    }
}
