using ContactsManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace ContactsManagementApp.Data
{
    public class ContactsFileRepository : IContactsRepository
    {

        private readonly string file = "d:\\contactslist2022.txt";
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, Contact modifiedContact)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetContacts()
        {
            StreamReader sr = new StreamReader(file);
            List<Contact> contacts = new List<Contact>();
            try
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Contact c = new Contact();
                    string[] data = line.Split(',');
                    c.ContactID = int.Parse(data[0]);
                    c.Name = data[1];
                    c.Mobile = data[2];
                    c.Email = data[3];
                    c.Location = data[4];
                    contacts.Add(c);
                }
            }
            finally { sr.Close(); }
            return contacts;
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public void Save(Contact contact)
        {
            string contactCSV = $"{contact.ContactID},{contact.Name},{contact.Mobile},{contact.Email},{contact.Location}";
            StreamWriter sw = new StreamWriter(file, true);
            try
            {
                sw.WriteLine(contactCSV);
            }
            finally { sw.Close(); }


        }
    }
}
