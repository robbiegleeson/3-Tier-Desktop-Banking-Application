using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DAL
{
    public class UserDALManager : ConnectionManager
    {
        SqlConnection cxn;
        SqlCommand cmd;

        public bool UserLogin(User cUser)
        {
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spUserLogin", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = cUser.UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 256).Value = cUser.Password;
                    cmd.Parameters.Add("@LastLogin", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@IsAdmin", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cxn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (rows > 0)
                    {
                        cUser.IsAdmin = Convert.ToBoolean(cmd.Parameters["@IsAdmin"].Value);
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public bool AddUser(User newUser)
        {
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spAddUser", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = newUser.UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 256).Value = newUser.Password;
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 50).Value = newUser.FullName;
                    cmd.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = newUser.IsAdmin;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    cxn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (rows > 0)
                    {
                        newUser.UserId = Convert.ToInt32(cmd.Parameters["@UserID"].Value);
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spChangePassword", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OldPassword", SqlDbType.NVarChar, 256).Value = oldPassword;
                    cmd.Parameters.Add("@NewPassword", SqlDbType.NVarChar, 256).Value = newPassword;

                    cxn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (rows > 0)
                        return true;
                    else
                        return false;
                }   
            }
        }
        public bool ResetPassword(string sessionUser ,string userName)
        {
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spResetPassword", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Admin", SqlDbType.NVarChar, 50).Value = sessionUser;
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = userName;

                    cxn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (rows > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
        public List<string> ReturnUserNames()
        {
            List<string> userNames = new List<string>();

            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spReturnUserNames", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cxn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        userNames.Add(dataReader["UserName"].ToString());
                    }
                    dataReader.Close();
                    cxn.Close();
                }
            }
            return userNames;
        }

        public DataSet GetUserLog()
        {
            DataSet dsUserLogs = null;
            using (cxn = new SqlConnection(this.ConnectionString))
            {
               
                using (cmd = new SqlCommand("spGetUserLog", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dsUserLogs = new DataSet();
                    dataAdapter.SelectCommand = cmd;

                    cxn.Open();
                    dataAdapter.Fill(dsUserLogs);
                    cxn.Close();
                }
            }
            return dsUserLogs;
        }

        public bool RemoverUser(string userName)
        {
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spRemoveUser", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = userName;

                    cxn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (rows > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}
