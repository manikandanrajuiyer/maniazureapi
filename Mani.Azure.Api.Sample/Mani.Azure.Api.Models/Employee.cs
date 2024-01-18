namespace Mani.Azure.Api.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Address { get; set; }

        public string? State { get; set; }
        
    }
}