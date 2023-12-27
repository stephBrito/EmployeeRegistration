namespace Employee.Application.UseCases
{
    public class GetEmployeeInput
    {
        public GetEmployeeInput(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
