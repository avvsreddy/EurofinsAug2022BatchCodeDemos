using ContactsManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ContactsManagementApp.Data
{
    public class ContactsDbRepository : IContactsRepository
    {


        private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            return conn;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sqlDelete = "delete from contacts where contactid=@id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlDelete;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(int id, Contact modifiedContact)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sqlUpdate = "update contacts set name=@name,mobile=@mobile,email=@email,location=@loc where contactid=@id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlUpdate;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", modifiedContact.Name);
                cmd.Parameters.AddWithValue("@mobile", modifiedContact.Mobile);
                cmd.Parameters.AddWithValue("@email", modifiedContact.Email);
                cmd.Parameters.AddWithValue("@loc", modifiedContact.Location);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Contact GetContactById(int id)
        {
            Contact c = new Contact();
            using (SqlConnection conn = GetConnection())
            {
                string sqlSelect = "select * from contacts where contactid=@id";
                SqlCommand cmd = new SqlCommand(sqlSelect, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    c.ContactID = (int)reader[0];
                    c.Name = reader[1].ToString();
                    c.Location = reader["location"].ToString();
                    c.Email = reader.GetString(3);
                    c.Mobile = reader.GetString(2);
                }
            }
            return c;
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
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
                // Step 2: prepare sql insert cmd and send
                // SQL Injection

                // name = venkat--;delete contacts
                //string sqlInsert = $"insert into contacts values ('{contact.Name}','{contact.Mobile}','{contact.Email}','{contact.Location}')";

                string sqlInsert = "insert into contacts values (@name,@mobile,@email,@loc)";

                SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                cmd.Parameters.AddWithValue("@name", contact.Name);

                SqlParameter p2 = new SqlParameter();
                p2.ParameterName = "@mobile";
                p2.Value = contact.Mobile;
                cmd.Parameters.Add(p2);

                cmd.Parameters.AddWithValue("@email", contact.Email);
                cmd.Parameters.AddWithValue("@loc", contact.Location);

                conn.Open();
                cmd.ExecuteNonQuery();

                // Step 3: close
            }
            //conn.Close();
        }
    }
}
