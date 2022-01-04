using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mulher_Presente.Data;

namespace Mulher_Presente.Models
{
    public class VitimaUsersController : Controller
    {
        private readonly VitimaUserContext _context;

        public VitimaUsersController(VitimaUserContext context)
        {
            _context = context;
        }

        // GET: VitimaUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.VitimaUser.ToListAsync());
        }

        // GET: VitimaUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vitimaUser = await _context.VitimaUser
                .FirstOrDefaultAsync(m => m.ID_vitima == id);
            if (vitimaUser == null)
            {
                return NotFound();
            }

            return View(vitimaUser);
        }

        // GET: VitimaUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VitimaUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_vitima,Nome,Telefone,Email,ParceirosUserID_parceiro")] VitimaUser vitimaUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vitimaUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vitimaUser);
        }

        // GET: VitimaUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vitimaUser = await _context.VitimaUser.FindAsync(id);
            if (vitimaUser == null)
            {
                return NotFound();
            }
            return View(vitimaUser);
        }

        // POST: VitimaUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID_vitima,Nome,Telefone,Email,ParceirosUserID_parceiro")] VitimaUser vitimaUser)
        {
            if (id != vitimaUser.ID_vitima)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vitimaUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VitimaUserExists(vitimaUser.ID_vitima))
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
            return View(vitimaUser);
        }

        // GET: VitimaUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vitimaUser = await _context.VitimaUser
                .FirstOrDefaultAsync(m => m.ID_vitima == id);
            if (vitimaUser == null)
            {
                return NotFound();
            }

            return View(vitimaUser);
        }

        // POST: VitimaUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vitimaUser = await _context.VitimaUser.FindAsync(id);
            _context.VitimaUser.Remove(vitimaUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VitimaUserExists(string id)
        {
            return _context.VitimaUser.Any(e => e.ID_vitima == id);
        }
    }
}
