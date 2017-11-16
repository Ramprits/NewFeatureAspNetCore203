using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewFeatureApplication.Models;

namespace NewFeatureApplication.Repository {
    public interface IDepartmentRepository {

        Task<IEnumerable<Department>> GetDepartmentsAsync ();
        Task<Department> GetDepartmentAsync (Guid id);
        Task<Department> InsertDepartmentAsync (Department entity);
        Task<bool> UpdateDepartmentAsync (Department entity);
        Task<bool> DeleteDepartmentAsync (Guid id);
        Task<bool> SaveAsync ();
    }
}