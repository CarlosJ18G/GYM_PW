namespace GestionMaquinas.Models.Entities
{
    public class Machine
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Quantity{ get; set; }
        public required bool Active { get; set; } = true;
        public required string? Description { get; set; }
        public required string? Status { get; set; }

    }
}
