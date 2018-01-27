using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DugoviLG_PIN.Models
{
    public class CurDugovi
    {

            public int ID { get; [Authorize]set; }
            public string Ime { get; [Authorize]set; }
            public string Prezime { get; [Authorize]set; }
            public double PosuđenNovac_Kn { get; [Authorize]set; }
            public double Tjedne_Kamate { get; [Authorize]set; }
            [Display(Name = "Datum posudbe")]
            [DataType(DataType.Date)]
            public DateTime Datum_Posudbe { get; [Authorize]set; }
            [Display(Name = "Datum vraćanja")]
            [DataType(DataType.Date)]
            public DateTime Rok_Povratka { get; [Authorize]set; }
       
    }
}
