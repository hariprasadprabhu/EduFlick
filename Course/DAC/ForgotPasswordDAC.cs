using Course.Model;
using System.Data;
using System.Data.SqlClient;
namespace Course.DAC
{
    public class ForgotPasswordDAC
    {
        public string conString = "";
        public ForgotPasswordDAC()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            this.conString = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public bool IsEmailValid(string email,bool islearner)
        {
            return true;
        }

        public bool updateSecreteCode(string email,int code)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ForgotPassword", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@email", email));
                        cmd.Parameters.Add(new SqlParameter("@code", code));
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string res = "";
                        DataTable dt = new DataTable();
                        try
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count == 0)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
        }
        public bool VerifyOTP(string email,int code)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_VerifyOTP", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@email", email));
                        cmd.Parameters.Add(new SqlParameter("@code", code));
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        int res = 0;
                        DataTable dt = new DataTable();
                        try
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count == 0)
                            {
                                return false;
                            }
                            else
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (dr["Res"] != DBNull.Value)
                                        return true;
                                    else
                                        res = 0;
                                }
                                return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            return false;
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
