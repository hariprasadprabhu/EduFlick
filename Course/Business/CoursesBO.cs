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
        public bool AddQuiz(Quiz[] quiz,int courseId)
        {
            CoursesDAC learnerDAC = new CoursesDAC();
            try
            {
                foreach (Quiz quizItem in quiz)
                {
                    learnerDAC.AddQuiz(quizItem, courseId);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
