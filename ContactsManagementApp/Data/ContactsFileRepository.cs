using ContactsManagementApp.Entities;
using System;
using System.Collections.Generic;

namespace ContactsManagementApp.Data
{
    public class ContactsFileRepository : IContactsRepository
    {
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
            throw new NotImplementedException();
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public void Save(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
