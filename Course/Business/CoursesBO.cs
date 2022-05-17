using Course.DAC;
using Course.Model;

namespace Course.Business
{
    public class CoursesBO
    {

        public CoursesBO()
        {
        }
        public string CreateCourse(Courses course)
        {
            CoursesDAC learnerDAC = new CoursesDAC();
            string res = learnerDAC.CreateCourse(course);
            return res;
        }
        public string UpdateCourseURL(int id,string url)
        {
            CoursesDAC learnerDAC = new CoursesDAC();
            string res = learnerDAC.UpdateCourseURL(id,url);
            return res;
        }
    }
}
