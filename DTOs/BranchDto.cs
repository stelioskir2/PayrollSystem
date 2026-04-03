namespace PayrollSystem.DTOs 
{
    public class CreateBranchDto
    {
        public string Area { get; set; }
        public int CityId { get; set; }
    }

    public class BranchResponseDto
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string CityName { get; set; }
    }
}