using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class SubmittedAnnualForms : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();

            List<DataAccess.Employee> emps = (from em in db.Employees where em.isActive == "1" select em).ToList();

            foreach (DataAccess.Employee empss in emps)
            {
                var Planned = (from ep in db.SubmitedAnnualForms
                               where ep.EmployeeId == empss.Id && ep.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && ep.IsSubmitted == true
                               select ep).FirstOrDefault();
                if (Planned != null)
                {
                    LbxSubmittedList.Items.Add(empss.EName + " " + empss.ELName);
                }
                else
                {
                    LbxUnsubmittedList.Items.Add(empss.EName + " " + empss.ELName);
                }
            }
        }
    }
}