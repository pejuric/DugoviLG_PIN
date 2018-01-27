using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DugoviLG_PIN.Models
{
    public class PotDugoviContext : DbContext
    {
        public PotDugoviContext (DbContextOptions<PotDugoviContext> options)
            : base(options)
        {
        }

        public DbSet<DugoviLG_PIN.Models.PotDugovi> PotDugovi { get; set; }
    }
}
