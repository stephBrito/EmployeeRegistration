using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Employee.WebAPI.Controllers.Employees.Request
{
    public class EmployeeRequest
    {
        [Required]
        [NotNull]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [NotNull]
        public string Address { get; set; }
        [Required]
        [NotNull]
        public string MobileNumber { get; set; }
        public string? EmergencyContact { get; set; }
    }
}
