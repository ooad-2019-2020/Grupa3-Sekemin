using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class Jelo
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
       
        [Required]
        [Display(Name = "Opis sastojaka jela")]
        public string Opis { get; set; }

       
    }
}
