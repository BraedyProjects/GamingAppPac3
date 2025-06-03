using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingAppPac3.Data;
using GamingAppPractice.Models;

namespace GamingAppPac3.Controllers
{
    public class Gamer_GameController : Controller
    {
        private readonly GamingAppPac3Context _context;

        public Gamer_GameController(GamingAppPac3Context context)
        {
            _context = context;
        }

        // GET: Gamer_Game
        public async Task<IActionResult> Index()
        {
            var gamingAppPac3Context = _context.Gamer_Game.Include(g => g.Game);
            return View(await gamingAppPac3Context.ToListAsync());
        }

        // GET: Gamer_Game/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer_Game = await _context.Gamer_Game
                .Include(g => g.Game)
                .FirstOrDefaultAsync(m => m.GGKey == id);
            if (gamer_Game == null)
            {
                return NotFound();
            }

            return View(gamer_Game);
        }

        // GET: Gamer_Game/Create
        public IActionResult Create()
        {
            // Fetch list of games for dropdown
            ViewBag.Games = new SelectList(_context.Game, "GameID", "GameName");
            ViewBag.Gamers = new SelectList(_context.Gamer, "UserID", "InGameName");
            return View();
        }

        // POST: Gamer_Game/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GGKey,UserID,GameID")] Gamer_Game gamer_Game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamer_Game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID", gamer_Game.GameID);
            return View(gamer_Game);
        }

        // GET: Gamer_Game/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer_Game = await _context.Gamer_Game.FindAsync(id);
            if (gamer_Game == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID", gamer_Game.GameID);
            return View(gamer_Game);
        }

        // POST: Gamer_Game/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GGKey,UserID,GameID")] Gamer_Game gamer_Game)
        {
            if (id != gamer_Game.GGKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamer_Game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Gamer_GameExists(gamer_Game.GGKey))
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
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID", gamer_Game.GameID);
            return View(gamer_Game);
        }

        // GET: Gamer_Game/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer_Game = await _context.Gamer_Game
                .Include(g => g.Game)
                .FirstOrDefaultAsync(m => m.GGKey == id);
            if (gamer_Game == null)
            {
                return NotFound();
            }

            return View(gamer_Game);
        }

        // POST: Gamer_Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamer_Game = await _context.Gamer_Game.FindAsync(id);
            if (gamer_Game != null)
            {
                _context.Gamer_Game.Remove(gamer_Game);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Gamer_GameExists(int id)
        {
            return _context.Gamer_Game.Any(e => e.GGKey == id);
        }
    }
}
