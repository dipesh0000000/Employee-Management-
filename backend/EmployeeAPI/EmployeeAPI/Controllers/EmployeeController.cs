using EmployeeAPI.Interface;
using EmployeeAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee empoloyee)
        {
            _employee = empoloyee;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            var list = await _employee.GetEmployee();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeModel employee)
        {
            var isSave = await _employee.AddEmployee(employee);
            return Ok(isSave);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var isDelete = await _employee.DeleteEmployee(id);
            return Ok(isDelete);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeModel employee)
        {
            var isUpdate = await _employee.UpdateEmployee(id, employee);
            return Ok(isUpdate);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeDetailById(int id)
        {
            var detail = await _employee.GetEmployeeById(id);
            return Ok(detail);
        }
    }
}
