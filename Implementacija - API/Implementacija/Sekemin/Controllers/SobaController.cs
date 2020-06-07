using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers
{
    [Authorize(Roles = "UpraviteljZaduzivanja")]
    public class SobaController : Controller
    {

        private BazaContext context;

        public SobaController(BazaContext context)
        {
            this.context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            List<SelectListItem> Studenti = context.Student.Select(a => new SelectListItem
            {
                Value = a.Id,
                Text = a.Ime + " " + a.Prezime
            }
            ).ToList();

            ViewBag.CimerId = Studenti;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sprat,RedniBroj,StudentPrviId,StudentDrugiId")] Soba soba)
        {
            if (ModelState.IsValid)
            {
                context.Add(soba);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            //ViewData["StudentId"] = new SelectList(context.Student, "Id", "Id", s.StudentId);
            return View(soba);
        }






    }
}
