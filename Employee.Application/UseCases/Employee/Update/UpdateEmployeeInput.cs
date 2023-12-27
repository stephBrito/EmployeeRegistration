using System.Net;

namespace Employee.Application.UseCases
{
    public sealed class UpdateEmployeeInput
    {
        public UpdateEmployeeInput(string name, int age, string address, string mobileNumber, string?
            emergencyContact)
        {
            Name = name;
            Age = age;
            Address = address;
            MobileNumber = mobileNumber;
            EmergencyContact = emergencyContact;
        }
        public string Name { get; }
        public int Age { get; }
        public string Address { get; }
        public string MobileNumber { get; }
        public string? EmergencyContact { get; }
    }
}
