using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTask.Data;
using MyTask.Models;

namespace MyTask.Controllers
{
    public class CalendersController : Controller
    {
        private readonly MytaskContext _context;

        public CalendersController(MytaskContext context)
        {
            _context = context;
        }

        // GET: Calenders
        public async Task<IActionResult> Index()
        {
            var mytaskContext = _context.Calender.Include(c => c.User);
            return View(await mytaskContext.ToListAsync());
        }

        // GET: Calenders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calender = await _context.Calender
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calender == null)
            {
                return NotFound();
            }

            return View(calender);
        }

        // GET: Calenders/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Calenders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Note,Time,UserId")] Calender calender)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calender);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", calender.UserId);
            return View(calender);
        }

        // GET: Calenders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calender = await _context.Calender.FindAsync(id);
            if (calender == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", calender.UserId);
            return View(calender);
        }

        // POST: Calenders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Note,Time,UserId")] Calender calender)
        {
            if (id != calender.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calender);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalenderExists(calender.Id))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", calender.UserId);
            return View(calender);
        }

        // GET: Calenders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calender = await _context.Calender
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calender == null)
            {
                return NotFound();
            }

            return View(calender);
        }

        // POST: Calenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calender = await _context.Calender.FindAsync(id);
            _context.Calender.Remove(calender);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalenderExists(int id)
        {
            return _context.Calender.Any(e => e.Id == id);
        }
    }
}
