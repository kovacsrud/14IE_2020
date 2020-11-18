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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfIdojarasBongeszo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IdojarasAdatok idojarasadatok;
        public MainWindow()
        {
            InitializeComponent();
            idojarasadatok = new IdojarasAdatok("idojaras.csv");
            listboxEvek.ItemsSource = idojarasadatok.GetEvek();
            listboxEvek.SelectionChanged += KivalasztEv;
            listboxHonapok.SelectionChanged += KivalasztHonap;
        }

        private void KivalasztEv(object sender,RoutedEventArgs e)
        {
            var ev = Convert.ToInt32(listboxEvek.SelectedItem);
            gridAdatok.ItemsSource = idojarasadatok.GetGridAdatok(ev);
            listboxHonapok.ItemsSource = idojarasadatok.GetHonapok(ev);
        }

        private void KivalasztHonap(object sender,RoutedEventArgs e)
        {
            var ev = Convert.ToInt32(listboxEvek.SelectedItem);
            var honap = Convert.ToInt32(listboxHonapok.SelectedItem);
            gridAdatok.ItemsSource = idojarasadatok.GetGridAdatok(ev, honap);
        }
    }
}
