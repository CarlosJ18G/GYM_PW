using System.ComponentModel.DataAnnotations;
public class Maquine
{
    public int Id { get; set; }
    [Required, MaxLength(255)]
    public string Name { get; set; }
    public int Quantity { get; set; } = 1;
    public bool Active { get; set; } = true;
    public string Status { get; set; } = "DISPONIBLE";
    public string Description { get; set; }

    // public ICollection<MachineMuscle> MachineMuscles { get; set; }
    public ICollection<Maintenance> Maintenances { get; set; }
    // public ICollection<HeadquarterMachine> HeadquarterMachines { get; set; }
}
