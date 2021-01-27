﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfEF_Kutyak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KutyaModel kutyamodel;
        public MainWindow()
        {
            InitializeComponent();
            kutyamodel = new KutyaModel();
            kutyamodel.kutya.Load();
            kutyamodel.kutyafajtak.Load();
            kutyamodel.kutyanevek.Load();
            DataContext = kutyamodel;
            //datagridKutya.ItemsSource = kutyamodel.kutya.Local;

        }

        private void buttonKutyanevUpdate_Click(object sender, RoutedEventArgs e)
        {
            DbUpdate();
        }

        private void DbUpdate()
        {
            var allapot = kutyamodel.SaveChanges();
            if (allapot > 0)
            {
                MessageBox.Show("Művelet sikeres");
            }
            else
            {
                MessageBox.Show("Művelet sikertelen");
            }
        }

        private void buttonKutyafajtaUpdate_Click(object sender, RoutedEventArgs e)
        {
            DbUpdate();
        }

        private void buttonKutyaUpdate_Click(object sender, RoutedEventArgs e)
        {
            DbUpdate();
        }

        private void buttonKeres_Click(object sender, RoutedEventArgs e)
        {
            dataGridKereses.Items.Clear();

            IEnumerable<kutya> eredmeny = new List<kutya>();

            if (textboxNevkeres.Text.Length > 0)
            {
                eredmeny = kutyamodel.kutya.Local.Where(x => x.kutyanevek.Kutyanev==textboxNevkeres.Text);

            } else if (textboxFajtakeres.Text.Length > 0)
            {
                eredmeny = kutyamodel.kutya.Local.Where(x => x.kutyafajtak.nev==textboxFajtakeres.Text);
            } else if (textboxFajtakeres.Text.Length > 0 && textboxNevkeres.Text.Length > 0)
            {
                eredmeny = kutyamodel.kutya.Local.Where(x => x.kutyafajtak.nev == textboxFajtakeres.Text && x.kutyanevek.Kutyanev == textboxNevkeres.Text);
            } else 
            {
                MessageBox.Show("Valamelyik mezőt ki kell tölteni");
            }

            if (eredmeny.Count()>0)
            {
                foreach (var i in eredmeny)
                {
                    dataGridKereses.Items.Add(i);
                }
            } else
            {
                MessageBox.Show("Nincs találat");
            }
            

            

        }
    }
}
