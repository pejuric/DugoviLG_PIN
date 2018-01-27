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
    public class CurDugovisController : Controller
    {
        private readonly CurDugoviContext _context;

        public CurDugovisController(CurDugoviContext context)
        {
            _context = context;
        }

        // GET: CurDugovis
        public async Task<IActionResult> Index()
        {
            return View(await _context.CurDugovi.ToListAsync());
        }

        // GET: CurDugovis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curDugovi = await _context.CurDugovi
                .SingleOrDefaultAsync(m => m.ID == id);
            if (curDugovi == null)
            {
                return NotFound();
            }

            return View(curDugovi);
        }

        // GET: CurDugovis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CurDugovis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Prezime,PosuđenNovac_Kn,Tjedne_Kamate,Datum_Posudbe,Rok_Povratka")] CurDugovi curDugovi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curDugovi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curDugovi);
        }

        // GET: CurDugovis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curDugovi = await _context.CurDugovi.SingleOrDefaultAsync(m => m.ID == id);
            if (curDugovi == null)
            {
                return NotFound();
            }
            return View(curDugovi);
        }

        // POST: CurDugovis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Prezime,PosuđenNovac_Kn,Tjedne_Kamate,Datum_Posudbe,Rok_Povratka")] CurDugovi curDugovi)
        {
            if (id != curDugovi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curDugovi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurDugoviExists(curDugovi.ID))
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
            return View(curDugovi);
        }

        // GET: CurDugovis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curDugovi = await _context.CurDugovi
                .SingleOrDefaultAsync(m => m.ID == id);
            if (curDugovi == null)
            {
                return NotFound();
            }

            return View(curDugovi);
        }

        // POST: CurDugovis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curDugovi = await _context.CurDugovi.SingleOrDefaultAsync(m => m.ID == id);
            _context.CurDugovi.Remove(curDugovi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurDugoviExists(int id)
        {
            return _context.CurDugovi.Any(e => e.ID == id);
        }
    }
}
