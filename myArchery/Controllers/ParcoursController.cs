#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myArchery.Persistance;
using myArchery.Persistance.Models;

namespace myArchery.Controllers
{
    public class ParcoursController : Controller
    {
        private readonly ArcheryDbContext _context;

        public ParcoursController(ArcheryDbContext context)
        {
            _context = context;
        }

        // GET: Parcours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parcours.ToListAsync());
        }

        // GET: Parcours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcour = await _context.Parcours
                .FirstOrDefaultAsync(m => m.ParId == id);
            if (parcour == null)
            {
                return NotFound();
            }

            return View(parcour);
        }

        // GET: Parcours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parcours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                Parcour parcour = new()
                {
                    Parcourname = collection["Parcourname"],
                    Counttargets = Convert.ToInt32(collection["Counttargets"]),
                    Postalcode = Convert.ToInt32(collection["Postalcode"]),
                    StreetHousenumber = collection["StreetHousenumber"],
                    Town = collection["Town"]
                };

                for (int i = 5; i < collection.Count-1; i++)
                {
                    var currentindex = i - 5;
                    Target t = new()
                    {
                        Targetname = collection[$"Targets[{currentindex}].Name"]
                    };

                    ParcoursTarget pt = new()
                    {
                        Par = parcour,
                        Tar = t
                    };

                    _context.ParcoursTargets.Add(pt);
                }

                _context.Parcours.Add(parcour);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Parcours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcour = await _context.Parcours.FindAsync(id);
            if (parcour == null)
            {
                return NotFound();
            }
            return View(parcour);
        }

        // POST: Parcours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParId,Parcourname,Town,Postalcode,StreetHousenumber,Counttargets")] Parcour parcour)
        {
            if (id != parcour.ParId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parcour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParcourExists(parcour.ParId))
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
            return View(parcour);
        }

        // GET: Parcours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcour = await _context.Parcours
                .FirstOrDefaultAsync(m => m.ParId == id);
            if (parcour == null)
            {
                return NotFound();
            }

            return View(parcour);
        }

        // POST: Parcours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parcour = await _context.Parcours.FindAsync(id);
            _context.Parcours.Remove(parcour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParcourExists(int id)
        {
            return _context.Parcours.Any(e => e.ParId == id);
        }
    }
}
