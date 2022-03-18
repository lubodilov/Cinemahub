using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinemahub_Official.Data;
using Cinemahub_Official.Models;

namespace Cinemahub_Official.Controllers
{
    public class AwardsController : Controller
    {
        private readonly Application1DbContext _context;

        public AwardsController(Application1DbContext context)
        {
            _context = context;
        }

        // GET: Awards
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Awards.ToListAsync());
        //}

        public async Task<IActionResult> Index(string searchString, string awardLocation)
        {
            IQueryable<string> locationQuery = from m in _context.Awards
                                               orderby m.Location
                                               select m.Location;
            var awards = from m in _context.Awards
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                awards = awards.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(awardLocation))
            {
                awards = awards.Where(x => x.Location == awardLocation);
            }

            var AwardsLocationVM = new AwardsNameViewModel
            {
                Location = new SelectList(await locationQuery.Distinct().ToListAsync()),
                Awards = await awards.ToListAsync()
            };

            return View(AwardsLocationVM);
        }

        // GET: Awards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awards = await _context.Awards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awards == null)
            {
                return NotFound();
            }

            return View(awards);
        }

        // GET: Awards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Awards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Founded,Location,WebSite")] Awards awards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(awards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(awards);
        }

        // GET: Awards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awards = await _context.Awards.FindAsync(id);
            if (awards == null)
            {
                return NotFound();
            }
            return View(awards);
        }

        // POST: Awards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Founded,Location,WebSite")] Awards awards)
        {
            if (id != awards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(awards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwardsExists(awards.Id))
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
            return View(awards);
        }

        // GET: Awards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awards = await _context.Awards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awards == null)
            {
                return NotFound();
            }

            return View(awards);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var awards = await _context.Awards.FindAsync(id);
            _context.Awards.Remove(awards);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardsExists(int id)
        {
            return _context.Awards.Any(e => e.Id == id);
        }
    }
}
