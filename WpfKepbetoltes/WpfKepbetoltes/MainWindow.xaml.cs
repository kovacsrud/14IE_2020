﻿using Microsoft.Win32;
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

namespace WpfKepbetoltes
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

        private void buttonBetolt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "képek (*.jpg;*.jpeg;*.gif)|*.jpg;*.jpeg;*.gif|minden fájl (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.Multiselect = true;
                
                if (dialog.ShowDialog() == true)
                {
                    var files = dialog.FileNames;
                    for (int i = 0; i < files.Length; i++)
                    {
                        Image kep = new Image();
                        BitmapImage bitmap = new BitmapImage(new Uri(files[i]));
                        kep.Source = bitmap;
                        panelKepek.Children.Add(kep);
                    }
                  
                }
            }
            catch(NotSupportedException ex)
            {
                MessageBox.Show("Nem támogatott formátum!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
