using Employee.Application.Shared;

namespace Employee.Application.UseCases
{
    internal sealed class UpdateEmployeeOutput
    {
        private UpdateEmployeeOutput() { }
        public Error? Error { get; private set; }

        internal static UpdateEmployeeOutput Success()
        {
            return new UpdateEmployeeOutput();
        }
    }
}
