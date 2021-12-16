using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class _6MonthPlanReports : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();
        }

        protected void BtnGetReport_Click(object sender, EventArgs e)
        {
            TARAdditionalPoints.InnerText = string.Empty;

            int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);

            var EpointsAM = (from ev in db.LKSixMonthPlans
                             where ev.DataTypeSelection == 3
                             where ev.PreparedByID == 2 || ev.PreparedByID == loggerId
                             select ev).ToList();
            /* var EpointsEN = (from ev in db.LKSixMonthPlans 
                              where ev.LanguageSelection == "EN" && ev.DataTypeSelection == 3
                              where ev.PreparedByID == 2 || ev.PreparedByID == loggerId
                              select ev).ToList();
                              */

            if (Session["SelectedLanguage"].ToString() == "AM")
            {
                //LblAdditionalEN.Visible = false;
                //LblAdditionalAM.Visible = true;
                //LblIntroHeaderEN.Visible = false;
                //LblIntroHeaderAM.Visible = true;
            }
            if (Session["SelectedLanguage"].ToString() == "EN")
            {
                //LblAdditionalEN.Visible = true;
                //LblAdditionalAM.Visible = false;
                //LblIntroHeaderEN.Visible = true;
                //LblIntroHeaderAM.Visible = false;
            }
            int rows = EpointsAM.Count;
            int cols = 7;

            int rowcounter = 1;

             var evaluated2 = (from evd in db.SixMonthPlans
                               where evd.PlanName == 22
&& evd.PlanSetByEmployeeId == Convert.ToInt32(DDLEvaluators.SelectedValue) && evd.PlanSetForEmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                               select evd).SingleOrDefault();

             if (evaluated2 != null)
             {
                 TARAdditionalPoints.InnerText = evaluated2.PriorityGiven.ToString();
             }
            foreach (var eAM in EpointsAM)
            {
                TableRow tr = new TableRow();

                for (int i = 0; i < cols; i++)
                {
                    TableCell c = new TableCell();
                    if (i == 0)
                    {
                        c.Controls.Add(new Label() { ID = rowcounter.ToString(), Text = rowcounter.ToString() });
                        tr.Cells.Add(c);
                    }
                    if (i == 1)
                    {
                        if (Session["SelectedLanguage"].ToString() == "AM")
                        {
                            c.Controls.Add(new Label() { ID = (rowcounter + eAM.LanguageSelection).ToString(), Text = eAM.PlanNameAmharic.ToString() });
                            tr.Cells.Add(c);
                        }
                        else {
                            c.Controls.Add(new Label() { ID = (rowcounter + eAM.LanguageSelection).ToString(), Text = eAM.PlanName.ToString() });
                            tr.Cells.Add(c);
                        }
                    }
                    if (i != 0 && i != 1 && i != 6 && i!=5)
                    {
                        var evaluated = (from evd in db.SixMonthPlans
                                         where evd.PlanName == eAM.Id && evd.PlanSetByEmployeeId == Convert.ToInt32(DDLEvaluators.SelectedValue) && evd.PlanSetForEmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                             evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && evd.PlanName != 22
                                         select evd).SingleOrDefault();
                        if (evaluated != null && Convert.ToInt32(evaluated.PriorityGiven) == i)
                        {
                            c.Controls.Add(new RadioButton() { ID = (rowcounter + eAM.LanguageSelection + i).ToString(), Checked = true, GroupName = eAM.PlanName.ToString() });
                            tr.Cells.Add(c);
                        }
                        else
                        {
                            c.Controls.Add(new RadioButton() { ID = (rowcounter + eAM.LanguageSelection + i).ToString(), GroupName = eAM.PlanName.ToString() });
                            tr.Cells.Add(c);
                        }
                    }
                    if (i == 6)
                    {
                        c.Controls.Add(new Label() { ID = eAM.LanguageSelection + rowcounter.ToString(), Text = eAM.Id.ToString() });
                        tr.Cells.Add(c);
                        tr.Cells[6].Visible = false;
                    }
                    if (i == 5)
                    {
                        DataAccess.SixMonthPlan evaluatedRemark = (from evd in db.SixMonthPlans
                                                                   where evd.PlanName == eAM.Id
                                   && evd.PlanSetForEmployeeId == Convert.ToInt32(Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue)) 
                                   && evd.PlanSetByEmployeeId == Convert.ToInt32(Convert.ToInt32(DDLEvaluators.SelectedValue)) &&
                                   evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && evd.PlanName != 22 && evd.UserRemark != null
                                                                   select evd).SingleOrDefault();
                        if (evaluatedRemark != null)
                        {
                            c.Controls.Add(new TextBox() { ID = ("Tbx" + rowcounter).ToString(), Text = evaluatedRemark.UserRemark.ToString(), CssClass = "form-control formTbx", TextMode = TextBoxMode.MultiLine, Rows = 1 });
                            tr.Cells.Add(c);
                        }
                        else
                        {
                            c.Controls.Add(new TextBox() { ID = ("Tbx" + rowcounter).ToString(), CssClass = "form-control formTbx", TextMode = TextBoxMode.MultiLine, Rows = 1 });
                            tr.Cells.Add(c);
                        }
                    }

                }
                Table1.Rows.Add(tr);
                rowcounter++;
            }
        }
    }
}