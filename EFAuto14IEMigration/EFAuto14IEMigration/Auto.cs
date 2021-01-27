using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAuto14IEMigration
{
    [Table("auto")]
    public class Auto
    {
        [Key]
        public string Rendszam { get; set; }
        [Required]
        public string Gyartmany { get; set; }
        [Required]
        public string Tipus { get; set; }
        [Required]
        public int GyartasiEv { get; set; }
        [Required]
        public string Alvazszam { get; set; }

        public int TulajId { get; set; }
        public Tulaj Tulaj { get; set; }

    }
}
