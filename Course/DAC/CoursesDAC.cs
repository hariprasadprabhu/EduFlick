using Course.Model;
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
        public string CreateCourse(Courses course)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CreateCourse", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@courseName", course.CourseName));
                        cmd.Parameters.Add(new SqlParameter("@description", course.Description));
                        cmd.Parameters.Add(new SqlParameter("@instructorId", course.InstructorId));
                        cmd.Parameters.Add(new SqlParameter("@createDate", course.CreatedDate));
                        cmd.Parameters.Add(new SqlParameter("@courseDuration", course.CourseDuration));
                        cmd.Parameters.Add(new SqlParameter("@price", course.price));
                        cmd.Parameters.Add(new SqlParameter("@url", course.url));
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
        public string UpdateCourseURL(int courseId,string url)
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
    }
}
