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
    public class LinkVehiclesDriversController : Controller
    {
        private readonly PoliceContext _context;

        public LinkVehiclesDriversController(PoliceContext context)
        {
            _context = context;
        }

        // GET: LinkVehiclesDrivers
        public async Task<IActionResult> Index()
        {
            var policeContext = _context.link_VehiclesDrivers.Include(t => t.Vehicles);
            return View(await policeContext.ToListAsync());
        }

        // GET: LinkVehiclesDrivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLink_VehiclesDrivers = await _context.link_VehiclesDrivers
                .Include(t => t.Vehicles)
                .FirstOrDefaultAsync(m => m.lngDriveID == id);
            if (tblLink_VehiclesDrivers == null)
            {
                return NotFound();
            }

            return View(tblLink_VehiclesDrivers);
        }

        // GET: LinkVehiclesDrivers/Create
        public IActionResult Create()
        {
            ViewData["lngDriveID"] = new SelectList(_context.Vehicles, "lngVehicleID", "lngVehicleID");
            return View();
        }

        // POST: LinkVehiclesDrivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lngDriveID,lngVehicleID")] tblLink_VehiclesDrivers tblLink_VehiclesDrivers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblLink_VehiclesDrivers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["lngDriveID"] = new SelectList(_context.Vehicles, "lngVehicleID", "lngVehicleID", tblLink_VehiclesDrivers.lngDriveID);
            return View(tblLink_VehiclesDrivers);
        }

        // GET: LinkVehiclesDrivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLink_VehiclesDrivers = await _context.link_VehiclesDrivers.FindAsync(id);
            if (tblLink_VehiclesDrivers == null)
            {
                return NotFound();
            }
            ViewData["lngDriveID"] = new SelectList(_context.Vehicles, "lngVehicleID", "lngVehicleID", tblLink_VehiclesDrivers.lngDriveID);
            return View(tblLink_VehiclesDrivers);
        }

        // POST: LinkVehiclesDrivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("lngDriveID,lngVehicleID")] tblLink_VehiclesDrivers tblLink_VehiclesDrivers)
        {
            if (id != tblLink_VehiclesDrivers.lngDriveID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblLink_VehiclesDrivers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblLink_VehiclesDriversExists(tblLink_VehiclesDrivers.lngDriveID))
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
            ViewData["lngDriveID"] = new SelectList(_context.Vehicles, "lngVehicleID", "lngVehicleID", tblLink_VehiclesDrivers.lngDriveID);
            return View(tblLink_VehiclesDrivers);
        }

        // GET: LinkVehiclesDrivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLink_VehiclesDrivers = await _context.link_VehiclesDrivers
                .Include(t => t.Vehicles)
                .FirstOrDefaultAsync(m => m.lngDriveID == id);
            if (tblLink_VehiclesDrivers == null)
            {
                return NotFound();
            }

            return View(tblLink_VehiclesDrivers);
        }

        // POST: LinkVehiclesDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblLink_VehiclesDrivers = await _context.link_VehiclesDrivers.FindAsync(id);
            _context.link_VehiclesDrivers.Remove(tblLink_VehiclesDrivers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblLink_VehiclesDriversExists(int id)
        {
            return _context.link_VehiclesDrivers.Any(e => e.lngDriveID == id);
        }
    }
}
