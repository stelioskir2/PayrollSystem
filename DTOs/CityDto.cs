namespace PayrollSystem.DTOs 
{
    public class CreateCityDto
    {
        public string Name { get; set; }
    }

    public class CityResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}