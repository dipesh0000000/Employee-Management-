using EmployeeAPI.Entities.BaseEntity;
using System.Collections.Generic;

namespace EmployeeAPI.Entities
{
    public class Employee : CommonEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public float Salary { get; set; }
        public ICollection<EmployeeQualification> EmployeeQualifications { get; set; }  
    }
}
