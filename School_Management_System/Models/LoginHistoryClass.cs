using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Management_System.Models
{
    public class LoginHistoryClass
    {
        public string User_Id { get; internal set; }
        public string Login_ID { get; internal set; }
        public string SA05_User_Id { get; internal set; }
        public string LoginHist_LoginIPAddress { get; internal set; }
        public string SA08_AppId { get; internal set; }
        public string LoginHist_IsLoggedIn { get; internal set; }
        public string LoginHistory_Location { get; internal set; }    
        public string LoginHistory_Browser { get; internal set; }
        public string LoginHistory_AccessType { get; internal set; }
        public string LoginHistory_LoginSessionId { get; internal set; }
        public string LoginHistory_LanguageMode { get; internal set; }
    }
}