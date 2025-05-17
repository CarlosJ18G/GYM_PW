using System.ComponentModel.DataAnnotations;

public class Membership
{
    public int Id { get; set; }
    [Required, MaxLength(255)]
    public string Name { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public int Period { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? ModifiedAt { get; set; }
    public bool Active { get; set; } = true;
    [Required]
    public string Description { get; set; }

    public ICollection<MembershipUser> MembershipUsers { get; set; }
    // public ICollection<MembershipService> MembershipServices { get; set; }
}
