using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinemahub_Official.Data;
using Cinemahub_Official.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cinemahub_Official.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Actors
        /* public async Task<IActionResult> Index()
        {
            return View(await _context.Actor.ToListAsync());
        } */

        // GET: Actors
        public async Task<IActionResult> Index(string actorNationality, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> nationalityQuery = from m in _context.Actor
                                            orderby m.Nationality
                                            select m.Nationality;
            var actors = from m in _context.Actor
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                actors = actors.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(actorNationality))
            {
                actors = actors.Where(x => x.Nationality == actorNationality);
            }

            var actorNationalityVM = new ActorNationalityViewModel
            {
                Nationality = new SelectList(await nationalityQuery.Distinct().ToListAsync()),
                Actors = await actors.ToListAsync()
            };

            return View(actorNationalityVM);
        }

        // GET: Actors/ShowSearchForm
        [Authorize]
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // GET: Actors/ShowSearchResult
        public async Task<IActionResult> ShowSearchResult(String SearchPhrase)
        {
            return View("Index", await _context.Actor.Where(a => a.Name.Contains(SearchPhrase)).ToListAsync());
        }
        // GET: Actors/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // GET: Actors/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Birthday,Nationality,Status")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Birthday,Nationality,Status")] Actor actor)
        {
            if (id != actor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.Id))
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
            return View(actor);
        }

        // GET: Actors/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _context.Actor.FindAsync(id);
            _context.Actor.Remove(actor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
            return _context.Actor.Any(e => e.Id == id);
        }
    }
}
