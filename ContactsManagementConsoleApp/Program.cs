using ContactsManagementConsoleApp.Data;
using System;
using System.Linq;

namespace ContactsManagementConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get all contacts
            ContactsDbContext db = new ContactsDbContext();
            var contacts = db.Contacts.ToList();

            foreach (var item in contacts)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
