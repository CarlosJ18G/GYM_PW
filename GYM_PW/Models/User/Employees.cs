public class Employee
{
    public int Id { get; set; }
    public int TypeEmployeeId { get; set; }
    public int UserId { get; set; }
    public bool Active { get; set; } = true;
    public string Title { get; set; }

    public TypeEmployee TypeEmployee { get; set; }
    public User User { get; set; }

    public ICollection<Maintenance> Maintenances { get; set; }
    // public ICollection<HeadquarterEmployee> HeadquarterEmployees { get; set; }
    public Trainer Trainer { get; set; }
}
