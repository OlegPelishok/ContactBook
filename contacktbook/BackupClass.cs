using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace contacktbook
{
    public class BackupClass
    {
        public void createBackup()
        {
           DataBase db = new DataBase();
           SQLiteDataReader dataReader = db.selectContact();
           ListOfConacts contactsList = new ListOfConacts();
           contactsList.contactList = new List<Contact>();
    
       while (dataReader.Read())
           {
               Contact cont = new Contact();
               contactsList.contactList.Add(new Contact("" + dataReader["first_name"], "" + dataReader["second_name"], "" + dataReader["tel1"], "" + dataReader["tel2"], "" + dataReader["email"]));

           }

       XmlSerializer formatter = new XmlSerializer(typeof(ListOfConacts));
       using (FileStream fs = new FileStream("database.xml", FileMode.OpenOrCreate))
           {
               formatter.Serialize(fs, contactsList);
           }
          
        }

        private ListOfConacts deserializeContactXML()
        {
            XmlSerializer myDeserializer = new XmlSerializer(typeof(ListOfConacts));
            XmlTextReader reader = new XmlTextReader("database.xml");
            ListOfConacts result = (ListOfConacts)myDeserializer.Deserialize(reader);
            return result;

        }

        public void restoreDatabase()
        {
            DataBase db = new DataBase();
            List<Contact> contacts = deserializeContactXML().contactList;
            foreach (var item in contacts)
            {
                db.updateContact(item);

            }

        }

    }
}
