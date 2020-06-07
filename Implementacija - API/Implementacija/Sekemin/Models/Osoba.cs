using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public  class Osoba:IdentityUser
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Grad { get; set; }
        [Required]
        [Display(Name = "Datum rođenja")]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public Spol Spol { get; set; }

        public Uloga Uloga { get; set; }

    }
}
