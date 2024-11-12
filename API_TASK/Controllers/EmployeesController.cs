using API_TASK.Data;
using API_TASK.DTOs.Employee;
using API_TASK.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TASK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Employees = context.Employees.ToList();
            var EmployeesDto = Employees.Adapt<ICollection<GetAllDto>>();
            return Ok(EmployeesDto);
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateEmployeeDto modelDto)
        {
            var model = modelDto.Adapt<Employee>();
            context.Employees.Add(model);
            context.SaveChanges();
            return Ok();

        }
        [HttpGet("FindById")]
        public IActionResult FindById(int Id)
        {
            var Employee = context.Employees.Find(Id);
            if(Employee == null)
            {
                return NotFound();
            }

            var EmployeeDto = Employee.Adapt<GetAllDto>();
            return Ok(EmployeeDto);

        }

        [HttpPut("Update")]
        public IActionResult Update(int Id,CreateEmployeeDto modelDto)
        {
            var Employee = context.Employees.Find(Id);
            if (Employee == null)
            {
                return NotFound();
            }
            Employee.Name = modelDto.Name;
            Employee.Description = modelDto.Description;
            Employee.DepartmentId = modelDto.DepartmentId;
            
            context.SaveChanges();
           
            return Ok();

        }
        [HttpDelete("Delete")]
        public IActionResult Remove(int Id)
        {
            var Employee = context.Employees.Find(Id);
            if (Employee == null)
            {
                return NotFound();
            }
            context.Employees.Remove(Employee);
            context.SaveChanges();
            return Ok();

        }


    }
}
