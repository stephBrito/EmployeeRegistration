using Employee.Application.Shared;

namespace Employee.Application.UseCases.Employee.GetAll
{
    internal sealed class GetEmployeesOutput
    {
        private GetEmployeesOutput() { }
        public Error? Error { get; private set; }

        internal static GetEmployeesOutput Success()
        {
            return new GetEmployeesOutput();
        }
    }
}
