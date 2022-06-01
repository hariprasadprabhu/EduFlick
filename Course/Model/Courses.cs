namespace Course.Model
{
    public class Courses
    {
        public Courses(int courseID, string courseName, int instructorId, string description, DateTime createdDate,int CourseDuration, string url, string thumnail,  string[] topics)
        {
            CourseID = courseID;
            CourseName = courseName;
            InstructorId = instructorId;
            Description = description;
            CreatedDate = createdDate;
            this.CourseDuration = CourseDuration;
            this.url = url;
            this.thumbnail = thumnail;
            this.topics = topics;
        }

        public Courses()
        {

        }

        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int InstructorId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int CourseDuration { get; set; }=0;
        public string url { get; set; } = "";
        public string thumbnail { get; set; } = "";
        public string[] topics { get; set; }


    }
}
