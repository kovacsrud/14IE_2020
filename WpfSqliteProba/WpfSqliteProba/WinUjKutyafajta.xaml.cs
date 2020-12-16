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

namespace WpfSqliteProba
{
    /// <summary>
    /// Interaction logic for WinUjKutyafajta.xaml
    /// </summary>
    public partial class WinUjKutyafajta : Window
    {
        MainWindow mainwindow;
        public WinUjKutyafajta()
        {
            InitializeComponent();
        }

        //Dependency injection
        public WinUjKutyafajta(MainWindow atvettablak)
        {
            InitializeComponent();
            mainwindow = atvettablak;
        }

        private void buttonUjKutyafajta_Click(object sender, RoutedEventArgs e)
        {
            var muvelet = MessageBox.Show("Biztosan rögzíti?","Új adat felvitele",MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (muvelet==MessageBoxResult.Yes && textboxUjnev.Text.Length>3 && textboxUjEredetinev.Text.Length>3)
            {
                mainwindow.kutyafajtak.UjKutyafajta(textboxUjnev.Text,textboxUjEredetinev.Text);
                textboxUjnev.Text = "";
                textboxUjEredetinev.Text = "";
            } else
            {
                MessageBox.Show("Adatfelvitel megszakítva", "Új adat felvitele", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
