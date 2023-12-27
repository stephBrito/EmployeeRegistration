using Employee.Application.Shared;

namespace Employee.Application.UseCases
{
    internal sealed class GetEmployeeOutput
    {
        private GetEmployeeOutput() { }
        public Error? Error { get; private set; }

        internal static GetEmployeeOutput Success()
        {
            return new GetEmployeeOutput();
        }
    }
}
