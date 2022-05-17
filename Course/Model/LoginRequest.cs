namespace Course.Model
{
    [Serializable]
    public class LoginRequest
    {
        public string email { get; set; } = "";
        public string usn { get; set; } = "";
        public string password { get; set; }
    }
}
