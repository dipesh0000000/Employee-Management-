using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.Entities;
using EmployeeAPI.Interface;
using EmployeeAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Repository
{
    public class QualificationRepository : IQualification
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public QualificationRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<QualificationModel>> GetQualificationsList()
        {
           //sql query in the form of entity framework
            var qualificationList = await _context.Qualifications.Where(x => x.IsDeleted == false).ToListAsync();
            var qualificationViewModel = _mapper.Map<List<QualificationModel>>(qualificationList);
            return qualificationViewModel;
        }
    }
}
