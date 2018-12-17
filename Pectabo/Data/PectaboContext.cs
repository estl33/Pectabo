using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pectabo.Models
{
    public class PectaboContext : DbContext
    {
        public PectaboContext (DbContextOptions<PectaboContext> options)
            : base(options)
        {
        }

        public DbSet<Pectabo.Models.Pectab> Pectab { get; set; }
    }
}
