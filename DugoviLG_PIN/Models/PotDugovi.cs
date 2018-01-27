using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DugoviLG_PIN.Models
{
    public class PotDugovi
    {
        public int ID { get; [Authorize]set; }
        public string Ime { get; [Authorize]set; }
        public string Prezime { get; [Authorize]set; }
        public string KontaktBroj { get; [Authorize]set; }
    }
}
