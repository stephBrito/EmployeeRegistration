using Employee.Application.Extension;
using Employee.Domain.Entities;
using Employee.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Logging;

namespace Employee.Application.UseCases.Employee
{
    public class EmployeeUseCase : IEmployeeUseCase
    {
        private readonly ILogger<EmployeeUseCase> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeUseCase(ILogger<EmployeeUseCase> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public async Task CreateAsync(CreateEmployeeInput input, CancellationToken cancellationToken)
        {
            var emp = new Employees{ 
                Name = input.Name,
                Address = input.Address,
                Age = input.Age,
                EmergencyContact = input.EmergencyContact,
                MobileNumber = input.MobileNumber,
            };
           await _employeeRepository.CreateEmployee(emp, cancellationToken);
           
            _logger.LogUseCaseSuccess(nameof(EmployeeUseCase), Guid.NewGuid());
        }
        public async Task<Employees> GetAsync(GetEmployeeInput input, CancellationToken cancellationToken)
        {
           var result = await _employeeRepository.GetEmployee(input.Id, cancellationToken);
            _logger.LogUseCaseSuccess(nameof(EmployeeUseCase), Guid.NewGuid());

            return result;
        }
        public async Task<List<Employees>> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _employeeRepository.GetEmployeesList(cancellationToken);
            _logger.LogUseCaseSuccess(nameof(EmployeeUseCase), Guid.NewGuid());

            return response;
        }
        public async Task<Employees> UpdateAsync(int id, UpdateEmployeeInput input, CancellationToken cancellationToken)
        {
            var emp = new Employees
            {
                Name = input.Name,
                Address = input.Address,
                Age = input.Age,
                EmergencyContact = input.EmergencyContact,
                MobileNumber = input.MobileNumber,
            };

            var response = await _employeeRepository.UpdateEmployee(id, emp, cancellationToken);
            _logger.LogUseCaseSuccess(nameof(EmployeeUseCase), Guid.NewGuid());

            return response;
        }
        public async Task<bool> DeleteAsync(DeleteEmployeeInput input, CancellationToken cancellationToken)
        {
            var response = await _employeeRepository.DeleteEmployee(input.Id, cancellationToken);
            _logger.LogUseCaseSuccess(nameof(EmployeeUseCase), Guid.NewGuid());

            return response;
        }
    }
}
