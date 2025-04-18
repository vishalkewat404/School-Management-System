using School_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace School_Management_System.Controllers
{
    public class LoginController : Controller
    {
        BusinessLayer Objbus = new BusinessLayer();

        [HttpGet]
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginClass User)
        {
            DataTable dt = new DataTable();
            if (ModelState.IsValid)
            {
                User = User.GetUserLoginDetails(User.User_LoginName, User.User_Email, User.User_Password);

                if (User != null)
                {
                    LoginHistoryClass LoginHistrory = new LoginHistoryClass();
                    LoginHistrory.User_Id = User.User_Id;
                    LoginHistrory.LoginHist_LoginIPAddress = Request.UserHostAddress;
                    LoginHistrory.SA08_AppId = "1";
                    LoginHistrory.LoginHist_IsLoggedIn = "1";
                    LoginHistrory.LoginHistory_Location = "India";
                    LoginHistrory.LoginHistory_Browser = Request.Browser.Browser;
                    LoginHistrory.LoginHistory_AccessType = Request.Browser.IsMobileDevice ? "Mobile" : "Browser";
                    LoginHistrory.LoginHistory_LoginSessionId = Session.SessionID;
                    LoginHistrory.LoginHistory_LanguageMode = "English";

                    bool Flag = Objbus.InsertLoginDetails(LoginHistrory);
                    if (Flag == true)
                    {
                        if (Session["SA10_UserType_Id"].ToString() == "1")
                        {
                           return  RedirectToAction("AnalyticsDashboard", "Analytics");
                        }
                    }
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ViewBag.Message = "Invalid email or password";
                }
            }
            return View(User);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}