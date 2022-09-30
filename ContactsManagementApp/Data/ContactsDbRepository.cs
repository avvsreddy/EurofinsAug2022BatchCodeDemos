using ContactsManagementApp.Entities;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;

namespace ContactsManagementApp.Data
{
    public class ContactsDbRepository : IContactsRepository
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
            // Step 1: connect to database
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ContactsDbAug2022;Integrated Security=True";
                conn.Open();

                // Step 2: prepare sql insert cmd and send
                string sqlInsert = $"insert into contacts values ('{contact.Name}','{contact.Mobile}','{contact.Email}','{contact.Location}')";
                SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                cmd.ExecuteNonQuery();

                // Step 3: close
            }
            //conn.Close();
        }
    }
}
