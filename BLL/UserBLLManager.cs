using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataModels;
using System.Data;

namespace BLL
{
    public class UserBLLManager
    {
        UserDALManager userDAL = new UserDALManager();
        //return (un)successful login
        public bool UserLogin(User cUser)
        {
            return userDAL.UserLogin(cUser);
        }
        //return results of adding a user
        public bool AddUser(User newUser)
        {
            List<string> userNames = GetUserNames();

            if (userNames.Contains(newUser.UserName))
                return false;
            else
                return userDAL.AddUser(newUser);
        }
        //return (un)successful password change 
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            return userDAL.ChangePassword(oldPassword, newPassword);
        }
        //Gets a list over usernames from the DB
        public List<string> GetUserNames()
        {
            return userDAL.ReturnUserNames();
        }
        //returns (un)successful password reset (admin only)
        public bool ResetPassword(string sessionUser, string userName)
        {
            return userDAL.ResetPassword(sessionUser, userName);
        }
        //return dataset for user grid
        public DataSet GetUserLogs()
        {
            return userDAL.GetUserLog();
        }
        //return result of deleting user attempt
        public bool RemoveUser(string userName)
        {
            return userDAL.RemoverUser(userName);
        }
    }
}
