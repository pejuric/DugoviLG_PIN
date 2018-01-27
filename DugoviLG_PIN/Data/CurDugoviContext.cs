using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DugoviLG_PIN.Models
{
    public class CurDugoviContext : DbContext
    {
        public CurDugoviContext (DbContextOptions<CurDugoviContext> options)
            : base(options)
        {
        }

        public DbSet<DugoviLG_PIN.Models.CurDugovi> CurDugovi { get; set; }
    }
}
