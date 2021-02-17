using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMediaPlayer
{
    public class MediaItem
    {
        public String FullPath { get; set; }
        public String Filename { get; set; }

        public MediaItem(string fullpath,char separator)
        {
            FullPath = fullpath;
            var e = fullpath.Split(separator);
            Filename = e[e.Length - 1];
            //Filename = e.Last();
        }
    }
}
