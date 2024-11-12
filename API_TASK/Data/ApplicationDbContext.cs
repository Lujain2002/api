using API_TASK.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;

namespace API_TASK.Data
{
    public class ApplicationDbContext : DbContext 
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }
       
         public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

}
}
