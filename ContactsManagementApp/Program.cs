using ContactsManagementApp.Data;
using ContactsManagementApp.Entities;

namespace ContactsManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contact c = new Contact { Name = "Sachin", Email = "sachin@bcci.org", Mobile = "234234234", Location = "Mumbai" };

            IContactsRepository repo = new ContactsDbRepository();
            repo.Save(c);
            System.Console.WriteLine("contact saved");

        }
    }
}
