using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMediaPlayer
{
    public class MediaList
    {
        public List<MediaItem> mediaItems { get; set; }

        public MediaList()
        {
            mediaItems = new List<MediaItem>();
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
