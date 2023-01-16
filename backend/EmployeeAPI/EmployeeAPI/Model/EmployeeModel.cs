using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Model
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public float Salary { get; set; }
        public ICollection<EmployeeQualificationModel> Qualifications { get; set; }
    }
}
