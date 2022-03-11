using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Jquery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManager.Jquery.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly AppDbContext db = null;

        public CountriesController(AppDbContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public async Task<List<Country>> GetAsync()
        {
            List<Country> countries = await db.Countries.ToListAsync();
            return countries;
        }
    }
}
