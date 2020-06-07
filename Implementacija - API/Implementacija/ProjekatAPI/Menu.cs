using System;
using System.Collections.Generic;

namespace ProjekatAPI
{
    public partial class Menu
    {
        public Menu()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            Jela = new HashSet<Jela>();
        }

        public int Id { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<Jela> Jela { get; set; }
    }
}
