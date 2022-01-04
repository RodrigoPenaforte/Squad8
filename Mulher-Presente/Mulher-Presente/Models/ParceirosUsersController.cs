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
    public class ParceirosUsersController : Controller
    {
        private readonly VitimaUserContext _context;

        public ParceirosUsersController(VitimaUserContext context)
        {
            _context = context;
        }

        // GET: ParceirosUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParceirosUser.ToListAsync());
        }

        // GET: ParceirosUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceirosUser = await _context.ParceirosUser
                .FirstOrDefaultAsync(m => m.ID_parceiro == id);
            if (parceirosUser == null)
            {
                return NotFound();
            }

            return View(parceirosUser);
        }

        // GET: ParceirosUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParceirosUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_parceiro,Nome,Telefone_parceiro,Email_parceiro,Especialidade")] ParceirosUser parceirosUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parceirosUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parceirosUser);
        }

        // GET: ParceirosUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceirosUser = await _context.ParceirosUser.FindAsync(id);
            if (parceirosUser == null)
            {
                return NotFound();
            }
            return View(parceirosUser);
        }

        // POST: ParceirosUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID_parceiro,Nome,Telefone_parceiro,Email_parceiro,Especialidade")] ParceirosUser parceirosUser)
        {
            if (id != parceirosUser.ID_parceiro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parceirosUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParceirosUserExists(parceirosUser.ID_parceiro))
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
            return View(parceirosUser);
        }

        // GET: ParceirosUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceirosUser = await _context.ParceirosUser
                .FirstOrDefaultAsync(m => m.ID_parceiro == id);
            if (parceirosUser == null)
            {
                return NotFound();
            }

            return View(parceirosUser);
        }

        // POST: ParceirosUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var parceirosUser = await _context.ParceirosUser.FindAsync(id);
            _context.ParceirosUser.Remove(parceirosUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParceirosUserExists(string id)
        {
            return _context.ParceirosUser.Any(e => e.ID_parceiro == id);
        }
    }
}
