namespace GYM_PW.Models.Geography
{
    public class Cities
    {
        public int Id { get; set;}
        public int StateId { get; set;}
        public string Name { get; set;}
        public bool Active { get; set;} =true;
        public States State { get; set;}
        public ICollection<Headquarters> Headquarters { get; set; } = new List<Headquarters>();
    }
}