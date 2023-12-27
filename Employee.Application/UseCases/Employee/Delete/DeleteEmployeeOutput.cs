using Employee.Application.Shared;

namespace Employee.Application.UseCases
{
    internal sealed class DeleteEmployeeOutput
    {
        private DeleteEmployeeOutput()
        {
       
        }
        public Error? Error { get; private set; }

        internal static DeleteEmployeeOutput Success()
        {
            return new DeleteEmployeeOutput();
        }
    }
}
