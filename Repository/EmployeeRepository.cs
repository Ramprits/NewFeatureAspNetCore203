using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewFeatureApplication.Infrastructure;
using NewFeatureApplication.Models;

namespace NewFeatureApplication.Repository {
    public class EmployeeRepository : IEmployeeRepository {
        private readonly NewApplicationDbContext _context;
        private readonly ILogger _Logger;

        public EmployeeRepository (NewApplicationDbContext context, ILoggerFactory loggerFactory) {
            _context = context;
            _Logger = loggerFactory.CreateLogger ("EmployeeRepository");
        }
        public async Task<bool> DeleteEmployeeAsync (Guid id) {
            var deleteEmployee = await _context.Employees.FirstOrDefaultAsync (x => x.EmployeeId == id);
            _context.Remove (deleteEmployee);
            try {
                return (await _context.SaveChangesAsync () > 0 ? true : false);
            } catch (System.Exception exp) {
                _Logger.LogError ($"Error in {nameof(DeleteEmployeeAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> EmployeeExist (Guid id) {
            return await _context.Employees.AnyAsync (x => x.EmployeeId == id);
        }

        public Task<Employee> GetEmployeeAsync (Guid id) {
            throw new NotImplementedException ();
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync () {
            return await _context.Employees.Include (x => x.Department).ToListAsync ();
        }
        public async Task<Employee> InsertEmployeeAsync (Employee entity) {
            await _context.Employees.AddAsync (entity);
            try {
                await _context.SaveChangesAsync ();
            } catch (System.Exception exp) {
                _Logger.LogError ($"Error in {nameof(InsertEmployeeAsync)}: " + exp.Message);
            }

            return entity;
        }

        public async Task<bool> SaveAsync () {
            return (await _context.SaveChangesAsync () >= 0);
        }

        public Task<bool> UpdateEmployeeAsync (Employee entity) {
            throw new NotImplementedException ();
        }
    }
}