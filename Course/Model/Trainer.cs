using System.ComponentModel.DataAnnotations;

namespace Course.Model
{
    public class Trainer
    {
        public Trainer(int id, string name, string specialization1, string specialization2, string specialization3, DateTime dateOfJoining, int expirience, string email,string password, string phone,DateTime createdate)
        {
            Id = id;
            Name = name;
            Specialization1 = specialization1;
            Specialization2 = specialization2;
            Specialization3 = specialization3;
            DateOfJoining = dateOfJoining;
            Expirience = expirience;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.createdate = createdate;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization1 { get; set; }
        public string Specialization2 { get; set; }
        public string Specialization3 { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int Expirience { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public DateTime createdate { get; set; }

    }
}
