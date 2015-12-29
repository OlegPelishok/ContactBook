using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace contacktbook
{
    /// <summary>
    /// Class for working with DB
    /// </summary>
    public class DataBase
    {
        private const string connString = "Data Source=ContactsDataBase.sqlite;Version=3;";
        
        public void createNewDatabase()
        {
            if (!(File.Exists("ContactsDataBase.sqlite")))
            {
                SQLiteConnection.CreateFile("ContactsDataBase.sqlite");

                using (var connection = new SQLiteConnection(connString))
                {
                    connection.Open();
                    string createContactTableQuery = @"CREATE TABLE contacts (ID INTEGER PRIMARY KEY, 
                                                       first_name VARCHAR(20), second_name VARCHAR(20),
                                                       tel1 VARCHAR(20), tel2 VARCHAR(20), email VARCHAR(30))";
                    SQLiteCommand createTable = new SQLiteCommand(createContactTableQuery, connection);
                    createTable.ExecuteNonQuery();
                }
            }
        }

        public void updateContact(Contact contact)
        {
            using( var connection = new SQLiteConnection(connString))
            {
                connection.Open();
                string updateContactTableQuery = String.Format(@"INSERT INTO contacts 
                                                              (first_name, second_name, tel1, tel2, email) VALUES
                                                              ('{0}', '{1}', '{2}', '{3}', '{4}')", 
                                                              contact.FirstName, contact.SecondName, 
                                                              contact.Tel1, contact.Tel2, contact.Email);
                SQLiteCommand updateCommand = new SQLiteCommand(updateContactTableQuery, connection);
                updateCommand.ExecuteNonQuery();
            }
        }

        public void deleteContact(Contact contact)
        {
            using (var connection = new SQLiteConnection(connString))
            {
                connection.Open();
                string deleteContactTableQuery = String.Format("DELETE FROM contacts WHERE first_name = '{0}' AND second_name = '{1}'", contact.FirstName, contact.SecondName);
                SQLiteCommand deleteCommand = new SQLiteCommand(deleteContactTableQuery, connection);
                deleteCommand.ExecuteNonQuery();
            }
        }
        public SQLiteDataReader selectContact()
        {
            var connection = new SQLiteConnection(connString);
                string selectContactsQuery = "SELECT * FROM contacts";
                connection.Open();
                SQLiteCommand selectAllContacts = new SQLiteCommand(selectContactsQuery, connection);
               var allContactsTableReader =  selectAllContacts.ExecuteReader();
               return allContactsTableReader;
            

        }


    }
}


