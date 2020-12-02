﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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

namespace WpfAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JObject jsonIp;
        String apiKey = "57e7f2daa88da7119dc6c575f1232c0f";
        string weatherApiKey = "cee47ae14c4e2b23dd70220929479c28";
        JObject jsonWeather;

        public MainWindow()
        {
            InitializeComponent();
                       
        }

        public TextBlock DataTextBlock(string data,int fontmeret)
        {
            TextBlock datatext = new TextBlock();
            datatext.Text = data;
            datatext.FontSize = fontmeret;

            return datatext;
        }

        public void GetIpData(string ipAddress)
        {
            jsonIp = JObject.Parse(new WebClient().DownloadString($"http://api.ipstack.com/{ipAddress}?access_key={apiKey}"));
        }

        public void GetWeatherData(string city)
        {
            jsonWeather = JObject.Parse(new WebClient().DownloadString($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={weatherApiKey}&units=metric&lang=hu"));
        }



        public BitmapImage KepFromUrl(string url)
        {
            WebClient kepclient = new WebClient();
            byte[] adatok = kepclient.DownloadData(url);
            MemoryStream ms = new MemoryStream(adatok);
            BitmapImage netkep = new BitmapImage();
            netkep.BeginInit();
            netkep.StreamSource = ms;
            netkep.EndInit();

            return netkep;
        }

        private void buttonIp_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                GetIpData(textboxIp.Text);
                GetWeatherData((string)jsonIp["city"]);
                //Debug.WriteLine(jsonIp);
                Debug.WriteLine(jsonWeather);
                stackAdatok.Children.Clear();
                stackAdatok.Children.Add(DataTextBlock((string)jsonIp["continent_name"], 20));
                stackAdatok.Children.Add(DataTextBlock((string)jsonIp["country_name"], 20));
                stackAdatok.Children.Add(DataTextBlock((string)jsonIp["city"], 30));
                stackAdatok.Children.Add(DataTextBlock((string)jsonIp["location"]["capital"], 20));
                stackAdatok.Children.Add(DataTextBlock((string)jsonWeather["main"]["temp"],24));
                stackAdatok.Children.Add(DataTextBlock((string)jsonWeather["dt"], 20));
                stackAdatok.Children.Add(DataTextBlock((string)jsonWeather["weather"][0]["main"], 20));
                stackAdatok.Children.Add(DataTextBlock((string)jsonWeather["weather"][0]["description"], 20));
                netKep.Source = KepFromUrl("https://taszi.hu/kepek/kepkezelo/large/2828.jpg");
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                MessageBox.Show("Hibás IP!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
