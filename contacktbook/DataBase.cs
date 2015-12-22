using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace contacktbook
{
    class DataBase:MainWindow
    {
        public SQLiteConnection conn = new SQLiteConnection("Data Source=ContactsDataBase.sqlite;Version=3;");
        public string CreateTableContacts = "create table Contacts (Id varchar(20), FirstName varchar(20), SecondName varchar(20), Tel1 varchar(20), Tel2 varchar(20), Email varchar(20))";
        private string UpdateContactsTable = "insert into Contacts (Id, FirstName, SecondName, Tel1, Tel2, Email) values ('{0}','{1}','{2}','{3}','{4}','{5}')";
        
        public void createNewDatabase()
        {
            SQLiteConnection.CreateFile("ContactsDataBase.sqlite");
        }

        public void CreateTable()
        {
            conn.Open();
            SQLiteCommand command = new SQLiteCommand(CreateTableContacts, conn);
            command.ExecuteNonQuery();
            conn.Clone();
        }

        public void UpdateContacts()
        {
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(string.Format(UpdateContactsTable, ID.Text, FirstName.Text, SecondName.Text, Tel1.Text, Tel2.Text, Email.Text), conn);
            cmd.ExecuteNonQuery();
            conn.Clone();
        }
    }
}


