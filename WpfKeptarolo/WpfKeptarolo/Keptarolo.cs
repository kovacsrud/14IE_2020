using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfKeptarolo
{
    public class Keptarolo:StackPanel
    {
        BitmapImage bitmap;
        Image kep;
        TextBlock fajlinfo;

        public Keptarolo(string fajl)
        {
            bitmap = new BitmapImage(new Uri(fajl));
            kep = new Image();
            kep.Source = bitmap;
            fajlinfo = new TextBlock();
            fajlinfo.Text = fajl;
            fajlinfo.TextAlignment = TextAlignment.Center;
            fajlinfo.FontSize = 16;
            fajlinfo.TextWrapping = TextWrapping.Wrap;
            this.Children.Add(kep);
            this.Children.Add(fajlinfo);
        }

    }
}
