using System.ComponentModel.DataAnnotations;

namespace Course.Model
{
    public class Learner
    {
        public Learner(int id, string name, string email,string usn, string username,string password, DateTime dob, string specialization, int semister)
        {
            Id = id;
            Name = name;
            this.Email = email;
            USN = usn;
            this.Username = username;
            this.Password = password;
            Dob = dob;
            Specialization = specialization;
            Semister = semister;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string USN { get; set; }
        public string Username { get; set; } = "None";
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Specialization { get; set; }
        public int Semister { get; set; }
    }
}
