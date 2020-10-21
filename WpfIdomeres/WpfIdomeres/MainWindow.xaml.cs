using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfIdomeres
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopper;
        Random rand;

        public MainWindow()
        {
            InitializeComponent();
            stopper = new Stopwatch();
            buttonStartStop.Content = "Start";
            rand = new Random();
            labelFelirat.Content = "Katt!";
            labelFelirat.Visibility = Visibility.Hidden;

        }

        private void Reakcio()
        {
            labelFelirat.Visibility = Visibility.Hidden;
            Thread.Sleep(rand.Next(1000, 5000));
            labelFelirat.Visibility = Visibility.Visible;
            stopper.Start();
           
        }

        private void buttonStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (stopper.IsRunning)
            {
                stopper.Stop();
                labelElteltIdo.Content = stopper.ElapsedMilliseconds;
                stopper.Reset();
                buttonStartStop.Content = "Start";
            } else
            {
                //stopper.Start();
                Reakcio();
               
                buttonStartStop.Content = "Stop";
            }
        }
    }
}
