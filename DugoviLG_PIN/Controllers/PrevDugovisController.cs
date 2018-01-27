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
    public class PrevDugovisController : Controller
    {
        private readonly PrevDugoviContext _context;

        public PrevDugovisController(PrevDugoviContext context)
        {
            _context = context;
        }

        // GET: PrevDugovis
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrevDugovi.ToListAsync());
        }

        // GET: PrevDugovis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prevDugovi = await _context.PrevDugovi
                .SingleOrDefaultAsync(m => m.ID == id);
            if (prevDugovi == null)
            {
                return NotFound();
            }

            return View(prevDugovi);
        }

        // GET: PrevDugovis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrevDugovis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Prezime,PosuđenNovac_Kn,Vraćen_Novac_Kn")] PrevDugovi prevDugovi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prevDugovi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prevDugovi);
        }

        // GET: PrevDugovis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prevDugovi = await _context.PrevDugovi.SingleOrDefaultAsync(m => m.ID == id);
            if (prevDugovi == null)
            {
                return NotFound();
            }
            return View(prevDugovi);
        }

        // POST: PrevDugovis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Prezime,PosuđenNovac_Kn,Vraćen_Novac_Kn")] PrevDugovi prevDugovi)
        {
            if (id != prevDugovi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prevDugovi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrevDugoviExists(prevDugovi.ID))
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
            return View(prevDugovi);
        }

        // GET: PrevDugovis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prevDugovi = await _context.PrevDugovi
                .SingleOrDefaultAsync(m => m.ID == id);
            if (prevDugovi == null)
            {
                return NotFound();
            }

            return View(prevDugovi);
        }

        // POST: PrevDugovis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prevDugovi = await _context.PrevDugovi.SingleOrDefaultAsync(m => m.ID == id);
            _context.PrevDugovi.Remove(prevDugovi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrevDugoviExists(int id)
        {
            return _context.PrevDugovi.Any(e => e.ID == id);
        }
    }
}
