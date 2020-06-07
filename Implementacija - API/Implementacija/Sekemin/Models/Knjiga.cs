using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class Knjiga
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Naziv djela")]
        public string NazivDjela { get; set; }
        [Required]
        [Display(Name = "Žanr")]
        public string Zanr { get; set; }
        [Required]
        [Display(Name = "Ime pisca")]
        public string ImePisca { get; set; }
        [Required]
        [Display(Name = "Broj izdanja")]
        public int BrojIzdanja { get; set; }

        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
