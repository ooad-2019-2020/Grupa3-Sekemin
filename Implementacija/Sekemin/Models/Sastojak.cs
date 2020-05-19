using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class Sastojak
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Naziv sastojka")]
        public string NazivSastojka { get; set; }
    }
}
