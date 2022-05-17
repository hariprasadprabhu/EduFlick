using Course.Model;
using System.Data.SqlClient;
using System.Data;

namespace Course.DAC
{
    public class TrainerDAC
    {
        public string conString = "";
        public TrainerDAC()
        {

        }
        public TrainerDAC(string conString)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            this.conString = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public Trainer LoginCheck(string email, string password)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_LoginCheckTrainer", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@email", email));
                        cmd.Parameters.Add(new SqlParameter("@password", password));
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        List<Trainer> ln = new List<Trainer>();
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
                                    ln.Add(new Trainer(int.Parse(dr["id"].ToString()), dr["name"].ToString(), dr["specialization1"].ToString(), dr["specialization2"].ToString(), dr["specialization3"].ToString(), DateTime.Parse(dr["DateofJoining"].ToString()), int.Parse(dr["yearsOfExp"].ToString()), dr["email"].ToString(), dr["password"].ToString(), dr["phone"].ToString(), DateTime.Parse(dr["createdate"].ToString())));
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
        public string RegisterTrainer(Trainer trainer)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RegisterTrainer", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@name", trainer.Name));
                        cmd.Parameters.Add(new SqlParameter("@specialization1", trainer.Specialization1));
                        cmd.Parameters.Add(new SqlParameter("@specialization2", trainer.Specialization2));
                        cmd.Parameters.Add(new SqlParameter("@specialization3", trainer.Specialization3));
                        cmd.Parameters.Add(new SqlParameter("@email", trainer.email));
                        cmd.Parameters.Add(new SqlParameter("@dateOfJoining", trainer.DateOfJoining));
                        cmd.Parameters.Add(new SqlParameter("@expirience", trainer.Expirience));
                        cmd.Parameters.Add(new SqlParameter("@password", trainer.password));
                        cmd.Parameters.Add(new SqlParameter("@phone", trainer.phone));
                        cmd.Parameters.Add(new SqlParameter("@createdate", trainer.createdate));
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
                        return null;
                    }
                }
            }
        }

    }
}
