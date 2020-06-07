using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers {
    [Authorize(Roles ="Student")]
    public class StudentController : Controller {
        private readonly BazaContext context;
        private readonly UserManager<Osoba> userManager;

        public StudentController(BazaContext context, UserManager<Osoba> userManager) {
            this.context = context;
            this.userManager = userManager;
        }

        private Student getStudent()
        {
            var studentId = getKorisnik();
            var student = context.Student.FirstOrDefault(s => s.Id == studentId);

            return student;
        }

        private String getKorisnik()
        {
            return userManager.GetUserId(HttpContext.User);
        }
        public  IActionResult VratiKnjigu(int? knjigaId)
        {
            if (knjigaId == null)
            {
                return NoContent();
            }

            var knjiga = context.Knjiga.FirstOrDefault(k => k.Id == knjigaId);
            if (knjiga == null)
            {
                return NoContent();
            }

            knjiga.StudentId = null;
            context.Update(knjiga);
            context.SaveChanges();

            return RedirectToAction("Biblioteka", "Student");
        }


        public IActionResult Index() {
            ViewBag.Ime = getStudent().Ime;
            return View();
        }

        public IActionResult Jelovnik() {
            var jela = context.Jelo;
            var trenutni = getStudent();
            return View(new Tuple<IEnumerable<Jelo>, Student>(jela, trenutni));
        }


        public async Task<IActionResult> Biblioteka()
        {
            var bazaContext = context.Knjiga.Where(k => k.StudentId == null);
            var tuple = new Tuple<IEnumerable<Knjiga>, Knjiga>(await bazaContext.ToListAsync(), GetPodignutaKnjiga());
            return View(tuple);
        }
        private Knjiga GetPodignutaKnjiga()
        {
            String studentId = getKorisnik();
            if (studentId == null) return null;
            var knjiga = context.Knjiga.FirstOrDefault(k => k.StudentId == studentId);
            return knjiga;
        }

        public IActionResult SobaZaZabavu() {
            return View();
        }

        //nisam jos siguran koji parametri se šalju ovdje

        public IActionResult PlatiHranu()
        {
            var studentId = getKorisnik();

            var student = context.Student.FirstOrDefault(s => s.Id == studentId);

            if (student == null || student.BrojBonova < 1)
            {
                Console.WriteLine("Korisnik nije student ili nije prijavljen");
                return NoContent();
            }

            student.BrojBonova = student.BrojBonova - 1;
            context.Update(student);
            context.SaveChanges();

            return RedirectToAction("Jelovnik", "Student");
        }

        public async Task<IActionResult> PodigniKnjigu(int? knjigaId)
        {
            if (knjigaId == null)
            {
                return NoContent();
            }
            var studentId = getKorisnik();
            var student = context.Student.FirstOrDefault(s => s.Id != null && s.Id == studentId);

            if (student == null)
            {
                return NoContent();
            }

            var knjigaBaza = context.Knjiga.FirstOrDefault(k => k.Id == knjigaId && k.Student == null);

            if (knjigaBaza == null)
            {
                Console.WriteLine("Odabrana knjiga nije dostupna");
                return NoContent();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ZahtjevZaPodizanjeKnjige zahtjev = new ZahtjevZaPodizanjeKnjige();
                    zahtjev.Knjiga = knjigaBaza;
                    zahtjev.KnjigaId = knjigaBaza.Id;
                    zahtjev.Student = student;
                    zahtjev.StudentId = student.Id;
                    context.Add(zahtjev);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NoContent();
                }
            }

            return RedirectToAction("Biblioteka", "Student");
        }

        public IActionResult Razduzivanje()
        {
            return View(getStudent());
        }

        public IActionResult PotvrdaRazduzivanja()
        {
            ZahtjevZaRazduzivanje zahtjev = new ZahtjevZaRazduzivanje();

            zahtjev.StudentId = getKorisnik();

            context.Add(zahtjev);
            context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        public IActionResult Rezervisi([Bind("DatumSlanja, Trajanje")] ZahtjevSobaZaZabavu zahtjev)
        {
            zahtjev.StudentId = getKorisnik();

            if (zahtjev.StudentId == null)
            {
                return NoContent();
            }

            context.Add(zahtjev);
            context.SaveChanges();

            return RedirectToAction("SobaZaZabavu", "Student");
        }
    }
}
