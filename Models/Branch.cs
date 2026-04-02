public class Branch
{
    public int Id { get; set; }
    public string Area { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
}