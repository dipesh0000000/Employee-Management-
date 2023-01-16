using EmployeeAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Model
{
    public class EmployeeQualificationModel
    {
        [Required]
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        [Required]
        public float Marks { get; set; }
        [Required]
        public string Remarks { get; set; }
        public int Id { get; set; } 
    }
}
