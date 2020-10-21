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

namespace WpfDinLabels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Cimkek(150);
        }

        public void Cimkek(int darab)
        {
            for (int i = 0; i < darab; i++)
            {
                Label label = new Label();
                label.Content = i + 1;
                label.Margin = new Thickness(3);
                label.MouseDown += CimkeKatt;
                
                gyujto.Children.Add(label);
            }
        }

        private void CimkeKatt(object sender,RoutedEventArgs e)
        {
            Label label = (Label)sender;
            label.Foreground = Brushes.Red;
            label.Background = Brushes.Green;
        }


        private void buttonTorol_Click(object sender, RoutedEventArgs e)
        {
            gyujto.Children.Clear();
        }
    }
}
