using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class Login : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogIn_Click(object sender, EventArgs e)
        {
            String userName = un.Value;
            string passw = pwd.Value;

            var isUserValid = (from ul in db.UsersLogIns where ul.UserName.Equals(userName) && ul.Pwd.Equals(passw) select ul).SingleOrDefault();

            if (isUserValid != null)
            {
                Session["EvaluationPeriod"] = (from eperiod in db.EvaluationPeriods where eperiod.isClosed.Equals("0") select eperiod).SingleOrDefault().Id;
                Session["LogedInUserCompanyId"] = isUserValid.CompanyId;
                Session["UserLoggedInID1"] = isUserValid.Id;
                Session["SelectedLanguage"] = "AM";
                Session["UserRole"] = isUserValid.UserRole;
                
                Response.Redirect("WebForm2.aspx");
            }
            else { Response.Write("invalid username and password"); }
        }
    }
}