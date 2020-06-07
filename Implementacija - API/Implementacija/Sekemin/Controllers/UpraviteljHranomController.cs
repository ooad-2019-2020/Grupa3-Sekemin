using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers
{   
    [Authorize(Roles ="UpraviteljHranom")]
    public class UpraviteljHranomController : Controller
    {

        private readonly BazaContext context;
        private UserManager<Osoba> userManager;
        public UpraviteljHranomController(BazaContext context, UserManager<Osoba> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var radnici = context.Radnik;
            var jela = context.Jelo;
            var tuple = new Tuple<IEnumerable<Radnik>, IEnumerable<Jelo>>(radnici, jela);

            ViewBag.Ime = getStudent().Ime; 
            return View(tuple);
        }


        private Osoba getStudent()
        {
            var korisnikId = getKorisnik();
            var student = context.Osoba.FirstOrDefault(s => s.Id == korisnikId);

            return student;
        }

        private String getKorisnik()
        {
            return userManager.GetUserId(HttpContext.User);
        }

        public IActionResult CreateRadnik()
        {
            //  ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRadnik([Bind("Id,Ime,Prezime,DatumRodjenja")] Radnik radnik)
        {
            if (ModelState.IsValid)
            {

                var evidencije = context.EvidencijaRadnika.Include(k => k.Radnici);
                List<Radnik> lista = new List<Radnik>();
                foreach (var e in evidencije)
                {
                    if (e == null)
                    {
                        EvidencijaRadnika prvaEvidencija = new EvidencijaRadnika();
                        prvaEvidencija.Id = 1;
                        prvaEvidencija.Radnici = lista;
                        prvaEvidencija.Radnici.Add(radnik);
                        context.Add(prvaEvidencija);
                        break;
                    }

                    e.Radnici.Add(radnik);
                    // context.Update(e);
                    break;
                }

                context.Add(radnik);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //  ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", knjiga.StudentId);
            return View(radnik);
        }

        public IActionResult CreateJelo()
        {
            //  ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJelo([Bind("Id,Naziv,Opis")] Jelo jelo)
        {
            if (ModelState.IsValid)
            {

                context.Add(jelo);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jelo);
        }

        public async Task<IActionResult> DeleteRadnika(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radnik = await context.Radnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (radnik == null)
            {
                return NotFound();
            }

            return View(radnik);
        }

        // POST: Radnik/DeleteRadnika/5
        [HttpPost, ActionName("DeleteRadnika")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRadnikaConfirmed(int id)
        {
            var radnik = await context.Radnik.FindAsync(id);
            context.Radnik.Remove(radnik);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditJelo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jelo = await context.Jelo.FindAsync(id);
            if (jelo == null)
            {
                return NotFound();
            }

            return View(jelo);
        }

        // POST: Jelo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditJelo(int id, [Bind("Id,Naziv,Opis")] Jelo jelo)
        {
            if (id != jelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(jelo);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JeloExists(jelo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(jelo);
        }

        private bool JeloExists(int id)
        {
            return context.Jelo.Any(e => e.Id == id);
        }

        public async Task<IActionResult> DetailsJelo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jelo = await context.Jelo.FirstOrDefaultAsync(m => m.Id == id);
            if (jelo == null)
            {
                return NotFound();
            }

            return View(jelo);
        }



        public async Task<IActionResult> DeleteJelo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jelo = await context.Jelo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jelo == null)
            {
                return NotFound();
            }

            return View(jelo);
        }

        // POST: Radnik/DeleteRadnika/5
        [HttpPost, ActionName("DeleteJelo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteJeloConfirmed(int id)
        {
            var jelo = await context.Jelo.FindAsync(id);
            context.Jelo.Remove(jelo);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DetailsRadnik(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radnik = await context.Radnik.FirstOrDefaultAsync(m => m.Id == id);
            if (radnik == null)
            {
                return NotFound();
            }

            return View(radnik);
        }


        public async Task<IActionResult> EditRadnika(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radnik = await context.Radnik.FindAsync(id);
            if (radnik == null)
            {
                return NotFound();
            }

            return View(radnik);
        }

        // POST: Knjiga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRadnika(int id, [Bind("Id,Ime,Prezime,DatumRodjenja")] Radnik radnik)
        {
            if (id != radnik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(radnik);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RadnikExists(radnik.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(radnik);
        }

        private bool RadnikExists(int id)
        {
            return context.Radnik.Any(e => e.Id == id);
        }


    }
}
