using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class Student: Osoba
    {
        [Required]
        public string Fakultet { get; set; }
        [Required]
        [Display(Name = "Godina studija")]
        public int GodinaStudija { get; set; }
        public int BrojBonova { get; set; }
    }
}
