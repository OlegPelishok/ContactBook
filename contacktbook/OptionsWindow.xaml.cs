using System;
using System.Collections.Generic;
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
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
        }

        private void Button_Backup_Click(object sender, RoutedEventArgs e)
        {
            BackupClass backup = new BackupClass();
            backup.createBackup();

        }

        private void Button_Restore_Click(object sender, RoutedEventArgs e)
        {
            BackupClass backup = new BackupClass();
            backup.restoreDatabase();

        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            TheSecondWindow secondWindow = new TheSecondWindow();
            secondWindow.Show();
            this.Close();
        }
    }
}
