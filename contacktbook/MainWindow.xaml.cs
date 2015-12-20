using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;


namespace contacktbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            TheSecondWindow secondWindow = new TheSecondWindow();
            secondWindow.Show();
            this.Hide();
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

        private void AddObject_Click(object sender, RoutedEventArgs e)
        {
            
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