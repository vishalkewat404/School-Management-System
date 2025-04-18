using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace School_Management_System.Models
{
    
    public class BusinessLayer
    {
        DataLayer objdl = new DataLayer();
        internal DataTable GetUserLoginDetails(string User_LoginName, string User_Email, string User_Password)
        {
            return objdl.GetUserLoginDetails(User_LoginName, User_Email, User_Password);
        }

        internal bool InsertLoginDetails(LoginHistoryClass loginHistrory)
        {
            return objdl.InsertLoginDetails(loginHistrory);
        }
    }
}