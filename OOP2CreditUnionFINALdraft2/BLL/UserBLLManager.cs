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

        public bool UserLogin(User cUser)
        {
            return userDAL.UserLogin(cUser);
        }

        public bool AddUser(User newUser)
        {
            List<string> userNames = GetUserNames();

            if (userNames.Contains(newUser.UserName))
                return false;
            else
                return userDAL.AddUser(newUser);
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            return userDAL.ChangePassword(oldPassword, newPassword);
        }

        public List<string> GetUserNames()
        {
            return userDAL.ReturnUserNames();
        }

        public bool ResetPassword(string sessionUser, string userName)
        {
            return userDAL.ResetPassword(sessionUser, userName);
        }

        public DataSet GetUserLogs()
        {
            return userDAL.GetUserLog();
        }

        public bool RemoveUser(string userName)
        {
            return userDAL.RemoverUser(userName);
        }
    }
}
