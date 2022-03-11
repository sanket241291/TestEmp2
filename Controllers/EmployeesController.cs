﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Jquery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManager.Jquery.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Manager")]
    public class EmployeesController : Controller
    {
        private AppDbContext db = null;

        public EmployeesController(AppDbContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            List<Employee> data = await db.Employees.ToListAsync();
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            Employee emp = await db.Employees.FindAsync(id);
            return Ok(emp);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Employee emp)
        {
            if (ModelState.IsValid)
            {
                await db.Employees.AddAsync(emp);
                await db.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = emp.EmployeeID }, emp);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Update(emp);
                await db.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Employee emp = await db.Employees.FindAsync(id);
            db.Employees.Remove(emp);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
