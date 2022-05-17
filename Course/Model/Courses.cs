namespace Course.Model
{
    public class Courses
    {
        public Courses(int courseID, string courseName, int instructorId, string description, DateTime createdDate, double courseDuration,string url, int price)
        {
            CourseID = courseID;
            CourseName = courseName;
            InstructorId = instructorId;
            Description = description;
            CreatedDate = createdDate;
            CourseDuration = courseDuration;
            this.url = url;
            this.price = price;
        }

        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int InstructorId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public double CourseDuration { get; set; }=0.0;
        public string url { get; set; } = "";
        public int  price { get; set; }=0;
    }
}
