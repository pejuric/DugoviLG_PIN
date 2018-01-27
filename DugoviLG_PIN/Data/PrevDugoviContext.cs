using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DugoviLG_PIN.Models
{
    public class PrevDugoviContext : DbContext
    {
        public PrevDugoviContext (DbContextOptions<PrevDugoviContext> options)
            : base(options)
        {
        }

        public DbSet<DugoviLG_PIN.Models.PrevDugovi> PrevDugovi { get; set; }
    }
}
