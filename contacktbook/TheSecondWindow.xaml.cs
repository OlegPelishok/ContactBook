using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace contacktbook
{
    /// <summary>
    /// Interaction logic for TheSecondWindow.xaml
    /// </summary>
    public partial class TheSecondWindow : Window
    {
        public class DataObject
        {
            public string O { get; set; }
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
            public string D { get; set; }
            public string E { get; set; }

        }

        public TheSecondWindow()
        {
            InitializeComponent();

            var list = new ObservableCollection<DataObject>();
            DataBase db = new DataBase();
            SQLiteDataReader reader =  db.selectContact();
            while (reader.Read())
            {
                list.Add(new DataObject() {O = reader["ID"].ToString(), A = "" + reader["first_name"], B = ""+ reader["second_name"], C = ""+reader["tel1"], D = ""+ reader["tel2"], E = ""+ reader["email"]});
                this.dataGrid1.ItemsSource = list;
            }

         }

        private void btnSwitchToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Options_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow secondWindow = new OptionsWindow();
            secondWindow.Show();
            this.Close();

        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
