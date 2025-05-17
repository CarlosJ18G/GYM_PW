namespace GYM_PW.Models.Geography
{
    public class Headquarters
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public Cities City { get; set; }
    }
}