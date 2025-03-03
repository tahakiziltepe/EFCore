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
            var allStudents = await applicationDbContext.Students.ToListAsync();

            //var idFilter = await applicationDbContext.Students
            //                        .Where(x => x.Id == 25 && x.FirstName != "NetUser")
            //                        .Where(x => x.Number == 1)
            //                        .OrderByDescending(x => x.BirthDate)
            //                        .Select(x => new { x.FirstName, x.LastName })
            //                        .ToListAsync();

            // ---- OR

            //var students = applicationDbContext.Students.AsQueryable();
            //students.Where(x => x.Id == 25 && x.FirstName != "NetUser");

            return Ok(allStudents);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            //StudentAddress address = new StudentAddress()
            //{
            //    City = "Istanbul",
            //    Country = "Turkiye",
            //    District = "Kadiköy",
            //    FullAddress = "173. Sk. No: 9"
            //};

            //await applicationDbContext.StudentAddresses.AddAsync(address);
            //await applicationDbContext.SaveChangesAsync();

            Student st = new Student()
            {
                FirstName = "User",
                LastName = "Name",
                Number = 1,
                BirthDate = DateTime.Now,

                //AddressId = address.Id
                // ---- OR
                Address = new StudentAddress()
                {
                    City = "Istanbul",
                    Country = "Turkiye",
                    District = "Kadiköy",
                    FullAddress = "173. Sk. No: 20"
                }
            };

            await applicationDbContext.Students.AddAsync(st);
            await applicationDbContext.SaveChangesAsync();
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // var student = await applicationDbContext.Students.FindAsync(id);
            var student = await applicationDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            // var student = await applicationDbContext.Students.Where(x => x.Id == id).SingleOrDefaultAsync();  

            if (student == null)
            {
                return NotFound($"Not Found: {id}");
            }
            else
            {
                applicationDbContext.Students.Remove(student);
                await applicationDbContext.SaveChangesAsync();
                return Ok();
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var student = await applicationDbContext.Students.FirstOrDefaultAsync(x=>x.Id == id);
            // var student = await applicationDbContext.Students.Where().SingleOrDefaultAsync();  

            student.BirthDate = DateTime.Now;

            await applicationDbContext.SaveChangesAsync();

            return Ok();
        }



    }
}
