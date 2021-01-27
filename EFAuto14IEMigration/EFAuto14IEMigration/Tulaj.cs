using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAuto14IEMigration
{
    [Table("tulaj")]
    public class Tulaj
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TulajId { get; set; }
        [Required]
        public string Nev { get; set; }
        public string Telefon { get; set; }

        public List<Auto> Autok { get; set; }

    }
}
