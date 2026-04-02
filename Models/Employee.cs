using System.ComponentModel.DataAnnotations;

public class Employee
{
    [Key]
    [Range(10000, 99999)]  // ← 5 digit
    public int RegistrationNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BranchId { get; set; }
    public Branch Branch { get; set; }
    public int PositionId { get; set; }
    public Position Position { get; set; }
    public decimal Salary { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}