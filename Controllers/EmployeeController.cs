using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }
        public async Task< IActionResult> Index()
        {
            var employees = await _context.employees.ToListAsync();
            return View(employees);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                _context.employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();
            var employee = await _context.employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return NotFound();


            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return View(employee);

            }

            _context.employees.Update(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int ? id)
        {
            if (id == null || id <= 0)
                return BadRequest();
            var employee = await _context.employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return NotFound();


            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
