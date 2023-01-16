using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.Entities;
using EmployeeAPI.Interface;
using EmployeeAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeRepository(ApplicationDbContext context,IMapper mapper)
        {
            _context= context;
            _mapper = mapper;
        }
        public async Task<int> AddEmployee(EmployeeModel employee)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try 
                {
                    if (employee != null)
                    {
                        Employee emp = new Employee();
                        emp.Address = employee.Address;
                        emp.Salary = employee.Salary;
                        emp.Name = employee.Name;
                        emp.CreatedDate = DateTime.UtcNow;
                        await _context.Employee.AddAsync(emp);
                        await _context.SaveChangesAsync();
                        foreach (var empQualification in employee.Qualifications)
                        {
                            var qual = new EmployeeQualification()
                            {
                                QualificationId = empQualification.QualificationId,
                                EmployeeId = emp.Id,
                                Marks = empQualification.Marks,
                                Remarks = empQualification.Remarks,
                                CreatedDate = DateTime.UtcNow,
                            };
                            await _context.EmployeeQualifications.AddAsync(qual);
                            await _context.SaveChangesAsync();
                        }
                        dbContextTransaction.Commit();
                        return emp.Id;
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<int> DeleteEmployee(int employeeId)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var employee = await _context.Employee.Where(x => x.Id == employeeId).Include(x=> x.EmployeeQualifications).FirstOrDefaultAsync();
                    employee.IsDeleted = true;
                    _context.Employee.Update(employee);
                    foreach (var qualification in employee.EmployeeQualifications)
                    {
                        qualification.IsDeleted = true;
                        _context.EmployeeQualifications.Update(qualification);
                    }
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<List<EmployeeModel>> GetEmployee()
        {
            try
            {
                var employee = await _context.Employee.Where(x=> x.IsDeleted == false).ToListAsync();
                var employeeModel = _mapper.Map<List<EmployeeModel>>(employee);
                return employeeModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EmployeeQualificationModel>> GetEmployeeById(int employeeId)
        {
            try
            {
                var Qualification = await (from qualification in _context.EmployeeQualifications
                                    where qualification.EmployeeId == employeeId
                                    join qual in _context.Qualifications
                                    on qualification.QualificationId equals qual.Id
                                    select new EmployeeQualificationModel
                                    {
                                        QualificationId     = qualification.QualificationId,
                                        QualificationName   = qual.Alias,
                                        Marks               = qualification.Marks,
                                        Remarks             = qualification.Remarks,
                                        Id                  = qualification.Id
                                    }).ToListAsync();

                return Qualification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> UpdateEmployee(int id, EmployeeModel employee)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var emp = await _context.Employee.Where(x => x.Id == id).Include(x => x.EmployeeQualifications).FirstOrDefaultAsync();
                    emp.UpdatedDate = DateTime.UtcNow;
                    emp.Name = employee.Name;
                    emp.Address = employee.Address;
                    emp.Salary = employee.Salary;
                    _context.Employee.Update(emp);
                    _context.SaveChanges();
                    _context.EmployeeQualifications.RemoveRange(_context.EmployeeQualifications.Where(x => x.EmployeeId == emp.Id).ToList());
                    foreach (var qualification in emp.EmployeeQualifications)
                    {
                        var qual = new EmployeeQualification()
                        {
                            QualificationId = qualification.Id,
                            EmployeeId = emp.Id,
                            Marks = qualification.Marks,
                            Remarks = qualification.Remarks,
                            CreatedDate = DateTime.UtcNow,
                        };
                        await _context.EmployeeQualifications.AddAsync(qual);
                        await _context.SaveChangesAsync();
                    }
                    dbContextTransaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
