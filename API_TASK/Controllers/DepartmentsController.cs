using API_TASK.Data;
using API_TASK.DTOs.Department;
using API_TASK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TASK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DepartmentsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Departments = context.Departments.Select(
                x => new GetAllDto()
                {
                    Name = x.Name,
                    Id = x.Id,
                });
                
            return Ok(Departments);
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateDepartmentDto dtomodel)
        {
            var Department = new Department()
            {
                Name = dtomodel.Name,
            };
            context.Departments.Add(Department);
            context.SaveChanges();
            return Ok(Department);

        }
        [HttpGet("FindById")]
        public IActionResult FindById(int Id)
        {
            var Department = context.Departments.Find(Id);
            if (Department == null)
            {
                return NotFound();
            }
            GetAllDto dept = new GetAllDto()
            {
                Id = Department.Id,
                Name = Department.Name,
            };
            return Ok(dept);

        }

        [HttpPut("Update")]
        public IActionResult Update(int Id, CreateDepartmentDto dtomodel)
        {
            var department = context.Departments.Find(Id);
            if (department == null)
            {
                return NotFound();
            }
            department.Name = dtomodel.Name;
            
            
            context.SaveChanges();
            GetAllDto dept = new GetAllDto()
            {
                Id = department.Id,
                Name = department.Name,
            };
            return Ok(dept);

        }
        [HttpDelete("Delete")]
        public IActionResult Remove(int Id)
        {
            var department = context.Departments.Find(Id);
            if (department == null)
            {
                return NotFound();
            }
            context.Departments.Remove(department);
            context.SaveChanges();
            return Ok();

        }
    }
}
