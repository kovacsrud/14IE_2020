using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSqliteProba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public KutyafajtaSQL kutyafajtak;
        public MainWindow()
        {
            InitializeComponent();
            kutyafajtak = new KutyafajtaSQL("Data source=g:/kutyak14ie.db;Version=3");
            //kutyaFajtak.ItemsSource = kutyafajtak.Kutyafajtak;
            kutyaFajtak.MouseDoubleClick += GridDblClick;
            kutyaFajtak.MouseRightButtonDown += GridRightClick;
            
            kutyaFajtak.ItemsSource = kutyafajtak.KutyafajtakDT.DefaultView;
            
        }

        private void buttonUjKutyafajta_Click(object sender, RoutedEventArgs e)
        {
            WinUjKutyafajta winujkutyafajta = new WinUjKutyafajta(this);
            winujkutyafajta.ShowDialog();
        }

        private void GridDblClick(object sender,RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)kutyaFajtak.SelectedItem;
            Debug.WriteLine(row["id"]);
            Debug.WriteLine(row["nev"]);
            Debug.WriteLine(row["eredetinev"]);
            WinModKutyafajta winmodkutyafajta = new WinModKutyafajta(
                this,
                Convert.ToInt32(row["id"]),
                row["nev"].ToString(),
                row["eredetinev"].ToString()
                );
            winmodkutyafajta.ShowDialog();

        }

        private void GridRightClick(object sender,RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)kutyaFajtak.SelectedItem;
            WinTorolKutyafajta wintorolkutyafajta = new WinTorolKutyafajta(
                this,
                Convert.ToInt32(row["id"]),
                row["nev"].ToString(),
                row["eredetinev"].ToString()
                );
            wintorolkutyafajta.ShowDialog();
        }

    }
}
