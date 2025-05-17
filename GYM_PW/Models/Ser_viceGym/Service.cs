using GYM_PW.Models.Geography;
using System.ComponentModel.DataAnnotations;

namespace GYM_PW.Models.Ser_viceGym
{
    public class Service
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public float Amount { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        public DateTime ModifiedAt{ get; set; }
        public bool Active { get; set; } = true;

        public ICollection<MembershipService> MembershipServices { get; set; } = new List<MembershipService>();
    }
}
