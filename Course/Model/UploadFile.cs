namespace Course.Model
{
    public class UploadFile
    {
        public int id { get; set; }
        public List<IFormFile> file { get; set; }
        public string name { get; set; }
    }
}
