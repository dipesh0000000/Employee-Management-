using EmployeeAPI.Entities;
using EmployeeAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAPI.Interface
{
    public interface IQualification
    {
        public Task<IEnumerable<QualificationModel>> GetQualificationsList();
    }
}
