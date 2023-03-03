using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using employeeApi.Models;
namespace employeeApi.Controller
{
    [Route("employees")]
    [ApiController]
    public class employeeController : ControllerBase
    {
        private readonly employeeContext? emp;

        public employeeController(ILogger<employeeController> logger, employeeContext context)
         {
             emp = context; }

        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return emp!.GetEmployees();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployees(Employee e)
        {
            emp!.Employees.Add(e);
            await emp.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployees),e);
        }

        //  [HttpPut]
        //  [Route("{id}")]
        // public async Task<ActionResult<Employee>> PutEmployees(int id, Employee emp1)
        // {
        //     Employee e  = emp!.Employees.Find(id)!;
        //     e.Id =emp1.Id;
        //     e.FirstName = emp1.FirstName;
        //     e.SecondName = emp1.SecondName;
        //     emp.Entry(emp1).State = EntityState.Modified();
        //     await emp.SaveChangesAsync();
        //     return CreatedAtAction(nameof(GetEmployees),e);
        // }

         [HttpDelete]
         [Route("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployees(int id)
        {
            Employee e  = emp!.Employees.Find(id)!;
            emp.Employees.Remove(e);
            await emp.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployees),e);
        }

    
    }
}