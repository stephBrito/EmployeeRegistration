using Employee.Application.UseCases;
using Employee.Application.UseCases.Employee;
using Employee.WebAPI.Controllers.Employees.Request;
using Employee.WebAPI.Controllers.Employees.Response;
using Microsoft.AspNetCore.Mvc;

namespace Employee.WebAPI.Controllers.Employees
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeUseCase _employeeUseCase;

        public EmployeeController(IEmployeeUseCase employeeUseCase)
        {
            _employeeUseCase = employeeUseCase;
        }

        [HttpPost(Name = nameof(CreateEmployeeAsync))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] EmployeeRequest request,
           CancellationToken cancellationToken)
        {
            try
            {
                await _employeeUseCase.CreateAsync(new CreateEmployeeInput(request.Name,
                                                       request.Age,
                                                       request.Address,
                                                       request.MobileNumber,
                                                       request.EmergencyContact), cancellationToken);

                return StatusCode(StatusCodes.Status201Created, "Funcionário adicionado com sucesso!");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }
        }

        [HttpGet(Name = nameof(GetEmployeeAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployeeAsync([FromHeader] int id,
           CancellationToken cancellationToken)
        {
            try
            {
                var result = await _employeeUseCase.GetAsync(new GetEmployeeInput(id), cancellationToken);

                var mapToResponse = new EmployeeResponse
                {
                    Name = result.Name,
                    Age = result.Age,
                    Address = result.Address,
                    MobileNumber = result.MobileNumber,
                    EmergencyContact = result.EmergencyContact
                };

                return Ok(mapToResponse);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }
        }
        [HttpPut(Name = nameof(UpdateEmployeeAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEmployeeAsync([FromHeader]int id, [FromBody] EmployeeRequest request,
          CancellationToken cancellationToken)
        {
            try
            {
                var result = await _employeeUseCase.UpdateAsync(id, new UpdateEmployeeInput(request.Name,
                                                               request.Age,
                                                               request.Address,
                                                               request.MobileNumber,
                                                               request.EmergencyContact), cancellationToken);

                var mapToResponse = new EmployeeResponse
                {
                    Name = result.Name,
                    Age = result.Age,
                    Address = result.Address,
                    MobileNumber = result.MobileNumber,
                    EmergencyContact = result.EmergencyContact
                };

                return Ok(mapToResponse);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }           
        }
        [HttpDelete(Name = nameof(DeleteEmployeeAsync))]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmployeeAsync([FromHeader] int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _employeeUseCase.DeleteAsync(new DeleteEmployeeInput(id), cancellationToken);

                return Accepted(result);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }
        }
    }
}
