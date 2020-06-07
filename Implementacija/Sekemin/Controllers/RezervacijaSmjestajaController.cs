using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sekemin.Data;
using Sekemin.Models;
using Sekemin.ViewModels;

namespace Sekemin.Controllers
{
    public class RezervacijaSmjestajaController : Controller
    {
        private BazaContext _context;

        public RezervacijaSmjestajaController(BazaContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            return View();
        }

        // POST: Knjiga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("rezervacijaSmjestaja, zahtjev")] KreiranjeRezervacijeSmjestaja rezervacijaSmjestaja)
        {
            RezervacijaSmjestaja rezervacija = rezervacijaSmjestaja.rezervacijaSmjestaja;
            

            if (ModelState.IsValid)
            {
                _context.Add(rezervacijaSmjestaja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", rezervacijaSmjestaja.StudentId);
            return View(rezervacijaSmjestaja);
        }


    }
}
