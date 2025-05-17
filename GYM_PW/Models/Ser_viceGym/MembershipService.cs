

namespace GYM_PW.Models.Ser_viceGym{

    public class MembershipService {
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public int ServiceId { get; set; }

        public Membership Membership { get; set; }
        public Service Service { get; set; }

    }
}