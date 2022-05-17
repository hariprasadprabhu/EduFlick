using Course.Model;
using System.Data;
using System.Data.SqlClient;

namespace Course.DAC
{
    public class LearnerDAC
    {

        public string conString = "";
        public LearnerDAC()
        {

        }
        public LearnerDAC(string conString)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            this.conString=builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public Learner LoginCheck(string usn, string password)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using(SqlCommand cmd = new SqlCommand("usp_LoginCheckLearner",con))
                {
                    using(var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@USN", usn));
                        cmd.Parameters.Add(new SqlParameter("@password", password));
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        List<Learner> ln = new List<Learner>();
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
                                    ln.Add(new Learner(int.Parse(dr["id"].ToString()), dr["name"].ToString(), dr["email"].ToString(), dr["usn"].ToString(), dr["username"].ToString(), dr["password"].ToString(), DateTime.Parse(dr["dob"].ToString()), dr["specialization"].ToString(), int.Parse(dr["semister"].ToString())));
                                }
                                return ln[0];
                            }
                        }
                        catch (Exception ex)
                        {
                            //handle errors
                        }
                        return null;
                    }    
                }    
            }
        }
        public string RegisterLearner(Learner learner)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RegisterLearner", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@name", learner.Name));
                        cmd.Parameters.Add(new SqlParameter("@email", learner.Email));
                        cmd.Parameters.Add(new SqlParameter("@usn", learner.USN));
                        cmd.Parameters.Add(new SqlParameter("@username", learner.Username));
                        cmd.Parameters.Add(new SqlParameter("@password", learner.Password));
                        cmd.Parameters.Add(new SqlParameter("@dob", learner.Dob));
                        cmd.Parameters.Add(new SqlParameter("@specialization", learner.Specialization));
                        cmd.Parameters.Add(new SqlParameter("@semister", learner.Semister));
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
                                    if(dr["err"] == DBNull.Value)
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
                        return null;
                    }
                }
            }
        }

    }
}
