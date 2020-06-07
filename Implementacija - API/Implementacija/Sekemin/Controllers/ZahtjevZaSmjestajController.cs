using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers
{
    public class ZahtjevZaSmjestajController : Controller
    {
        private BazaContext context;
        private UserManager<Osoba> userManager;
        public ZahtjevZaSmjestajController(BazaContext context, UserManager<Osoba> userManager) {
            this.context = context;
            this.userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            //ViewData["SobaId"] = new SelectList(context.Student, "Id", "Id");
            List<SelectListItem> Cimeri = context.Student.Select(a => new SelectListItem
            {
                Value = a.Id,
                Text = a.Ime  + " " +  a.Prezime
            }
            ).ToList();

            ViewBag.CimerId = Cimeri;
            List<SelectListItem> Sobe = context.Soba.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Sprat.ToString() + " - " + a.RedniBroj.ToString()
            }
           ).ToList();

            ViewBag.SobaId = Sobe;
            return View();
        }
        private async Task<Osoba> GetKorisnik()
        {
            return await userManager.GetUserAsync(HttpContext.User);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,SobaId,CimerId")] ZahtjevZaSmjestaj zahtjev)
        {
            var student = await GetKorisnik();
            zahtjev.StudentId = student.Id;

            if (ModelState.IsValid)
            {
                context.Add(zahtjev);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Student");
            }
            //ViewData["StudentId"] = new SelectList(context.Student, "Id", "Id", s.StudentId);
            return View(zahtjev);
        }







    }
}
