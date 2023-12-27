using Employee.Domain.Entities;

namespace Employee.Infrastructure.Data.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> CreateEmployee(Employees employee, CancellationToken cancellation);
        Task<Employees> GetEmployee(int id, CancellationToken cancellation);
        Task<List<Employees>> GetEmployeesList(CancellationToken cancellation);
        Task<Employees> UpdateEmployee(int id, Employees employee, CancellationToken cancellation);
        Task<bool> DeleteEmployee(int key, CancellationToken cancellation);
    }
}
