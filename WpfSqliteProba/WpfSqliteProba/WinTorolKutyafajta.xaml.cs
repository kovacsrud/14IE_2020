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
    /// Interaction logic for WinTorolKutyafajta.xaml
    /// </summary>
    public partial class WinTorolKutyafajta : Window
    {
        
        MainWindow mainwindow;
        int id;
        public WinTorolKutyafajta()
        {
            InitializeComponent();
        }
        public WinTorolKutyafajta(MainWindow atvettablak,int id,string nev,string eredetinev)
        {
            InitializeComponent();
            mainwindow = atvettablak;
            this.id = id;
            textboxTorolnev.Text = nev;
            textboxTorolEredetinev.Text = eredetinev;
            
        }

        private void buttonTorolKutyafajta_Click(object sender, RoutedEventArgs e)
        {
            var muvelet = MessageBox.Show("Biztosan törli?","Adat törlés",MessageBoxButton.YesNo,MessageBoxImage.Warning);

            if (muvelet==MessageBoxResult.Yes)
            {
                mainwindow.kutyafajtak.TorolKutyafajta(id);
                
            } else
            {
                MessageBox.Show("Törlés visszavonva","Adat törlés",MessageBoxButton.OK,MessageBoxImage.Information);
            }

        }
    }
}
