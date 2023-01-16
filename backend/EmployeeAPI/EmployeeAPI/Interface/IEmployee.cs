using EmployeeAPI.Entities;
using EmployeeAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAPI.Interface
{
    public interface IEmployee
    {
        Task<int> AddEmployee(EmployeeModel employee);
        Task<int> UpdateEmployee(int employeeid, EmployeeModel employee);
        Task<int> DeleteEmployee(int employeeId);
        Task<List<EmployeeQualificationModel>> GetEmployeeById(int employeeId);
        Task<List<EmployeeModel>> GetEmployee();
    }
}
