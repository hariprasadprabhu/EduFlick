using Course.Model;
using Course.Model.RequestResponse;
using System.Data;
using System.Data.SqlClient;

namespace Course.DAC
{
    public class CoursesDAC
    {
        public string conString = "";
        public CoursesDAC()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            this.conString = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public Courses[] GetCourses(int trainedId)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetCoursebyTrainerID", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@trainerId", trainedId));
                        con.Open();
                        string res = "";
                        DataTable dt = new DataTable();

                        try
                        {
                            da.Fill(dt);
                            Courses[] courses = new Courses[dt.Rows.Count];
                            if (dt.Rows.Count == 0)
                            {
                                return null;
                            }
                            else
                            {
                                int i = 0;
                                foreach (DataRow dr in dt.Rows)
                                {
                                    courses[i++] = new Courses(int.Parse(dr["id"].ToString()), dr["coursename"].ToString(), int.Parse(dr["instructorId"].ToString()), dr["description"].ToString(), DateTime.Parse(dr["createdate"].ToString()), dr["url"].ToString(), dr["thumbnail"].ToString(), (dr["topics"].ToString()).Split(',').ToArray()); 
                                }
                                return courses;
                            }
                        }
                        catch (Exception ex)
                        {
                            //handle errors
                        }
                        finally
                        {
                            con.Close();
                        }
                        return null;
                    }
                }
            }

        }

        public Trainers[] SearchTrainerWithSearchElement(string searchElement,int learnerId)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_SearchTrainer", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@searchelement", searchElement));
                        cmd.Parameters.Add(new SqlParameter("@learnerId", learnerId));
                        con.Open();
                        string res = "";
                        DataTable dt = new DataTable();

                        try
                        {
                            da.Fill(dt);
                            Trainers[] trainer = new Trainers[dt.Rows.Count];
                            if (dt.Rows.Count == 0)
                            {
                                return null;
                            }
                            else
                            {
                                int i = 0;
                                foreach (DataRow dr in dt.Rows)
                                {
                                    trainer[i++] = new Trainers(int.Parse(dr["id"].ToString()), dr["name"].ToString(), dr["specialization1"].ToString(), dr["specialization2"].ToString(), dr["specialization3"].ToString(), DateTime.Parse(dr["DateofJoining"].ToString()), int.Parse(dr["yearsOfExp"].ToString()), dr["email"].ToString(),dr["phone"].ToString(), DateTime.Parse(dr["createdate"].ToString()), int.Parse(dr["isSubscribed"].ToString()));
                                }
                                return trainer;
                            }
                        }
                        catch (Exception ex)
                        {
                            //handle errors
                        }
                        finally
                        {
                            con.Close();
                        }
                        return null;
                    }
                }
            }

        }
        public Courses[] GetSubscribedCourses(int learnerId)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetCoursebyLearnerID", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Learnerid", learnerId));
                        con.Open();
                        string res = "";
                        DataTable dt = new DataTable();

                        try
                        {
                            da.Fill(dt);
                            Courses[] courses = new Courses[dt.Rows.Count];
                            if (dt.Rows.Count == 0)
                            {
                                return null;
                            }
                            else
                            {
                                int i = 0;
                                foreach (DataRow dr in dt.Rows)
                                {
                                    courses[i++] = new Courses(int.Parse(dr["id"].ToString()), dr["coursename"].ToString(), int.Parse(dr["instructorId"].ToString()), dr["description"].ToString(), DateTime.Parse(dr["createdate"].ToString()), dr["url"].ToString(), dr["thumbnail"].ToString(), (dr["topics"].ToString()).Split(',').ToArray());
                                }
                                return courses;
                            }
                        }
                        catch (Exception ex)
                        {
                            //handle errors
                        }
                        finally
                        {
                            con.Close();
                        }
                        return null;
                    }
                }
            }

        }
        public Courses[] GetCompletedCourses(int learnerId)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetCompletedCoursebyLearnerID", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Learnerid", learnerId));
                        con.Open();
                        string res = "";
                        DataTable dt = new DataTable();

                        try
                        {
                            da.Fill(dt);
                            Courses[] courses = new Courses[dt.Rows.Count];
                            if (dt.Rows.Count == 0)
                            {
                                return null;
                            }
                            else
                            {
                                int i = 0;
                                foreach (DataRow dr in dt.Rows)
                                {
                                    courses[i++] = new Courses(int.Parse(dr["id"].ToString()), dr["coursename"].ToString(), int.Parse(dr["instructorId"].ToString()), dr["description"].ToString(), DateTime.Parse(dr["createdate"].ToString()), dr["url"].ToString(), dr["thumbnail"].ToString(), (dr["topics"].ToString()).Split(',').ToArray());
                                }
                                return courses;
                            }
                        }
                        catch (Exception ex)
                        {
                            //handle errors
                        }
                        finally
                        {
                            con.Close();
                        }
                        return null;
                    }
                }
            }

        }
        public string CreateCourse(Courses course)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CreateCourse", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        string abc = string.Join(",", course.topics);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@courseName", course.CourseName));
                        cmd.Parameters.Add(new SqlParameter("@description", course.Description));
                        cmd.Parameters.Add(new SqlParameter("@instructorId", course.InstructorId));
                        cmd.Parameters.Add(new SqlParameter("@createDate", course.CreatedDate));
                        cmd.Parameters.Add(new SqlParameter("@courseDuration", course.CourseDuration));
                        cmd.Parameters.Add(new SqlParameter("@url", course.url));
                        cmd.Parameters.Add(new SqlParameter("@thumbnail", ""));
                        cmd.Parameters.Add(new SqlParameter("@topics", string.Join(",", course.topics) ));
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string res = "";
                        DataTable dt = new DataTable();
                        try
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count == 0)
                            {
                                return null;
                            }
                            else
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (dr["err"] == DBNull.Value)
                                        res = dr["id"].ToString();
                                    else
                                        res = dr["err"].ToString();
                                }
                                return res;
                            }
                        }
                        catch (Exception ex)
                        {
                            //handle errors
                        }
                        finally
                        {
                            con.Close();
                        }
                        return null;
                    }
                }
            }

        }
        public Quiz[] GetQuiz(int courseId)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetQuizByCourseID", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@courseId", courseId));
                            con.Open();
                        string res = "";
                        DataTable dt = new DataTable();
                        
                        try
                        {
                            da.Fill(dt);
                            Quiz[] quiz = new Quiz[dt.Rows.Count];
                            if (dt.Rows.Count == 0)
                            {
                                return null;
                            }
                            else
                            {
                                int i = 0;
                                foreach (DataRow dr in dt.Rows)
                                {
                                    quiz[i++] = new Quiz(int.Parse(dr["id"].ToString()),dr["question"].ToString(), dr["option1"].ToString(), dr["option2"].ToString(), dr["option3"].ToString(), dr["option4"].ToString(), dr["answer"].ToString());
                                }
                                return quiz;
                            }
                        }
                        catch (Exception ex)
                        {
                            //handle errors
                        }
                        finally
                        {
                            con.Close();
                        }
                        return null;
                    }
                }
            }

        }
        public string UpdateCourseURL(int courseId,string url,string thumbnail)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateCourseURL", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@courseId", courseId));
                        cmd.Parameters.Add(new SqlParameter("@url", url));
                        cmd.Parameters.Add(new SqlParameter("@thumbnail", thumbnail));
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string res = "";
                        DataTable dt = new DataTable();
                        try
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count == 0)
                            {
                                return null;
                            }
                            else
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (dr["err"] == DBNull.Value)
                                        res = dr["id"].ToString();
                                    else
                                        res = dr["err"].ToString();
                                }
                                return res;
                            }
                        }
                        catch (Exception ex)
                        {
                            //handle errors
                        }
                        finally
                        {
                            con.Close();
                        }
                        return null;
                    }
                }
            }
        }
        public void AddQuiz(Quiz quiz,int courseid)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AddQuiz", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@courseid", courseid));
                        cmd.Parameters.Add(new SqlParameter("@question", quiz.Quetion));
                        cmd.Parameters.Add(new SqlParameter("@option1", quiz.Option1));
                        cmd.Parameters.Add(new SqlParameter("@option2", quiz.Option2));
                        cmd.Parameters.Add(new SqlParameter("@option3", quiz.Option3));
                        cmd.Parameters.Add(new SqlParameter("@option4", quiz.Option4));
                        cmd.Parameters.Add(new SqlParameter("@answer", quiz.answer));
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        DataTable dt = new DataTable();
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            //handle errors
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }

        }
        public void UpdateCourseCompletion(int courseId,int learnerId,string score)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_updateCourseCompletion", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@courseId", courseId));
                        cmd.Parameters.Add(new SqlParameter("@learnerId", learnerId));
                        cmd.Parameters.Add(new SqlParameter("@score", score));
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        DataTable dt = new DataTable();
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            //handle errors
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }

        }
    }
}
