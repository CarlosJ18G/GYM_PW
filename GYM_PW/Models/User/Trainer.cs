public class Trainer
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int? Specialitiation { get; set; }
    public bool Active { get; set; } = true;
    public string Users_count { get; set; }
    public string Email { get; set; }
    public string Phone_number { get; set; }
    public string Description { get; set; }

    public Employee Employee { get; set; }
    public MembershipUser MembershipUser { get; set; }
}