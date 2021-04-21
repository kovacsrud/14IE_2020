using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfGamesData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameData gameData;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonBetolt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog()==true)
            {
                try
                {
                    gameData = new GameData(dialog.FileName, ';', 1);
                    MessageBox.Show($"Sikeres betöltés, adatsorok száma:{gameData.Games.Count}", "Betöltés", MessageBoxButton.OK, MessageBoxImage.Information);
                    comboPlatform.ItemsSource = gameData.GetPlatformData();
                    tabPlatform.IsEnabled = true;
                    tabKereses.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace,"Hiba!",MessageBoxButton.OK,MessageBoxImage.Error);                    
                }
                
            }
        }

        private void comboPlatform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = comboPlatform.SelectedValue.ToString();
            var selectedData = gameData.Games.FindAll(x=>x.Platform==selected);
            datagridPlatform.ItemsSource = selectedData;
            buttonMentes.IsEnabled = true;
        }

        private void buttonMentes_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog()==true)
            {
                try
                {
                    FileStream fajl = new FileStream(dialog.FileName, FileMode.Create);
                    StreamWriter wr = new StreamWriter(fajl, Encoding.Default);
                    var selected = comboPlatform.SelectedValue.ToString();
                    var selectedData = gameData.Games.FindAll(x => x.Platform == selected);
                    wr.WriteLine("Rank;Name;Platform;Year;Genre;Publisher;NA_Sales;EU_Sales;JP_Sales;Other_Sales;Global_Sales");
                    foreach (var i in selectedData)
                    {
                        wr.WriteLine($"{i.Rank};{i.Name};{i.Platform};{i.Year};{i.Genre};{i.Publisher};{i.NA_sales};{i.EU_sales};{i.JP_sales};{i.Other_sales};{i.Global_sales}");
                    }
                    wr.Close();
                    MessageBox.Show($"Sikeres mentés, adatsorok száma:{selectedData.Count}", "Betöltés", MessageBoxButton.OK, MessageBoxImage.Information);
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        private void buttonKereses_Click(object sender, RoutedEventArgs e)
        {
            var jatekNev = textboxKereses.Text;
            datagridKereses.Items.Clear();
            var eredmeny = gameData.Games.FindAll(x=>x.Name==jatekNev);

            if (eredmeny.Count==0)
            {
                MessageBox.Show("Nincs a feltételnek megfelelő adat!");
            } else
            {
                datagridKereses.ItemsSource = eredmeny;
            }
            
        }
    }
}
