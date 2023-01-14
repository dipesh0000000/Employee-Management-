using EmployeeAPI.Entities.BaseEntity;
using System;

namespace EmployeeAPI.Entities
{
    public class Qualification : CommonEntity
    {
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}
