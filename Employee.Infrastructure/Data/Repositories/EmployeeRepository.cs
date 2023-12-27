using Employee.Domain.Entities;
using Employee.Infrastructure.Data.Services;

namespace Employee.Infrastructure.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbService _dbService;

        public EmployeeRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateEmployee(Employees employee, CancellationToken cancellation)
        {
            try
            {
                var response =
                await _dbService.EditData(
                    "INSERT INTO public.employee (name, age, address, mobile_number, mobile_number_emergency_contact) " +
                    "VALUES (@Name, @Age, @Address, @MobileNumber, @EmergencyContact)",
                    employee);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }
            return true;
        }

        public async Task<List<Employees>> GetEmployeesList(CancellationToken cancellation)
        {
            var employeeList = new List<Employees>();

            try
            {
                employeeList = await _dbService.GetAll<Employees>("SELECT * FROM public.employee", new { });
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }
            
            return employeeList;
        }


        public async Task<Employees> GetEmployee(int id, CancellationToken cancellation)
        {
            var employee = new Employees();

            try
            {
                employee = await _dbService.GetAsync<Employees>("SELECT employee_id, name, age, address, mobile_number, mobile_number_emergency_contact " +
                    "FROM public.employee " +
                    "WHERE employee_id=@Id", new { id });
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }
            
            return employee;
        }

        public async Task<Employees> UpdateEmployee(int id, Employees employeeUpdateInput, CancellationToken cancellation)
        {
            var employeeExists = await GetEmployee(id, cancellation);

            var employee = new Employees
            {
                Name = employeeUpdateInput.Name,
                Age = employeeUpdateInput.Age,
                Address = employeeUpdateInput.Address,
                MobileNumber = employeeUpdateInput.MobileNumber,
                EmergencyContact = employeeUpdateInput.EmergencyContact
            };

            if (employeeExists != null)
            {
                try
                {
                    var updateEmployee =
                            await _dbService.EditData(
                                          "Update public.employee " +
                                          "SET name=@Name, age=@Age, address=@Address, mobile_number=@MobileNumber, " +
                                          "mobile_number_emergency_contact=@EmergencyContact " +
                                          "WHERE employee_id=" + id + "",
                                    employee);
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message.ToString());
                }

                return employee;
            }

            return employee;
        }

        public async Task<bool> DeleteEmployee(int id, CancellationToken cancellation)
        {
            try
            {
                var employeeRemoveDb = await _dbService.EditData("DELETE FROM public.employee WHERE employee_id=@Id", new { id });
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }
            
            return true;
        }
    }
}