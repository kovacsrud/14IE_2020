﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAutoPic
{
    public class AutoContext:DbContext
    {
        public DbSet<Auto> autok { get; set; }
    }
}
