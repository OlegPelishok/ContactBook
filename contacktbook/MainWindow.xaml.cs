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
     
        public MainWindow()
        {
            InitializeComponent();
            DataBase db = new DataBase();
            db.createNewDatabase();
     
        }

        private void AddObject_Click(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            db.updateContact(new Contact(FirstName.Text, SecondName.Text, Tel1.Text, Tel2.Text, Email.Text));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
           DataBase db = new DataBase();
           db.deleteContact(new Contact(FirstName.Text, SecondName.Text));
   }
        

        
        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            

           TheSecondWindow secondWindow = new TheSecondWindow();
            secondWindow.Show();
            this.Close();
            
        }

      

    }
}
