using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        public int ZahtjevId { get; set; }
        [Required]
        public DateTime Pocetak { get; set; }

        

        public virtual Student Student { get; set; }
        public virtual Zahtjev Zahtjev { get; set; }
    }
}
