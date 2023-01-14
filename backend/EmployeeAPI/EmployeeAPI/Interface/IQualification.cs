using EmployeeAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAPI.Interface
{
    public interface IQualification
    {
        public Task<IEnumerable<Qualification>> GetQualificationsList();
    }
}
