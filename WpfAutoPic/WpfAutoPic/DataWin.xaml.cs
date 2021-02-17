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
        bool IsModify;
        Auto auto;
        public DataWin(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            IsModify = false;
        }

        public DataWin(MainWindow mainWindow,Auto auto)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.auto = auto;
            IsModify = true;
            textboxRendszam.Text = auto.Rendszam;
            textboxGyartmany.Text = auto.Gyartmany;
            textboxTipus.Text = auto.Tipus;
            textboxGyartasiEv.Text = auto.GyartasiEv.ToString();
            kepadatok = auto.AutoKepData;
            imageAutokep.Source = auto.Autokep;

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

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (IsModify)
            {
                //Todo:Módosítás
                auto.Rendszam = textboxRendszam.Text;
                auto.Gyartmany = textboxGyartmany.Text;
                auto.Tipus = textboxTipus.Text;
                auto.GyartasiEv = Convert.ToInt32(textboxGyartasiEv.Text);
                auto.AutoKepData = kepadatok;
                auto.SetImage();
                mainWindow.autoContext.SaveChanges();
                mainWindow.datagridAutok.Items.Refresh();

            } else
            {
                Auto auto = new Auto
                {
                    Rendszam = textboxRendszam.Text,
                    Gyartmany = textboxGyartmany.Text,
                    Tipus = textboxTipus.Text,
                    GyartasiEv = Convert.ToInt32(textboxGyartasiEv.Text),
                    AutoKepData = kepadatok

                };
                auto.SetImage();

                mainWindow.autoContext.autok.Add(auto);

                mainWindow.autoContext.SaveChanges();
            }

           


        }
    }
}
