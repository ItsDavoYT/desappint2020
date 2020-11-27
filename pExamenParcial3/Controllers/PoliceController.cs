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
    public class PoliceController : Controller
    {
        private readonly PoliceContext _context;

        public PoliceController(PoliceContext context)
        {
            _context = context;
        }

        // GET: Police
        public async Task<IActionResult> Index(string searchString)
        {
            var busqueda = from d in _context.Policies select d;
            if(!string.IsNullOrEmpty(searchString)){
                busqueda = busqueda.Where(d=> d.strPolicyReferenceNo.Contains(searchString));
            }

            return View(await busqueda.ToListAsync());    
        }

        // GET: Police/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPolicies = await _context.Policies
                .FirstOrDefaultAsync(m => m.strPolicyReferenceNo == id);
            if (tblPolicies == null)
            {
                return NotFound();
            }

            return View(tblPolicies);
        }

        // GET: Police/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Police/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("strPolicyReferenceNo,dtePolicyEffectiveDate,dtePolicyExpirationDate,curTotalPolicyCost,lngPayerId,dteLastUpdate,memAdditionalInfo")] tblPolicies tblPolicies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPolicies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPolicies);
        }

        // GET: Police/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPolicies = await _context.Policies.FindAsync(id);
            if (tblPolicies == null)
            {
                return NotFound();
            }
            return View(tblPolicies);
        }

        // POST: Police/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("strPolicyReferenceNo,dtePolicyEffectiveDate,dtePolicyExpirationDate,curTotalPolicyCost,lngPayerId,dteLastUpdate,memAdditionalInfo")] tblPolicies tblPolicies)
        {
            if (id != tblPolicies.strPolicyReferenceNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPolicies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblPoliciesExists(tblPolicies.strPolicyReferenceNo))
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
            return View(tblPolicies);
        }

        // GET: Police/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPolicies = await _context.Policies
                .FirstOrDefaultAsync(m => m.strPolicyReferenceNo == id);
            if (tblPolicies == null)
            {
                return NotFound();
            }

            return View(tblPolicies);
        }

        // POST: Police/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblPolicies = await _context.Policies.FindAsync(id);
            _context.Policies.Remove(tblPolicies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblPoliciesExists(string id)
        {
            return _context.Policies.Any(e => e.strPolicyReferenceNo == id);
        }
    }
}
