

namespace GYM_PW.Models.User {
    using GYM_PW.Models.Geography;
    public class HeadquarterEmployee{
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int HeadquarterId { get; set; }

        public ICollection<Employee> Employee { get; set; }
        public ICollection<Headquarter> Headquarter { get; set; }
    }
}