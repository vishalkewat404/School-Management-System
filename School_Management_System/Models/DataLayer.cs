using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_Management_System.Models
{
    public class DataLayer
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;

        public bool ExecureProcTransactionWithParameter(string ProcedureName, SqlConnection conn,SqlTransaction trans, SqlParameter[] sp)
        {
            bool Flag = false;
            using (SqlCommand cmd = new SqlCommand(ProcedureName, conn, trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sp);
                // Execute the stored procedure
               int Return = cmd.ExecuteNonQuery();
                if (Return > 0)
                {
                    Flag = true;
                }
                else
                {
                    Flag = false;
                }

            }
            return Flag;
        }
        internal DataTable GetUserLoginDetails(string User_LoginName, string User_Email, string User_Password)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetUserLoginDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User_LoginName", User_LoginName);
                    cmd.Parameters.AddWithValue("@User_Email", User_Email);
                    cmd.Parameters.AddWithValue("@User_Password", User_Password);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        internal bool InsertLoginDetails(LoginHistoryClass loginHistrory)
        {
            bool Flag = false;
            loginHistrory.SA05_User_Id = "0";
            using (SqlConnection cn=new SqlConnection(_connectionString))
            {
                if (cn.State==ConnectionState.Closed)
                {
                    cn.Open();
                }
                SqlTransaction trans = cn.BeginTransaction();
                try
                {
                    if (HttpContext.Current.Session["loginHistrory_Id"]!=null)
                    {
                        string sql = "Update SA13_LoginHistory set LoginHist_LogoutTime=Getdate(),LoginHist_IsLoggedIn=0 where Login_ID='" + HttpContext.Current.Session["loginHistrory_Id"] + "'";
                        ExecuteSelectQuery(sql);
                    }
                    else
                    {
                        SqlParameter[] sp = new SqlParameter[11];
                        sp[0] = new SqlParameter("@Login_ID", loginHistrory.Login_ID);
                        sp[0] = new SqlParameter("@Login_ID", SqlDbType.Int);
                        sp[0] = new SqlParameter("@Login_ID", ParameterDirection.Output);
                        sp[1] = new SqlParameter("@SA05_User_Id", loginHistrory.SA05_User_Id == null ? loginHistrory.SA05_User_Id : "0");
                        sp[2] = new SqlParameter("@LoginHist_LoginIPAddress", loginHistrory.LoginHist_LoginIPAddress);
                        sp[3] = new SqlParameter("@SA08_AppId", loginHistrory.SA08_AppId);
                        sp[4] = new SqlParameter("@LoginHist_IsLoggedIn", loginHistrory.LoginHist_IsLoggedIn);
                        sp[5] = new SqlParameter("@LoginHistory_Location", loginHistrory.LoginHistory_Location);
                        sp[6] = new SqlParameter("@LoginHistory_Browser", loginHistrory.LoginHistory_Browser);
                        sp[7] = new SqlParameter("@LoginHistory_AccessType", loginHistrory.LoginHistory_AccessType);
                        sp[8] = new SqlParameter("@LoginHistory_LoginSessionId", loginHistrory.LoginHistory_LoginSessionId);
                        sp[9] = new SqlParameter("@InsertedBy", loginHistrory.User_Id);
                        sp[10] = new SqlParameter("@LoginHistory_LanguageMode", loginHistrory.LoginHistory_LanguageMode);
                        Flag = ExecureProcTransactionWithParameter("SP_InsertIntoSA13_LoginHistory", cn, trans, sp);
                        if (Flag == true)
                        {
                            trans.Commit();
                            Flag = true;
                            HttpContext.Current.Session["loginHistrory_Id"] = Convert.ToInt32(sp[0].Value);
                        }
                        else
                        {
                            trans.Rollback();
                            Flag = false;
                        }
                    }                  
                }
                catch (Exception)
                {
                    trans.Rollback();
                    Flag = false;
                    throw;

                }
            }
            return Flag;
        }

        private void ExecuteSelectQuery(string sql)
        {
            throw new NotImplementedException();
        }
    }
}