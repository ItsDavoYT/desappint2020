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
    public class InsuranceGroupsController : Controller
    {
        private readonly PoliceContext _context;

        public InsuranceGroupsController(PoliceContext context)
        {
            _context = context;
        }

        // GET: InsuranceGroups
        public async Task<IActionResult> Index(string searchString)
        {
            
            var busqueda = from d in _context.InsuranceGroups select d;
            if(!string.IsNullOrEmpty(searchString)){
                busqueda = busqueda.Where(d=> d.memInsuranceGroupDetails.Contains(searchString));
            }

            return View(await busqueda.ToListAsync());
        }

        // GET: InsuranceGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsuranceGroups = await _context.InsuranceGroups
                .FirstOrDefaultAsync(m => m.lngInsuranceGroup == id);
            if (tblInsuranceGroups == null)
            {
                return NotFound();
            }

            return View(tblInsuranceGroups);
        }

        // GET: InsuranceGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsuranceGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lngInsuranceGroup,memInsuranceGroupDetails")] tblInsuranceGroups tblInsuranceGroups)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblInsuranceGroups);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblInsuranceGroups);
        }

        // GET: InsuranceGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsuranceGroups = await _context.InsuranceGroups.FindAsync(id);
            if (tblInsuranceGroups == null)
            {
                return NotFound();
            }
            return View(tblInsuranceGroups);
        }

        // POST: InsuranceGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("lngInsuranceGroup,memInsuranceGroupDetails")] tblInsuranceGroups tblInsuranceGroups)
        {
            if (id != tblInsuranceGroups.lngInsuranceGroup)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblInsuranceGroups);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblInsuranceGroupsExists(tblInsuranceGroups.lngInsuranceGroup))
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
            return View(tblInsuranceGroups);
        }

        // GET: InsuranceGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsuranceGroups = await _context.InsuranceGroups
                .FirstOrDefaultAsync(m => m.lngInsuranceGroup == id);
            if (tblInsuranceGroups == null)
            {
                return NotFound();
            }

            return View(tblInsuranceGroups);
        }

        // POST: InsuranceGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblInsuranceGroups = await _context.InsuranceGroups.FindAsync(id);
            _context.InsuranceGroups.Remove(tblInsuranceGroups);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblInsuranceGroupsExists(int id)
        {
            return _context.InsuranceGroups.Any(e => e.lngInsuranceGroup == id);
        }
    }
}
