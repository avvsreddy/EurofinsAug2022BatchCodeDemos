using System;
using System.IO;

namespace FileIODemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {


        }

        private static void GetAllFiles()
        {
            // get all files in a folder

            string[] files = Directory.GetFiles("E://code");
            foreach (var f in files)
            {
                Console.WriteLine(f);
            }
        }

        private static void GetAllDrives()
        {
            // get all drives in the system
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine(drive.Name + "\t" + drive.TotalSize + "/" + drive.TotalFreeSpace);
            }
        }
    }
}
