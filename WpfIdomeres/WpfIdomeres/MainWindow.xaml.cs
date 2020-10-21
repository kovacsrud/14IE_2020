using System;
using System.Collections.Generic;
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

namespace WpfIdomeres
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopper;

        public MainWindow()
        {
            InitializeComponent();
            stopper = new Stopwatch();
            buttonStartStop.Content = "Start";
           
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
                stopper.Start();
                buttonStartStop.Content = "Stop";
            }
        }
    }
}
