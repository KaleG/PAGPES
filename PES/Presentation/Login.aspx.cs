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
            if (Session["UserLoggedInID1"] != null)
            {
                Response.Redirect("Home.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();
        }

        protected void BtnLogIn_Click(object sender, EventArgs e)
        {
            try
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
                    Session["LogInUserName"] = isUserValid.UserName;
                    Session["loggerId"] = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);

                    Response.Redirect("~/Presentation/Home.aspx");
                }
                else { Response.Write("invalid username and password"); }
            }
            catch (Exception exp) {
                Response.Write("invalid username and password");
            }
        }
    }
}