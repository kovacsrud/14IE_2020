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

namespace WpfSzamolas
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

        private void buttonSzamol_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = Convert.ToInt32(textboxA.Text);
                var b = Convert.ToInt32(textboxB.Text);
                var c = a * b;
                labelEredmeny.Content = c;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Számot kell megadni!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
