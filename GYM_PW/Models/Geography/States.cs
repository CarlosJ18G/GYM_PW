namespace GYM_PW.Models.Geography
{
    public class States
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;

        public Countries Country { get; set; }

        public ICollection<Cities> Cities { get; set; } = new List<Cities>();
    }
}
