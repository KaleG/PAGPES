using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class ReportUnsubmittedPlan : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();
            
            //ListBox lb1 = new ListBox();
            List<DataAccess.Employee> emps = (from em in db.Employees where em.isActive == "1" select em).ToList();

            foreach (DataAccess.Employee empss in emps) {
                var Planned = (from ep in db.SixMonthPlans
                                 where ep.PlanSetByEmployeeId == empss.Id && ep.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && ep.PlanSetForEmployeeId == empss.Id && ep.IsSubmitted == true
                                 select ep).FirstOrDefault();
                if (Planned != null)
                {
                    ListBox2.Items.Add(empss.EName + " " + empss.ELName);
                }
                else { 
                ListBox1.Items.Add(empss.EName + " " + empss.ELName);
                }
            }

            
        }

        protected void BtnSelectEmployee_Click(object sender, EventArgs e)
        {
            ListBox3.Items.Clear();
            ListBox4.Items.Clear();
            int SelectedLineManager = Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue);

            List<DataAccess.View_LineMAnagersEmploye> emps = (from em in db.View_LineMAnagersEmployes where em.LineManager==SelectedLineManager && em.period== Convert.ToInt32(Session["EvaluationPeriod"]) select em).ToList();

            foreach (DataAccess.View_LineMAnagersEmploye empss in emps)
            {
                var Planned = (from ep in db.SixMonthPlans
                               where ep.PlanSetForEmployeeId == empss.employeeID && ep.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && ep.PlanSetByEmployeeId == SelectedLineManager && ep.IsSubmitted == true
                               select ep).FirstOrDefault();
                if (Planned != null)
                {
                    ListBox3.Items.Add(empss.EmpFullName);
                }
                else
                {
                    ListBox4.Items.Add(empss.EmpFullName);
                }
            }
        }
    }
}