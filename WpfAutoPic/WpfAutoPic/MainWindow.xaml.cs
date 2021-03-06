﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfAutoPic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AutoContext autoContext;
        public MainWindow()
        {
            InitializeComponent();
            //byte[] kepdata = File.ReadAllBytes(@"g:/toyota.jpg");
            //autoContext = new AutoContext();
            //Auto auto = new Auto {
            //    Rendszam="ABC-001",
            //    Gyartmany="Toyota",
            //    Tipus="Corolla",
            //    GyartasiEv=2006,
            //    AutoKepData=kepdata
            //};
            //autoContext.autok.Add(auto);

            //autoContext.SaveChanges();

            autoContext = new AutoContext();
            autoContext.autok.Load();
            datagridAutok.MouseDoubleClick += gridAdatmodositas;
            foreach (var i in autoContext.autok.Local)
            {
                i.SetImage();
            }
           
            DataContext = autoContext;
        }

        private void buttonUjAdat_Click(object sender, RoutedEventArgs e)
        {
            DataWin dataWin = new DataWin(this);
            dataWin.ShowDialog();
        }

        private void buttonNyomtat_Click(object sender, RoutedEventArgs e)
        {
            ReportWin reportWin = new ReportWin(this);
            reportWin.Show();
        }

        private void gridAdatmodositas(object sender,RoutedEventArgs e)
        {
            var auto = (Auto)datagridAutok.SelectedItem;
            DataWin modWin = new DataWin(this, auto);
            modWin.ShowDialog();
        }
    }
}
