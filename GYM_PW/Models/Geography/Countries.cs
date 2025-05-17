namespace GYM_PW.Models.Geography{

    public class Countries
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public bool Active {get; set;} = true;

        public ICollection<States> States { get; set;} = new List<States>();
    }
}