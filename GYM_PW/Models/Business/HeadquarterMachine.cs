
namespace GYM_PW.Models.Business {
    public class HeadquarterMachine {
        public int Id { get; set; }
        public int HeadquarterId { get; set; }
        public int MachineId { get; set; }

        //public ICollection<Headquarter> Headquarter { get; set;}
        //public ICollection<Machine> Machine { get; set;}
    }
}