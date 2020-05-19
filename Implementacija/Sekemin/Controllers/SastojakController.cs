using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers
{
    public class SastojakController : Controller
    {
        private readonly BazaContext _context;

        public SastojakController(BazaContext context)
        {
            _context = context;
        }

        // GET: Sastojak
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sastojak.ToListAsync());
        }

        // GET: Sastojak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sastojak = await _context.Sastojak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sastojak == null)
            {
                return NotFound();
            }

            return View(sastojak);
        }

        // GET: Sastojak/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sastojak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NazivSastojka")] Sastojak sastojak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sastojak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sastojak);
        }

        // GET: Sastojak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sastojak = await _context.Sastojak.FindAsync(id);
            if (sastojak == null)
            {
                return NotFound();
            }
            return View(sastojak);
        }

        // POST: Sastojak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazivSastojka")] Sastojak sastojak)
        {
            if (id != sastojak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sastojak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SastojakExists(sastojak.Id))
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
            return View(sastojak);
        }

        // GET: Sastojak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sastojak = await _context.Sastojak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sastojak == null)
            {
                return NotFound();
            }

            return View(sastojak);
        }

        // POST: Sastojak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sastojak = await _context.Sastojak.FindAsync(id);
            _context.Sastojak.Remove(sastojak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SastojakExists(int id)
        {
            return _context.Sastojak.Any(e => e.Id == id);
        }
    }
}
