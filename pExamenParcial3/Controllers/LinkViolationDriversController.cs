using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorPolicy.Data;
using MotorPolicy.Models;

namespace MotorPolicy.Controllers
{
    public class LinkViolationDriversController : Controller
    {
        private readonly PoliceContext _context;

        public LinkViolationDriversController(PoliceContext context)
        {
            _context = context;
        }

        // GET: LinkViolationDrivers
        public async Task<IActionResult> Index()
        {
            return View(await _context.link_ViolationsDrivers.ToListAsync());
        }

        // GET: LinkViolationDrivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLink_ViolationsDrivers = await _context.link_ViolationsDrivers
                .FirstOrDefaultAsync(m => m.lngDriveID == id);
            if (tblLink_ViolationsDrivers == null)
            {
                return NotFound();
            }

            return View(tblLink_ViolationsDrivers);
        }

        // GET: LinkViolationDrivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LinkViolationDrivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lngDriveID,strViolationCode")] tblLink_ViolationsDrivers tblLink_ViolationsDrivers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblLink_ViolationsDrivers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblLink_ViolationsDrivers);
        }

        // GET: LinkViolationDrivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLink_ViolationsDrivers = await _context.link_ViolationsDrivers.FindAsync(id);
            if (tblLink_ViolationsDrivers == null)
            {
                return NotFound();
            }
            return View(tblLink_ViolationsDrivers);
        }

        // POST: LinkViolationDrivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("lngDriveID,strViolationCode")] tblLink_ViolationsDrivers tblLink_ViolationsDrivers)
        {
            if (id != tblLink_ViolationsDrivers.lngDriveID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblLink_ViolationsDrivers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblLink_ViolationsDriversExists(tblLink_ViolationsDrivers.lngDriveID))
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
            return View(tblLink_ViolationsDrivers);
        }

        // GET: LinkViolationDrivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLink_ViolationsDrivers = await _context.link_ViolationsDrivers
                .FirstOrDefaultAsync(m => m.lngDriveID == id);
            if (tblLink_ViolationsDrivers == null)
            {
                return NotFound();
            }

            return View(tblLink_ViolationsDrivers);
        }

        // POST: LinkViolationDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblLink_ViolationsDrivers = await _context.link_ViolationsDrivers.FindAsync(id);
            _context.link_ViolationsDrivers.Remove(tblLink_ViolationsDrivers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblLink_ViolationsDriversExists(int id)
        {
            return _context.link_ViolationsDrivers.Any(e => e.lngDriveID == id);
        }
    }
}
