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
        public async void VratiKnjigu(int? knjigaId)
        {
            if (knjigaId == null)
            {
                return;
            }

            var knjiga = context.Knjiga.FirstOrDefault(k => k.Id == knjigaId);
            if (knjiga == null)
            {
                return;
            }

            knjiga.StudentId = null;
            context.Update(knjiga);
            context.SaveChanges();

            await Biblioteka();
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
        public void Rezervisi(DateTime datumRezervacijeSobe, DateTime pocetakRezervacijeSobe, DateTime krajRezervacijeSobe)
        {
            ZahtjevSobaZaZabavu zahtjev = new ZahtjevSobaZaZabavu();

            zahtjev.StudentId = getKorisnik();

            if (zahtjev.StudentId == null)
            {
                return;
            }

            TimeSpan ts = krajRezervacijeSobe - pocetakRezervacijeSobe;
            if (krajRezervacijeSobe < pocetakRezervacijeSobe)
            {
                return;
            }

            zahtjev.Trajanje = ts.TotalMinutes;
            zahtjev.DatumSlanja = datumRezervacijeSobe;

            context.Add(zahtjev);
            context.SaveChanges();
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
