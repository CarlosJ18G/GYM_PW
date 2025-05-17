using System.ComponentModel.DataAnnotations;

public class TypeEmployee
{
    public int Id { get; set; }
    [Required, MaxLength(255)]
    public string Name { get; set; }
    public bool Active { get; set; } = true;
    public string Description { get; set; }

    public ICollection<Employee> Employees { get; set; }
}