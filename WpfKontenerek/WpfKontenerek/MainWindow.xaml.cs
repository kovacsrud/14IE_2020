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

namespace WpfKontenerek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Gombok(150);
        }

        public void Gombok(int db)
        {
            for (int i = 0; i < db; i++)
            {
                Button gomb = new Button();
                gomb.Content = i+1;
                gomb.Click += AktButton;
                elemek.Children.Add(gomb);
            }
        }

        public void AktButton(object sender,RoutedEventArgs e)
        {
            Button gomb = (Button)sender;
            labelKiir.Content = gomb.Content;
            elemek.Children.Remove(gomb);
        }

    }
}
