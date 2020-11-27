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
    public class DriverController : Controller
    {
        private readonly PoliceContext _context;

        public DriverController(PoliceContext context)
        {
            _context = context;
        }

        // GET: Driver
        public async Task<IActionResult> Index(string searchString)
        {
            var drivers = from d in _context.Drivers select d;
            if(!string.IsNullOrEmpty(searchString)){
                drivers = drivers.Where(d=> d.strTitle.Contains(searchString));
            }

            return View(await drivers.ToListAsync());
        }

        // GET: Driver/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDrivers = await _context.Drivers
                .FirstOrDefaultAsync(m => m.lngDriveID == id);
            if (tblDrivers == null)
            {
                return NotFound();
            }

            return View(tblDrivers);
        }

        // GET: Driver/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Driver/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lngDriveID,strTitle,strFirstName,strLastName,dteDOB,dteDateLicensed,strLicenseReference,strAddress_Street,strAddress_TownVillage,strAddress_Country,strAddress_PostCode,strContactDayPhone,strContactNightPhone")] tblDrivers tblDrivers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblDrivers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblDrivers);
        }

        // GET: Driver/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDrivers = await _context.Drivers.FindAsync(id);
            if (tblDrivers == null)
            {
                return NotFound();
            }
            return View(tblDrivers);
        }

        // POST: Driver/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("lngDriveID,strTitle,strFirstName,strLastName,dteDOB,dteDateLicensed,strLicenseReference,strAddress_Street,strAddress_TownVillage,strAddress_Country,strAddress_PostCode,strContactDayPhone,strContactNightPhone")] tblDrivers tblDrivers)
        {
            if (id != tblDrivers.lngDriveID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblDrivers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblDriversExists(tblDrivers.lngDriveID))
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
            return View(tblDrivers);
        }

        // GET: Driver/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDrivers = await _context.Drivers
                .FirstOrDefaultAsync(m => m.lngDriveID == id);
            if (tblDrivers == null)
            {
                return NotFound();
            }

            return View(tblDrivers);
        }

        // POST: Driver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblDrivers = await _context.Drivers.FindAsync(id);
            _context.Drivers.Remove(tblDrivers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblDriversExists(int id)
        {
            return _context.Drivers.Any(e => e.lngDriveID == id);
        }
    }
}
