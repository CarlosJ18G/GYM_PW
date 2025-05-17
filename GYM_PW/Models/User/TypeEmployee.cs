using System.ComponentModel.DataAnnotations;
namespace GYM_PW.Models.User
{
    public class TypeEmployee
        {
            public int Id { get; set; }
            [Required, MaxLength(255)]
            public string Name { get; set; }
            public bool Active { get; set; } = true;
            public string Description { get; set; }

            public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        }
}