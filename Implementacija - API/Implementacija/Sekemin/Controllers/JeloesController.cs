using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers
{
    public class JeloesController : Controller
    {
        private readonly BazaContext _context;

        public JeloesController(BazaContext context)
        {
            _context = context;
        }

        // GET: Jeloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jelo.ToListAsync());
        }

        // GET: Jeloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jelo = await _context.Jelo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jelo == null)
            {
                return NotFound();
            }

            return View(jelo);
        }

        // GET: Jeloes/Create
        [Authorize (Roles = "Administrator")]
        [Authorize (Roles = "Upravitelj hranom")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jeloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Upravitelj hranom")]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] Jelo jelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jelo);
        }

        // GET: Jeloes/Edit/5
        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Upravitelj hranom")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jelo = await _context.Jelo.FindAsync(id);
            if (jelo == null)
            {
                return NotFound();
            }
            return View(jelo);
        }

        // POST: Jeloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Upravitelj hranom")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] Jelo jelo)
        {
            if (id != jelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jelo);
                    await _context.SaveChangesAsync();
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

        // GET: Jeloes/Delete/5
        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Upravitelj hranom")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jelo = await _context.Jelo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jelo == null)
            {
                return NotFound();
            }

            return View(jelo);
        }

        // POST: Jeloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Upravitelj hranom")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jelo = await _context.Jelo.FindAsync(id);
            _context.Jelo.Remove(jelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JeloExists(int id)
        {
            return _context.Jelo.Any(e => e.Id == id);
        }
    }
}
