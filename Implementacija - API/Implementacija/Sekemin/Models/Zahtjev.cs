using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class Zahtjev
    {
        public int Id { get; set; }
        public string StudentId { get; set; }       
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

    }
}
