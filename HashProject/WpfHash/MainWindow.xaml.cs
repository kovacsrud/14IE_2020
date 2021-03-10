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
using HashCreator;

namespace WpfHash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HashCreate hash;
        public MainWindow()
        {
            InitializeComponent();
            hash = new HashCreate();
        }

        private void buttonHash_Click(object sender, RoutedEventArgs e)
        {
            if (radioMd5.IsChecked==true)
            {
                textblockSzovegHash.Text = hash.CreateHash(HashType.MD5, textboxSzoveg.Text);
            }
            else if (radioSha1.IsChecked==true)
            {
                textblockSzovegHash.Text = hash.CreateHash(HashType.SHA1, textboxSzoveg.Text);
            }
            else if (radioSha256.IsChecked==true)
            {
                textblockSzovegHash.Text = hash.CreateHash(HashType.SHA256, textboxSzoveg.Text);
            }
            else if (radioSha384.IsChecked==true)
            {
                textblockSzovegHash.Text = hash.CreateHash(HashType.SHA384, textboxSzoveg.Text);
            } else
            {
                textblockSzovegHash.Text = hash.CreateHash(HashType.SHA512, textboxSzoveg.Text);
            }
        }
    }
}
