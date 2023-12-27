using Employee.Application.Shared;

namespace Employee.Application.UseCases
{
    internal sealed class CreateEmployeeOutput
    {
        private CreateEmployeeOutput(Error error = default) {
            Error = error;
            HasFailed = !string.IsNullOrWhiteSpace(Error.ErrorMessage);
        }
        public Error Error { get; private set; }
        public bool HasFailed { get; private set; }
        internal static CreateEmployeeOutput Fail(Error error)
        {
            return new CreateEmployeeOutput(error);
        }

        internal static CreateEmployeeOutput Success()
        {
            return new CreateEmployeeOutput();
        }
    }
}
