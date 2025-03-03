using EFCore.Data.Context;
using EFCore.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentController(ApplicationDbContext applicationDbContext) 
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await applicationDbContext.Students.ToListAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            StudentAddress address = new StudentAddress()
            {
                City = "Istanbul",
                Country = "Turkiye",
                District = "Kadiköy",
                FullAddress = "173. Sk. No: 9"
            };

            await applicationDbContext.StudentAddresses.AddAsync(address);
            await applicationDbContext.SaveChangesAsync();

            Student st = new Student()
            {
                FirstName = "Taha",
                LastName = "Kiziltepe",
                Number = 1,
                AddressId = address.Id
            };

            await applicationDbContext.Students.AddAsync(st);
            await applicationDbContext.SaveChangesAsync();
            
            return Ok();
        }


    }
}
