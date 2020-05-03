
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Take1.Models;
using Microsoft.EntityFrameworkCore;
namespace Take1.Models
{
    public class OOADContext:DbContext
    {
        public OOADContext(DbContextOptions<OOADContext> options): base(options)
        {
        }
        
       public DbSet<Person> Persons { get; set; }
       public DbSet<Instructor> Instructors { get; set; }
       public DbSet<Student> Students { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>().ToTable("Person");
           
        }


    }
}
