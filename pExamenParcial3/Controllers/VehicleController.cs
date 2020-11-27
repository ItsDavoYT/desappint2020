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
    public class VehicleController : Controller
    {
        private readonly PoliceContext _context;

        public VehicleController(PoliceContext context)
        {
            _context = context;
        }

        // GET: Vehicle
        public async Task<IActionResult> Index(string searchString)
        {
            var busqueda = from d in _context.Vehicles select d;
            if(!string.IsNullOrEmpty(searchString)){
                busqueda = busqueda.Where(d=> d.strVehicleModel.Contains(searchString));
            }

            return View(await busqueda.ToListAsync()); 
        }

        // GET: Vehicle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVehicles = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.lngVehicleID == id);
            if (tblVehicles == null)
            {
                return NotFound();
            }

            return View(tblVehicles);
        }

        // GET: Vehicle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lngVehicleID,strVehicleChassisNo,strVehicleEngineNo,strVehicleEngineSize,strVehicleMake,strVehicleModel,lngRegistrationYear,strVehicleRegistrationNo,curVehicleValue,lngInsuranceGroup,strPolicyReferenceNo")] tblVehicles tblVehicles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblVehicles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblVehicles);
        }

        // GET: Vehicle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVehicles = await _context.Vehicles.FindAsync(id);
            if (tblVehicles == null)
            {
                return NotFound();
            }
            return View(tblVehicles);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("lngVehicleID,strVehicleChassisNo,strVehicleEngineNo,strVehicleEngineSize,strVehicleMake,strVehicleModel,lngRegistrationYear,strVehicleRegistrationNo,curVehicleValue,lngInsuranceGroup,strPolicyReferenceNo")] tblVehicles tblVehicles)
        {
            if (id != tblVehicles.lngVehicleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblVehicles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblVehiclesExists(tblVehicles.lngVehicleID))
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
            return View(tblVehicles);
        }

        // GET: Vehicle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVehicles = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.lngVehicleID == id);
            if (tblVehicles == null)
            {
                return NotFound();
            }

            return View(tblVehicles);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblVehicles = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(tblVehicles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblVehiclesExists(int id)
        {
            return _context.Vehicles.Any(e => e.lngVehicleID == id);
        }
    }
}
