namespace GYM_PW.Models.User
{
    using GYM_PW.Models.Ser_viceGym;
    public class Trainer
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int? Specialization { get; set; }
        public bool Active { get; set; } = true;
        public string UsersCount { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employee { get; set; }
        public ICollection<MembershipUser> MembershipUser { get; set; }
    }
}