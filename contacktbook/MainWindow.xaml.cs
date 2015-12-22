using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using System.Data.SQLite;


namespace contacktbook
{

    public partial class MainWindow : Window
    {
        DataBase db = new DataBase();
        
        public MainWindow()
        {
            InitializeComponent();
            DataBase db = new DataBase();
            db.createNewDatabase();
            
           // db.createNewDatabase();
          //  db.CreateTable();
        }


        private void Parse_Click(object sender, RoutedEventArgs e)
        {

            Contact contact = new Contact("1", "Sokhan", "Oleg", "0671111111", "6916", "oleg.sokhan@rosan-it.com");
            Contact contact1 = new Contact("2", "Taras", "Roman", "0671111111", "6915","taras.roman@rosan-it.com");
            Contact [] AllContacts = new Contact [] {contact,contact1};
            XmlSerializer formatter = new XmlSerializer(typeof(Contact[]));
            using (FileStream fs = new FileStream("D:\\contact.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, AllContacts);
            }
        }


        
        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            TheSecondWindow secondWindow = new TheSecondWindow();
            secondWindow.Show();
            this.Hide();
        }

        private void AddObject_Click(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            db.updateContact(new Contact(FirstName.Text, SecondName.Text, Tel1.Text, Tel2.Text, Email.Text));
            //db.UpdateContacts();
        }

    }
}

//private List<Contact> ParseXmlToContactList(string path)
//{
//    List<Contact> resultList;

//    using (var reader = new StreamReader(path))
//    {
//        XmlSerializer deserializer = new XmlSerializer(typeof(List<Contact>), new XmlRootAttribute("Contacts"));
//        resultList = (List<Contact>)deserializer.Deserialize(reader);
//    }
//    return resultList;
//}