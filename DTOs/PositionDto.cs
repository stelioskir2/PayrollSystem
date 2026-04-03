namespace PayrollSystem.DTOs 
{
    public class CreatePositionDto
    {
        public string Title { get; set; }
    }

    public class UpdatePositionDto
    {
        public string Title { get; set; }
    }

    public class PositionResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}