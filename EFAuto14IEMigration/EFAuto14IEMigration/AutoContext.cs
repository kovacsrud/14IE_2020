using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAuto14IEMigration
{
    public class AutoContext:DbContext
    {
        public DbSet<Auto> Autok { get; set; }
        public DbSet<Tulaj> Tulajok { get; set; }
    }
}
