using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public enum Uloga
    {
        
        Administrator,
        [Description("Upravitelj zaduživanja")]
        
        UpraviteljZaduzivanja,
        [Description("Upravitelj hranom")]
        UpraviteljHranom,
        [Description("Upravitelj bibliotekom")]
        UpraviteljBibliotekom,
        [Description("Upravitelj sobom za zabavu")]
        UpraviteljSobomZaZabavu,
        Student
    }
}
