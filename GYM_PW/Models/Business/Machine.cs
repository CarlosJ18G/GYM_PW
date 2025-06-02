using System.ComponentModel.DataAnnotations;
namespace GYM_PW.Models.Business
{
    public class Machine
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool Active { get; set; } = true;
        public string? Status { get; set; } = "DISPONIBLE";
        public string? Description { get; set; }

        // public ICollection<MachineMuscle> MachineMuscles { get; set; }
        public ICollection<Maintenance>? Maintenances { get; set; }
        // public ICollection<HeadquarterMachine> HeadquarterMachines { get; set; }
    }

}
