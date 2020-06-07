using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.ViewModels
{
    public class KreirajUlogu
    {
        [Required(ErrorMessage ="Morate unijeti naziv uloge!")]
        [Display(Name = "Naziv uloge")]
        public string NazivUloge { get; set; }
    }
}
