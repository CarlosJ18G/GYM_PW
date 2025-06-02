using GYM_PW.Models.Business;
public class Maintenance
{
    public int Id { get; set; }
    public int MachineId { get; set; }
    public DateTime MaintenanceDate { get; set; } = DateTime.Now;
    public int EmployeeId { get; set; }
    public string Observations { get; set; }

    public ICollection<Machine> Machine { get; set; }
    // public ICollection<Employee> Employee { get; set; }
}
