using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mulher_Presente.Data;
using Mulher_Presente.Models;

namespace Mulher_Presente.Controllers
{
    public class ParceirosController : Controller
    {
        private readonly MulherContext _context;

        public ParceirosController(MulherContext context)
        {
            _context = context;
        }

        // GET: Parceiros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parceiros.ToListAsync());
        }

        // GET: Parceiros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceiros = await _context.Parceiros
                .FirstOrDefaultAsync(m => m.id_parceiro == id);
            if (parceiros == null)
            {
                return NotFound();
            }

            return View(parceiros);
        }

        // GET: Parceiros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parceiros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_parceiro,Especilidade,Nome,Telefone,email")] Parceiros parceiros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parceiros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parceiros);
        }

        // GET: Parceiros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceiros = await _context.Parceiros.FindAsync(id);
            if (parceiros == null)
            {
                return NotFound();
            }
            return View(parceiros);
        }

        // POST: Parceiros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_parceiro,Especilidade,Nome,Telefone,email")] Parceiros parceiros)
        {
            if (id != parceiros.id_parceiro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parceiros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParceirosExists(parceiros.id_parceiro))
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
            return View(parceiros);
        }

        // GET: Parceiros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceiros = await _context.Parceiros
                .FirstOrDefaultAsync(m => m.id_parceiro == id);
            if (parceiros == null)
            {
                return NotFound();
            }

            return View(parceiros);
        }

        // POST: Parceiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parceiros = await _context.Parceiros.FindAsync(id);
            _context.Parceiros.Remove(parceiros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParceirosExists(int id)
        {
            return _context.Parceiros.Any(e => e.id_parceiro == id);
        }
    }
}
