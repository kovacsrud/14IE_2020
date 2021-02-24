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

namespace WpfMediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaList mediaList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            mediaList = new MediaList();
            mediaPlayer.LoadedBehavior = MediaState.Manual;
            listBoxPlaylist.SelectionChanged += playListChange;
            listBoxPlaylist.DataContext = mediaList;
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog()==true)
            {
                mediaList.SetMediaList(dialog.FileNames, '\\');

                
            }

        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void playListChange(object sender,RoutedEventArgs e)
        {
            MediaItem actItem = (MediaItem)listBoxPlaylist.SelectedItem;
            mediaPlayer.Source = new Uri(actItem.FullPath);
        }

        private void buttonPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void mediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                Debug.WriteLine(mediaPlayer.NaturalDuration.TimeSpan);

                mediaSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;


            }
        }

        private void mediaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan ts = new TimeSpan(0, 0, (int)mediaSlider.Value);
            mediaPlayer.Position = ts;
        }
    }
}
