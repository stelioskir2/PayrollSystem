namespace PayrollSystem.DTOs 
{
    public class CreateEmployeeDto
    {
        public int RegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BranchId { get; set; }
        public int PositionId { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class UpdateEmployeeDto
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }

    public class EmployeeResponseDto
    {
        public int RegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BranchArea { get; set; }
        public string CityName { get; set; }
        public string PositionTitle { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}