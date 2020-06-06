using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class Soba
    {
        public int Id { get; set; }
        [Required]
        public int Sprat { get; set; }
        [Required]
        [Display(Name = "Redni broj")]
        public int RedniBroj { get; set; }
        public string StudentPrviId { get; set; }
        public string StudentDrugiId { get; set; }

        [ForeignKey("StudentiPrviId")]
        public virtual Student StudentPrvi { get; set; }
        [ForeignKey("StudentiDrugiId")]
        public virtual Student StudentDrugi { get; set; }


    }
}
