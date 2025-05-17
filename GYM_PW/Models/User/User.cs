using System.ComponentModel.DataAnnotations;
namespace GYM_PW.Models.User
{

    using GYM_PW.Models.Ser_viceGym;
    // using GYM_PW.Models.Bill;
    public class User
        {
            public int Id { get; set; }
            [Required, MaxLength(12)]
            public string Document { get; set; }
            [Required, MaxLength(100)]
            public string Fullname { get; set; }
            [Required, MaxLength(255)]
            public string Email { get; set; }
            [EmailAddress, Required]
            public string PhoneNumber { get; set; }
            public bool Active { get; set; } = true;
            [Required, MaxLength(255)]
            public string Password { get; set; }

        // is an interface in the .NET framework, found in the System.Collections or System.Collections.Generic namespaces. It defines a standard set of methods and properties for working with collections of objects, such as adding, removing, and counting items.

        // When you see ICollection in code, it usually means the developer wants to represent a group of objects without specifying the exact type of collection (like a List, HashSet, or Array). This abstraction allows for more flexible and testable code, since any class that implements ICollection can be used interchangeably.

        // In most modern C# code, you'll often see ICollection<T>, the generic version, which provides type safety by specifying the type of objects the collection holds (for example, ICollection<User>). Using interfaces like ICollection is a best practice in object-oriented programming because it encourages loose coupling and makes code easier to maintain and extend.
            public ICollection<Employee> Employee { get; set; } = new List<Employee>();
            public ICollection<MembershipUser> MembershipUsers { get; set; } = new List<MembershipUser>();
            // public ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
            // public ICollection<TrainerUser> TrainerUsers { get; set; } = new List<TrainerUser>();
            // public ICollection<Routine> Routines { get; set; }
    }
}