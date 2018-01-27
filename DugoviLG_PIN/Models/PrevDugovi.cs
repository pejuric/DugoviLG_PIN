using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DugoviLG_PIN.Models
{
    public class PrevDugovi
    {
        public int ID { get; [Authorize]set; }
        public string Ime { get; [Authorize]set; }
        public string Prezime { get; [Authorize]set; }
        public double PosuđenNovac_Kn { get; [Authorize]set; }
        public double Vraćen_Novac_Kn { get; [Authorize]set; }

    }
}
