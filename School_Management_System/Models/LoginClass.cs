using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace School_Management_System.Models
{
    public class LoginClass
    {
        BusinessLayer Objbus = new BusinessLayer();
        public string User_Id { get; set; }
        public string User_LoginName { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        public string SA10_UserType_Id { get; set; }
        public string O03_Org_Id { get; private set; }
        public string Org_Name { get; private set; }
        public string O05_Office_Id { get; private set; }
        public string Office_Name { get; private set; }
        public string Office_Address { get; private set; }
        public string O10_Post_Id { get; private set; }
        public string Post_Name { get; private set; }
        public string O12_Designation_Id { get; private set; }
        public string P02_Person_Id { get; private set; }
        public string Person_FirstName { get; private set; }
        public string Person_Mobile1 { get; private set; }
        public string G02_Country_Id { get; private set; }
        public string Country_Name { get; private set; }
        public string G03_State_Id { get; private set; }
        public string State_Name { get; private set; }
        public string G04_District_Id { get; private set; }
        public string District_Name { get; private set; }
        public string G05_Block_Id { get; private set; }
        public string Block_Name { get; private set; }
        public string G06_Panchayat_Id { get; private set; }
        public string G07_Village_Id { get; private set; }
        public string Village_Name { get; private set; }
        public string G08_Tehsil_Id { get; private set; }
        public string Tehsil_Name { get; private set; }
        public string G09_Town_Id { get; private set; }
        public string Town_Name { get; private set; }
        public string G10_Ward_Id { get; private set; }
        public string Ward_Name { get; private set; }
        public string G29_Division_Id { get; private set; }
        public string Division_Name { get; private set; }

        internal LoginClass GetUserLoginDetails(string user_LoginName, string user_Email, string user_Password)
        {
            LoginClass User = new LoginClass();
            DataTable dt = new DataTable();
            dt = Objbus.GetUserLoginDetails(user_LoginName, user_Email, user_Password);
            if (dt != null && dt.Rows.Count>0)
            {
                #region Session Filling
                HttpContext.Current.Session["User_Id"] = dt.Rows[0]["User_Id"].ToString();
                HttpContext.Current.Session["User_LoginName"] = dt.Rows[0]["User_LoginName"].ToString();
                HttpContext.Current.Session["User_Email"] = dt.Rows[0]["User_Email"].ToString();
                HttpContext.Current.Session["User_Password"] = dt.Rows[0]["User_Password"].ToString();
                HttpContext.Current.Session["SA10_UserType_Id"] = dt.Rows[0]["SA10_UserType_Id"].ToString();
                HttpContext.Current.Session["O03_Org_Id"] = dt.Rows[0]["O03_Org_Id"].ToString();
                HttpContext.Current.Session["Org_Name"] = dt.Rows[0]["Org_Name"].ToString();
                HttpContext.Current.Session["O05_Office_Id"] = dt.Rows[0]["O05_Office_Id"].ToString();
                HttpContext.Current.Session["Office_Name"] = dt.Rows[0]["Office_Name"].ToString();
                HttpContext.Current.Session["Office_Address"] = dt.Rows[0]["Office_Address"].ToString();
                HttpContext.Current.Session["O10_Post_Id"] = dt.Rows[0]["O10_Post_Id"].ToString();
                HttpContext.Current.Session["Post_Name"] = dt.Rows[0]["Post_Name"].ToString();
                HttpContext.Current.Session["O12_Designation_Id"] = dt.Rows[0]["O12_Designation_Id"].ToString();
                HttpContext.Current.Session["P02_Person_Id"] = dt.Rows[0]["P02_Person_Id"].ToString();
                HttpContext.Current.Session["Person_FirstName"] = dt.Rows[0]["Person_FirstName"].ToString();
                HttpContext.Current.Session["Person_Mobile1"] = dt.Rows[0]["Person_Mobile1"].ToString();
                HttpContext.Current.Session["G02_Country_Id"] = dt.Rows[0]["G02_Country_Id"].ToString();
                HttpContext.Current.Session["Country_Name"] = dt.Rows[0]["Country_Name"].ToString();
                HttpContext.Current.Session["G03_State_Id"] = dt.Rows[0]["G03_State_Id"].ToString();
                HttpContext.Current.Session["State_Name"] = dt.Rows[0]["State_Name"].ToString();
                HttpContext.Current.Session["G04_District_Id "] = dt.Rows[0]["G04_District_Id"].ToString();
                HttpContext.Current.Session["District_Name"] = dt.Rows[0]["District_Name"].ToString();
                HttpContext.Current.Session["G05_Block_Id"] = dt.Rows[0]["G05_Block_Id"].ToString();
                HttpContext.Current.Session["Block_Name"] = dt.Rows[0]["Block_Name"].ToString();
                HttpContext.Current.Session["G06_Panchayat_Id"] = dt.Rows[0]["G06_Panchayat_Id"].ToString();
                HttpContext.Current.Session["G07_Village_Id"] = dt.Rows[0]["G07_Village_Id"].ToString();
                HttpContext.Current.Session["Village_Name"] = dt.Rows[0]["Village_Name"].ToString();
                HttpContext.Current.Session["G08_Tehsil_Id"] = dt.Rows[0]["G08_Tehsil_Id"].ToString();
                HttpContext.Current.Session["Tehsil_Name"] = dt.Rows[0]["Tehsil_Name"].ToString();
                HttpContext.Current.Session["G09_Town_Id"] = dt.Rows[0]["G09_Town_Id"].ToString();
                HttpContext.Current.Session["Town_Name"] = dt.Rows[0]["Town_Name"].ToString();
                HttpContext.Current.Session["G10_Ward_Id"] = dt.Rows[0]["G10_Ward_Id"].ToString();
                HttpContext.Current.Session["Ward_Name"] = dt.Rows[0]["Ward_Name"].ToString();
                HttpContext.Current.Session["G29_Division_Id"] = dt.Rows[0]["G29_Division_Id"].ToString();
                HttpContext.Current.Session["Division_Name"] = dt.Rows[0]["Division_Name"].ToString();

                #endregion

                #region Model filling

                User.User_Id = dt.Rows[0]["User_Id"].ToString();
                User.User_LoginName = dt.Rows[0]["User_LoginName"].ToString();
                User.User_Email = dt.Rows[0]["User_Email"].ToString();
                User.User_Password = dt.Rows[0]["User_Password"].ToString();
                User.SA10_UserType_Id = dt.Rows[0]["SA10_UserType_Id"].ToString();
                User.O03_Org_Id = dt.Rows[0]["O03_Org_Id"].ToString();
                User.Org_Name = dt.Rows[0]["Org_Name"].ToString();
                User.O05_Office_Id = dt.Rows[0]["O05_Office_Id"].ToString();
                User.Office_Name = dt.Rows[0]["Office_Name"].ToString();
                User.Office_Address = dt.Rows[0]["Office_Address"].ToString();
                User.O10_Post_Id = dt.Rows[0]["O10_Post_Id"].ToString();
                User.Post_Name = dt.Rows[0]["Post_Name"].ToString();
                User.O12_Designation_Id = dt.Rows[0]["O12_Designation_Id"].ToString();
                User.P02_Person_Id = dt.Rows[0]["P02_Person_Id"].ToString();
                User.Person_FirstName = dt.Rows[0]["Person_FirstName"].ToString();
                User.Person_Mobile1 = dt.Rows[0]["Person_Mobile1"].ToString();
                User.G02_Country_Id = dt.Rows[0]["G02_Country_Id"].ToString();
                User.Country_Name = dt.Rows[0]["Country_Name"].ToString();
                User.G03_State_Id = dt.Rows[0]["G03_State_Id"].ToString();
                User.State_Name = dt.Rows[0]["State_Name"].ToString();
                User.G04_District_Id = dt.Rows[0]["G04_District_Id"].ToString();
                User.District_Name = dt.Rows[0]["District_Name"].ToString();
                User.G05_Block_Id = dt.Rows[0]["G05_Block_Id"].ToString();
                User.Block_Name = dt.Rows[0]["Block_Name"].ToString();
                User.G06_Panchayat_Id = dt.Rows[0]["G06_Panchayat_Id"].ToString();
                User.G07_Village_Id = dt.Rows[0]["G07_Village_Id"].ToString();
                User.Village_Name = dt.Rows[0]["Village_Name"].ToString();
                User.G08_Tehsil_Id = dt.Rows[0]["G08_Tehsil_Id"].ToString();
                User.Tehsil_Name = dt.Rows[0]["Tehsil_Name"].ToString();
                User.G09_Town_Id = dt.Rows[0]["G09_Town_Id"].ToString();
                User.Town_Name = dt.Rows[0]["Town_Name"].ToString();
                User.G10_Ward_Id = dt.Rows[0]["G10_Ward_Id"].ToString();
                User.Ward_Name = dt.Rows[0]["Ward_Name"].ToString();
                User.G29_Division_Id = dt.Rows[0]["G29_Division_Id"].ToString();
                User.Division_Name = dt.Rows[0]["Division_Name"].ToString();


                #endregion
            }
            return User;
        }
    }
}