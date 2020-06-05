using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers {
    public class StudentController : Controller {
        private readonly BazaContext context;

        public StudentController(BazaContext context) {
            this.context = context;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Jelovnik() {
            return View();
        }

        public async Task<IActionResult> Biblioteka() {
            var bazaContext = context.Knjiga.Include(k => k.Student);
            return View(await bazaContext.ToListAsync());
        }

        public IActionResult SobaZaZabavu() {
            return View();
        }

        //nisam jos siguran koji parametri se šalju ovdje

        public void PlatiHranu(int id) {
            var student = context.Student.FirstOrDefault(s => Int32.Parse(s.Id) == id);

            if(student == null) {
                Console.WriteLine("Korisnik nije student ili nije prijavljen");
            }
        }

        public async Task<IActionResult> PodigniKnjigu(int studentId, Knjiga knjiga) {
            var student = context.Student.FirstOrDefault(s => Int32.Parse(s.Id) == studentId);

            if(student == null) {
                Console.WriteLine("Korisnik nije student ili nije prijavljen");
            }

            var knjigaBaza = context.Knjiga.FirstOrDefault(k => k.Id == knjiga.Id && k.Student == null);

            if(knjigaBaza == null) {
                Console.WriteLine("Odabrana knjiga nije dostupna");
            }

            if (ModelState.IsValid) {
                try {
                    context.Update(knjiga);
                    await context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    return NoContent();
                }
            }

            return View(knjigaBaza);
        }
    }
}
