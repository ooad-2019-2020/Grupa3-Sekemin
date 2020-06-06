using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers
{
    public class UpraviteljHranomController : Controller
    {

        private readonly BazaContext context;

        public UpraviteljHranomController(BazaContext context)
        {
            this.context = context;
        }



        public IActionResult Index()
        {
           /* var radnici = context.EvidencijaRadnika.Include(k => k.Radnici);
            List<Radnik> radnici2 = new List<Radnik>();
            foreach (var item in radnici)
            {
                foreach (var r in item.Radnici)
                {
                    radnici2.Add(r);
                }
            }
            var jela = context.Menu.Include(k => k.Jela);
            List<Jelo> jela2 = new List<Jelo>();
            foreach (var item in jela)
            {
                foreach (var j in item.Jela)
                {
                    jela2.Add(j);
                }
            }
            var tuple = new Tuple<IEnumerable<Radnik>, IEnumerable<Jelo>>(radnici2, jela2);
            return View(tuple);  */

            
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
                context.Add(radnik);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
          //  ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", knjiga.StudentId);
            return View(radnik);
        }

        public IActionResult CreateJelo()
        {
            return View();
        }
    }
}