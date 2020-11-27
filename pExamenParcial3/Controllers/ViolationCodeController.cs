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
    public class ViolationCodeController : Controller
    {
        private readonly PoliceContext _context;

        public ViolationCodeController(PoliceContext context)
        {
            _context = context;
        }

        // GET: ViolationCode
        public async Task<IActionResult> Index()
        {
            return View(await _context.ViolationCodes.ToListAsync());
        }

        // GET: ViolationCode/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblViolationCodes = await _context.ViolationCodes
                .FirstOrDefaultAsync(m => m.strViolationCode == id);
            if (tblViolationCodes == null)
            {
                return NotFound();
            }

            return View(tblViolationCodes);
        }

        // GET: ViolationCode/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ViolationCode/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("strViolationCode,strViolationDescription,strAdditionalInfo")] tblViolationCodes tblViolationCodes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblViolationCodes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblViolationCodes);
        }

        // GET: ViolationCode/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblViolationCodes = await _context.ViolationCodes.FindAsync(id);
            if (tblViolationCodes == null)
            {
                return NotFound();
            }
            return View(tblViolationCodes);
        }

        // POST: ViolationCode/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("strViolationCode,strViolationDescription,strAdditionalInfo")] tblViolationCodes tblViolationCodes)
        {
            if (id != tblViolationCodes.strViolationCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblViolationCodes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblViolationCodesExists(tblViolationCodes.strViolationCode))
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
            return View(tblViolationCodes);
        }

        // GET: ViolationCode/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblViolationCodes = await _context.ViolationCodes
                .FirstOrDefaultAsync(m => m.strViolationCode == id);
            if (tblViolationCodes == null)
            {
                return NotFound();
            }

            return View(tblViolationCodes);
        }

        // POST: ViolationCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblViolationCodes = await _context.ViolationCodes.FindAsync(id);
            _context.ViolationCodes.Remove(tblViolationCodes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblViolationCodesExists(string id)
        {
            return _context.ViolationCodes.Any(e => e.strViolationCode == id);
        }
    }
}
