using System.Collections;
using IndigyBackendTestAPI.Infrastructure.Db;
namespace IndigyBackendTestAPI.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepositories
    {
        Task<List<Domain.Entities.Employee>> GetAllAsync(int pageNumber = 1, int pageSize = 0);
        Task<Domain.Entities.Employee> GetByIdAsync(int id);
        Task AddAsync(Domain.Entities.Employee employee);
        Task UpdateAsync(Domain.Entities.Employee employee);
        Task DeleteAsync(int Id);
        string GenerateNextEmpNo();
    }
}
