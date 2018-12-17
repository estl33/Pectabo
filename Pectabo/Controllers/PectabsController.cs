using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pectabo.Models;

namespace Pectabo.Controllers
{
    public class PectabsController : Controller
    {
        private readonly PectaboContext _context;

        public PectabsController(PectaboContext context)
        {
            _context = context;
        }

        // GET: Pectabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pectab.ToListAsync());
        }

        // GET: Pectabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pectab = await _context.Pectab
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pectab == null)
            {
                return NotFound();
            }

            return View(pectab);
        }

        // GET: Pectabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pectabs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CreationDate,Type,Author")] Pectab pectab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pectab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pectab);
        }

        // GET: Pectabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pectab = await _context.Pectab.FindAsync(id);
            if (pectab == null)
            {
                return NotFound();
            }
            return View(pectab);
        }

        // POST: Pectabs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CreationDate,Type,Author")] Pectab pectab)
        {
            if (id != pectab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pectab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PectabExists(pectab.Id))
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
            return View(pectab);
        }

        // GET: Pectabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pectab = await _context.Pectab
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pectab == null)
            {
                return NotFound();
            }

            return View(pectab);
        }

        // POST: Pectabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pectab = await _context.Pectab.FindAsync(id);
            _context.Pectab.Remove(pectab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PectabExists(int id)
        {
            return _context.Pectab.Any(e => e.Id == id);
        }
    }
}
