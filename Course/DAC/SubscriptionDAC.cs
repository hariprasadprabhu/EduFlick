using Course.Model;
using System.Data;
using System.Data.SqlClient;

namespace Course.DAC
{
    public class SubscriptionDAC
    {
        public string conString = "";
        public SubscriptionDAC()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            this.conString = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public bool Subscribe(Subscription sub)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Subscribe", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@trainerId", sub.trainerid));
                        cmd.Parameters.Add(new SqlParameter("@learnerId", sub.learnerid));
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        DataTable dt = new DataTable();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            //handle errors
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
