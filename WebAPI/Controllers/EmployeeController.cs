using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.data;
using WebAPI.Models;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext; // creating context for the database so we can use it to make connection with database and execute quries
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // get request for getting all employees

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = dbContext.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto dto)
        {
            var employee = new Employee()
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Salary = dto.Salary
            };

            Console.WriteLine(employee);

            dbContext.Employees.Add(employee);
            dbContext.SaveChanges(); // this will save the changes in database
            return Ok(employee);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult updateEmployee(Guid id, UpdateEmployeeDto dto)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(dto.Name))
            {
                employee.Name = dto.Name;
            }

            if (!string.IsNullOrEmpty(dto.Email))
            {
                employee.Email = dto.Email;
            }

            if (!string.IsNullOrEmpty(dto.Phone))
            {
                employee.Phone = dto.Phone;
            }

            if(dto.Salary != 0)
            {
                employee.Salary = dto.Salary;
            }

            dbContext.Employees.Update(employee);
            dbContext.SaveChanges();

            return Ok(employee);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult deleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id); if (employee == null)
            {
                return NotFound();
            }
            var message = "Employee deleted";
            return Ok(message);
        }
    }
}
