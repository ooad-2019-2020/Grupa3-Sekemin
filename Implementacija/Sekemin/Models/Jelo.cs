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
        

        public virtual ICollection<Sastojak> Sastojci { get; set; }
    }
}
