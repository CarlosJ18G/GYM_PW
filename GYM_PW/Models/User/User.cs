using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }
    [Required, MaxLength(12)]
    public string Document { get; set; }
    [Required, MaxLength(100)]
    public string Fullname { get; set; }
    [Required, EmailAddress, MaxLength(255)]
    public string Email { get; set; }
    [Required]
    public decimal PhoneNumber { get; set; }
    public bool Active { get; set; } = true;
    [Required, MaxLength(255)]
    public string Password { get; set; }

// is an interface in the .NET framework, found in the System.Collections or System.Collections.Generic namespaces. It defines a standard set of methods and properties for working with collections of objects, such as adding, removing, and counting items.

// When you see ICollection in code, it usually means the developer wants to represent a group of objects without specifying the exact type of collection (like a List, HashSet, or Array). This abstraction allows for more flexible and testable code, since any class that implements ICollection can be used interchangeably.

// In most modern C# code, you'll often see ICollection<T>, the generic version, which provides type safety by specifying the type of objects the collection holds (for example, ICollection<User>). Using interfaces like ICollection is a best practice in object-oriented programming because it encourages loose coupling and makes code easier to maintain and extend.
    public ICollection<Employee> Employees { get; set; }
    public ICollection<MembershipUser> MembershipUsers { get; set; }
    // public ICollection<PaymentDetail> PaymentDetails { get; set; }
    // public ICollection<TrainerUser> TrainerUsers { get; set; }
    // public ICollection<Routine> Routines { get; set; }
}
