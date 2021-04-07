using Microsoft.Win32;
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

namespace MintaVizsga2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AutoLista autolista;
        public MainWindow()
        {
            InitializeComponent();
            //Vészhelyzeti megoldás
            //autolista = new AutoLista("valami.txt",';',1);
        }

        private void buttonBetolt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            
            if (dialog.ShowDialog()==true)
            {
                autolista = new AutoLista(dialog.FileName,';',1);

                Debug.WriteLine(autolista.Autok.Count);
                tabKereses.IsEnabled = true;
                tabUjadat.IsEnabled = true;
            }
        }

        private void buttonKereses_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var also = Convert.ToInt32(textboxAlso.Text);
                var felso = Convert.ToInt32(textboxFelso.Text);

                var eredmeny = autolista.Autok.FindAll(x=>x.Ar>=also && x.Ar<=felso);
                if (eredmeny.Count<1)
                {
                    throw new ArgumentException("Nincs a feltételeknek megfelelő elem!");
                }

                datagridEredmeny.ItemsSource = eredmeny;

            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            
        }

        private void buttonUjadat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = autolista.Autok.Max(x=>x.Id)+1;
                var marka = textboxMarka.Text;
                var tipus = textboxTipus.Text;
                var evjarat = Convert.ToInt32(textboxEvjarat.Text);
                var uzem = textboxUzem.Text;
                var hengerurtartalom = Convert.ToInt32(textboxHengerurtartalom.Text);
                var teljesitmeny = Convert.ToInt32(textboxTeljesitmeny.Text);
                var futottkm = Convert.ToInt32(textboxFutottKm.Text);
                var ar = Convert.ToInt32(textboxAr.Text);

                Auto ujauto = new Auto(id,marka,tipus,evjarat,uzem,hengerurtartalom,teljesitmeny,futottkm,ar);
                autolista.UjAuto(ujauto);
                //házi feladat ->fájlba írás megvalósítása

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
