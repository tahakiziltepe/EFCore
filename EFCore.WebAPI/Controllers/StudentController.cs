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

        [HttpGet("getAllStudents")]
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

        [HttpGet("getStudentsById")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await applicationDbContext.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
            return Ok(student);
        }

        [HttpPost("createStudentWithNewAddress")]
        public async Task<IActionResult> CreateStudentWithNewAddress(
                                                string firstName, 
                                                string lastName, 
                                                int number, 
                                                DateTime birthDate,
                                                string country,
                                                string city,
                                                string district,
                                                string fullAddress
                                            )
        {
            ////StudentAddress address = new StudentAddress()
            ////{
            ////    City = "Istanbul",
            ////    Country = "Turkiye",
            ////    District = "Kadiköy",
            ////    FullAddress = "173. Sk. No: 9"
            ////};

            ////await applicationDbContext.StudentAddresses.AddAsync(address);
            ////await applicationDbContext.SaveChangesAsync();

            //Student st = new Student()
            //{
            //    FirstName = "User",
            //    LastName = "Name",
            //    Number = 1,
            //    BirthDate = DateTime.Now,

            //    //AddressId = address.Id
            //    // ---- OR
            //    Address = new StudentAddress()
            //    {
            //        City = "Istanbul",
            //        Country = "Turkiye",
            //        District = "Kadiköy",
            //        FullAddress = "173. Sk. No: 20"
            //    }
            //};

            StudentAddress studentAddress = new StudentAddress()
            {
                City = city,
                Country = country,
                District = district,
                FullAddress = fullAddress
            };

            Student st = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Number = number,
                BirthDate = birthDate,
                Address = studentAddress
            };

            try
            {
                await applicationDbContext.Students.AddAsync(st);
                await applicationDbContext.SaveChangesAsync();
                return Ok($"Created: {st.Id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpDelete("deleteStudent")]
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
                try
                {
                    applicationDbContext.Students.Remove(student);
                    await applicationDbContext.SaveChangesAsync();
                    return Ok($"Deleted: {id}");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }


        [HttpPut("updateStudentNumber")]
        public async Task<IActionResult> Update(int id, int number)
        {
            var student = await applicationDbContext.Students.FirstOrDefaultAsync(x=>x.Id == id);
            // var student = await applicationDbContext.Students.Where().SingleOrDefaultAsync();  

            if (student == null)
            {
                return NotFound($"Not Found: {id}");
            }
            else
            {
                try
                {
                    student.Number = number;
                    await applicationDbContext.SaveChangesAsync();
                    return Ok($"Updated: {id}");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                
            }
        }



    }
}
