using Microsoft.Win32;
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
using System.Windows.Threading;

namespace WpfSlideshow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openDialog;
        DispatcherTimer timer;
        int szamlalo;
        string[] fajlok;

        public MainWindow()
        {
            InitializeComponent();
            szamlalo = 0;
            timer = new DispatcherTimer(TimeSpan.FromMilliseconds(1000),DispatcherPriority.Normal,Kepvalto,Dispatcher.CurrentDispatcher);
            timer.Stop();
            buttonStartStop.IsEnabled = false;
            
        }

        private void Kepvalto(object sender, EventArgs e)
        {
            kep.Source = new BitmapImage(new Uri(fajlok[szamlalo]));
            szamlalo++;
            
            if (szamlalo>=fajlok.Length)
            {
                szamlalo = 0;
            }
        }

        private void buttonBetolt_Click(object sender, RoutedEventArgs e)
        {
            openDialog = new OpenFileDialog();
            openDialog.Multiselect = true;
            if (openDialog.ShowDialog()==true)
            {
                fajlok = openDialog.FileNames;
                timer.Start();
                buttonStartStop.Content = "Stop";
                buttonStartStop.IsEnabled = true;
            }
        }

        private void buttonStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                buttonStartStop.Content = "Start";
            } else
            {
                timer.Start();
                buttonStartStop.Content = "Stop";
            }
        }
    }
}
