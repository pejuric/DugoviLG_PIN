using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DugoviLG_PIN.Models;
using Microsoft.AspNetCore.Authorization;

namespace DugoviLG_PIN.Controllers
{
    [Authorize]
    public class PotDugovisController : Controller
    {
        private readonly PotDugoviContext _context;

        public PotDugovisController(PotDugoviContext context)
        {
            _context = context;
        }

        // GET: PotDugovis
        public async Task<IActionResult> Index()
        {
            return View(await _context.PotDugovi.ToListAsync());
        }

        // GET: PotDugovis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var potDugovi = await _context.PotDugovi
                .SingleOrDefaultAsync(m => m.ID == id);
            if (potDugovi == null)
            {
                return NotFound();
            }

            return View(potDugovi);
        }

        // GET: PotDugovis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PotDugovis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Prezime,KontaktBroj")] PotDugovi potDugovi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(potDugovi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(potDugovi);
        }

        // GET: PotDugovis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var potDugovi = await _context.PotDugovi.SingleOrDefaultAsync(m => m.ID == id);
            if (potDugovi == null)
            {
                return NotFound();
            }
            return View(potDugovi);
        }

        // POST: PotDugovis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Prezime,KontaktBroj")] PotDugovi potDugovi)
        {
            if (id != potDugovi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(potDugovi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PotDugoviExists(potDugovi.ID))
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
            return View(potDugovi);
        }

        // GET: PotDugovis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var potDugovi = await _context.PotDugovi
                .SingleOrDefaultAsync(m => m.ID == id);
            if (potDugovi == null)
            {
                return NotFound();
            }

            return View(potDugovi);
        }

        // POST: PotDugovis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var potDugovi = await _context.PotDugovi.SingleOrDefaultAsync(m => m.ID == id);
            _context.PotDugovi.Remove(potDugovi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PotDugoviExists(int id)
        {
            return _context.PotDugovi.Any(e => e.ID == id);
        }
    }
}
