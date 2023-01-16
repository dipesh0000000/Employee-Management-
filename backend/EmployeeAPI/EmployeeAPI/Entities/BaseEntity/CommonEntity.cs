using System;

namespace EmployeeAPI.Entities.BaseEntity
{
    public abstract class CommonEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set;}
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
        public Boolean IsDeleted { get; set; } = false;

    }
}
