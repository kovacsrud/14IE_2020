using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMediaPlayer
{
    public class MediaList
    {
        public ObservableCollection<MediaItem> mediaItems { get; set; }

        public MediaList()
        {
            mediaItems = new ObservableCollection<MediaItem>();
        }

        public void SetMediaList(string[] files,char separator)
        {
            foreach (var i in files)
            {
               mediaItems.Add(new MediaItem(i, separator));
            }
        }

    }
}
