using EmployeeAPI.Entities.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Entities
{
    public class EmployeeQualification : CommonEntity
    {
        public int QualificationId { get; set; }
        [ForeignKey("QualificationId")]
        public Qualification Qualification { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }  
        public float Marks { get; set; }
        public string Remarks { get; set; }
    }
}
