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
    /// Interaction logic for WinModKutyafajta.xaml
    /// </summary>
    public partial class WinModKutyafajta : Window
    {
        MainWindow mainwindow;
        int id;
        public WinModKutyafajta()
        {
            InitializeComponent();
        }

        public WinModKutyafajta(MainWindow atvettablak,int id,string nev,string eredetinev)
        {
            InitializeComponent();
            mainwindow = atvettablak;
            textboxModnev.Text = nev;
            textboxModEredetinev.Text = eredetinev;
            this.id = id;
        }

        private void buttonModKutyafajta_Click(object sender, RoutedEventArgs e)
        {
            var muvelet = MessageBox.Show("Biztosan módosítja?","Módosítás",MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (muvelet==MessageBoxResult.Yes)
            {
                mainwindow.kutyafajtak.ModositKutyafajta(id, textboxModnev.Text, textboxModEredetinev.Text);
            }
            else
            {
                MessageBox.Show("Módosítás visszavonva", "Módosítás", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
