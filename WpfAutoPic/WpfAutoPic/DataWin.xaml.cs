using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfAutoPic
{
    /// <summary>
    /// Interaction logic for DataWin.xaml
    /// </summary>
    public partial class DataWin : Window
    {
        MainWindow mainWindow;
        byte[] kepadatok;
        public DataWin(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void buttonKepvalaszto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            if (dialog.ShowDialog()==true)
            {
                kepadatok = File.ReadAllBytes(dialog.FileName);
                imageAutokep.Source = new BitmapImage(new Uri(dialog.FileName));
            }

        }
    }
}
