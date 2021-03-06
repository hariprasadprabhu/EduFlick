using Course.DAC;
using Course.Model;
using Course.Model.RequestResponse;

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
        public string UpdateCourseURL(int id, string url,string thumbnail)
        {
            CoursesDAC learnerDAC = new CoursesDAC();
            string res = learnerDAC.UpdateCourseURL(id, url,thumbnail);
            return res;
        }
        public Courses[] GetCourses(int trainerId)
        {
            CoursesDAC cd = new CoursesDAC();
            return cd.GetCourses(trainerId);
        }
        public Courses[] GetSubscribedCourses(int learnerId)
        {
            CoursesDAC cd = new CoursesDAC();
            return cd.GetSubscribedCourses(learnerId);
        }
        public Trainers[] SearchTrainer(string searchElement,int learnerId)
        {
            CoursesDAC cd = new CoursesDAC();
            return cd.SearchTrainerWithSearchElement(searchElement, learnerId);
        }
        public Courses[] GetCompletedCourses(int learnerId)
        {
            CoursesDAC cd = new CoursesDAC();
            return cd.GetCompletedCourses(learnerId);
        }
        public bool AddQuiz(Quiz[] quiz, int courseId)
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
        public bool UpdateCompleteionStatus(int courseId, int learnerId, string score)
        {
            CoursesDAC learnerDAC = new CoursesDAC();
            try
            {
                learnerDAC.UpdateCourseCompletion(courseId, learnerId, score);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public Quiz[] GetQuiz(int courseId)
        {
            CoursesDAC cd = new CoursesDAC();
            return cd.GetQuiz(courseId);
        }
    }
}
