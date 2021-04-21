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
                    comboboxKategoria.ItemsSource = gameData.GetKategoria();
                    tabPlatform.IsEnabled = true;
                    tabKereses.IsEnabled = true;
                    tabStatisztika.IsEnabled = true;
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
            datagridKereses.ItemsSource = null;
            datagridKereses.Items.Clear();
            var eredmeny = gameData.Games.FindAll(x=>x.Name.ToLower().Replace(" ","").Contains(jatekNev.ToLower().Replace(" ","")));

            if (eredmeny.Count==0)
            {
                MessageBox.Show("Nincs a feltételnek megfelelő adat!");
            } else
            {
                datagridKereses.ItemsSource = eredmeny;
            }
            
        }

        private void comboboxKategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = comboboxKategoria.SelectedValue.ToString();
            var eredmeny = gameData.Games.FindAll(x=>x.Genre==selected);
            datagridKategoria.ItemsSource = eredmeny;
            var minEredmeny = eredmeny.Min(x=>x.Global_sales);
            textblockMin.Text = $"{minEredmeny} millió";
            datagridMin.ItemsSource = eredmeny.FindAll(x=>x.Global_sales==minEredmeny);
            var maxEredmeny = eredmeny.Max(x => x.Global_sales);
            textblockMax.Text = $"{maxEredmeny} millió";
            datagridMax.ItemsSource = eredmeny.FindAll(x => x.Global_sales == maxEredmeny);
            var avgEredmeny = eredmeny.Average(x => x.Global_sales);
            textblockAvg.Text = $"{avgEredmeny:0.00} millió";
            var sumEredmeny = eredmeny.Sum(x => x.Global_sales);
            textblockSum.Text = $"{sumEredmeny:0.00} millió";
        }
    }
}
