namespace Course.Model
{
    public class Resetpassword
    {
        public Resetpassword(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string email { get; set; }
        public string password { get; set; }
    }
}
