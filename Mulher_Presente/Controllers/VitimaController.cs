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
    public class VitimaController : Controller
    {
        private readonly MulherContext _context;

        public VitimaController(MulherContext context)
        {
            _context = context;
        }

        // GET: Vitima
        public async Task<IActionResult> Index()
        {
            var mulherContext = _context.Vitima.Include(v => v.Parceiros);
            return View(await mulherContext.ToListAsync());
        }

        // GET: Vitima/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vitima = await _context.Vitima
                .Include(v => v.Parceiros)
                .FirstOrDefaultAsync(m => m.id_vitima == id);
            if (vitima == null)
            {
                return NotFound();
            }

            return View(vitima);
        }

        // GET: Vitima/Create
        public IActionResult Create()
        {
            ViewData["Parceirosid_parceiro"] = new SelectList(_context.Parceiros, "id_parceiro", "Especilidade");
            return View();
        }

        // POST: Vitima/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_vitima,apelido,telefone,email,Parceirosid_parceiro")] Vitima vitima)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vitima);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Parceirosid_parceiro"] = new SelectList(_context.Parceiros, "id_parceiro", "Especilidade", vitima.Parceirosid_parceiro);
            return View(vitima);
        }

        // GET: Vitima/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vitima = await _context.Vitima.FindAsync(id);
            if (vitima == null)
            {
                return NotFound();
            }
            ViewData["Parceirosid_parceiro"] = new SelectList(_context.Parceiros, "id_parceiro", "Especilidade", vitima.Parceirosid_parceiro);
            return View(vitima);
        }

        // POST: Vitima/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_vitima,apelido,telefone,email,Parceirosid_parceiro")] Vitima vitima)
        {
            if (id != vitima.id_vitima)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vitima);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VitimaExists(vitima.id_vitima))
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
            ViewData["Parceirosid_parceiro"] = new SelectList(_context.Parceiros, "id_parceiro", "Especilidade", vitima.Parceirosid_parceiro);
            return View(vitima);
        }

        // GET: Vitima/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vitima = await _context.Vitima
                .Include(v => v.Parceiros)
                .FirstOrDefaultAsync(m => m.id_vitima == id);
            if (vitima == null)
            {
                return NotFound();
            }

            return View(vitima);
        }

        // POST: Vitima/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vitima = await _context.Vitima.FindAsync(id);
            _context.Vitima.Remove(vitima);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VitimaExists(int id)
        {
            return _context.Vitima.Any(e => e.id_vitima == id);
        }
    }
}
