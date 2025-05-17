namespace GYM_PW.Models.Ser_viceGym
{
    using GYM_PW.Models.User;
    public class MembershipUser
        {
            public int Id { get; set; }
            public int MembershipId { get; set; }
            public int UserId { get; set; }
            public int? HeadquarterId { get; set; }
            public DateTime InitialDate { get; set; } = DateTime.Now;
            public int CutDay { get; set; } = 1;

            public Membership Membership { get; set; }
            public User User { get; set; }

            // public Headquarter Headquarter { get; set; }
        }
}