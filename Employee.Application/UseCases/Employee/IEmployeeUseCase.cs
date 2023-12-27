using Employee.Domain.Entities;

namespace Employee.Application.UseCases.Employee
{
    public interface IEmployeeUseCase
    {
        Task CreateAsync(CreateEmployeeInput input, CancellationToken cancellationToken);

        Task<Employees>GetAsync(GetEmployeeInput input, CancellationToken cancellationToken);

        Task<List<Employees>> GetAllAsync(CancellationToken cancellationToken);

        Task<Employees> UpdateAsync(int id, UpdateEmployeeInput input, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(DeleteEmployeeInput input, CancellationToken cancellationToken);
        
    }
}
