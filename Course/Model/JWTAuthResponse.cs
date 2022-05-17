namespace Course.Model
{
    public class JWTAuthResponse
    {
        public string token { get; set; }
        public string email { get; set; }
        public int expiresIn { get; set; }
        public string error { get; set; }
        public Trainer trainer { get; set; }
        public Learner learner { get; set; }
        public int userId { get; set; }
    }
}
