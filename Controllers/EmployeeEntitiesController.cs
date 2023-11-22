﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeeEntitiesController : Controller
    {
        private readonly MyDbContext _context;

        public EmployeeEntitiesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeEntities
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.employees.Include(e => e.branch);
            return View(await myDbContext.ToListAsync());
        }

        // GET: EmployeeEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.employees == null)
            {
                return NotFound();
            }

            var employeeEntity = await _context.employees
                .Include(e => e.branch)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            return View(employeeEntity);
        }

        // GET: EmployeeEntities/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.branches, "Id", "Location");
            return View();
        }

        // POST: EmployeeEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Title,Salary,BranchId")] EmployeeEntity employeeEntity)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(employeeEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.branches, "Id", "Location", employeeEntity.BranchId);
            return View(employeeEntity);
        }

        // GET: EmployeeEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.employees == null)
            {
                return NotFound();
            }

            var employeeEntity = await _context.employees.FindAsync(id);
            if (employeeEntity == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.branches, "Id", "Location", employeeEntity.BranchId);
            return View(employeeEntity);
        }

        // POST: EmployeeEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Title,Salary,BranchId")] EmployeeEntity employeeEntity)
        {
            if (id != employeeEntity.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeEntityExists(employeeEntity.Id))
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
            ViewData["BranchId"] = new SelectList(_context.branches, "Id", "Location", employeeEntity.BranchId);
            return View(employeeEntity);
        }

        // GET: EmployeeEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.employees == null)
            {
                return NotFound();
            }

            var employeeEntity = await _context.employees
                .Include(e => e.branch)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            return View(employeeEntity);
        }

        // POST: EmployeeEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.employees == null)
            {
                return Problem("Entity set 'MyDbContext.employees'  is null.");
            }
            var employeeEntity = await _context.employees.FindAsync(id);
            if (employeeEntity != null)
            {
                _context.employees.Remove(employeeEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeEntityExists(int id)
        {
            return (_context.employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
