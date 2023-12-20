using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using fussball.Models;

namespace fussball.Data
{
    public class fussballContext : DbContext
    {
        public fussballContext (DbContextOptions<fussballContext> options)
            : base(options)
        {
        }

        public DbSet<fussball.Models.Spiller> Spiller { get; set; } = default!;

        public DbSet<fussball.Models.Kamp> Kamp { get; set; } = default!;
    }
}
