using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfAutoPic
{
    [Table("auto")]
    public class Auto
    {
        [Key]
        public String Rendszam { get; set; }
        [Required]
        public String Gyartmany { get; set; }
        [Required]
        public String Tipus { get; set; }
        [Required]
        public int GyartasiEv { get; set; }

        public byte[] AutoKepData { get; set; }

        [NotMapped]
        private BitmapImage autokep;

        [NotMapped]
        public BitmapImage Autokep {
            get { return autokep; }
        }

        public void SetImage()
        {
            autokep = new BitmapImage();
            MemoryStream ms = new MemoryStream(AutoKepData);
            autokep.BeginInit();
            autokep.StreamSource = ms;
            autokep.EndInit();
        }
    }
}
