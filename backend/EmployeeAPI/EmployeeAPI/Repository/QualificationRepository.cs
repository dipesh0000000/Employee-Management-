using EmployeeAPI.Data;
using EmployeeAPI.Entities;
using EmployeeAPI.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Repository
{
    public class QualificationRepository : IQualification
    {
        private readonly ApplicationDbContext _context;
        public QualificationRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<Qualification>> GetQualificationsList()
        {
           //sql query in the form of entity framework
           var qualificationList = await _context.Qualifications.Where(x => x.IsDeleted == false).ToListAsync();
            return qualificationList;
        }
    }
}
