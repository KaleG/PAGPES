using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class Set6MonthPlanForColleage : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);

            var EpointsAM = (from ev in db.LKSixMonthPlans
                             where ev.LanguageSelection == Session["SelectedLanguage"].ToString() && ev.DataTypeSelection == 3
                             where ev.PreparedByID == 2 || ev.PreparedByID == loggerId
                             select ev).ToList();
            /* var EpointsEN = (from ev in db.LKSixMonthPlans 
                              where ev.LanguageSelection == "EN" && ev.DataTypeSelection == 3
                              where ev.PreparedByID == 2 || ev.PreparedByID == loggerId
                              select ev).ToList();
                              */

            if (Session["SelectedLanguage"].ToString() == "AM")
            {
                LblAdditionalEN.Visible = false;
                LblAdditionalAM.Visible = true;
                LblIntroHeaderEN.Visible = false;
                LblIntroHeaderAM.Visible = true;
            }
            if (Session["SelectedLanguage"].ToString() == "EN")
            {
                LblAdditionalEN.Visible = true;
                LblAdditionalAM.Visible = false;
                LblIntroHeaderEN.Visible = true;
                LblIntroHeaderAM.Visible = false;
            }
            int rows = EpointsAM.Count;
            int cols = 7;

            int rowcounter = 1;

            /* var evaluated2 = (from evd in db.LKSixMonthPlans
                               where evd. == 24
&& evd.EmployeeId == loggerId && evd.EvaluatorId == loggerId &&
evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                               select evd).SingleOrDefault();

             if (evaluated2 != null)
             {
                 TARAdditionalPoints.InnerText = evaluated2.EvaluationPointGiven.ToString();
             }*/
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
                        c.Controls.Add(new Label() { ID = (rowcounter + eAM.LanguageSelection).ToString(), Text = eAM.PlanName.ToString() });
                        tr.Cells.Add(c);
                    }
                    if (i != 0 && i != 1 && i != 6)
                    {
                        var evaluated = (from evd in db.SixMonthPlans
                                         where evd.PlanName == eAM.Id && evd.PlanSetByEmployeeId == loggerId && evd.PlanSetForEmployeeId == Convert.ToInt32(Session["EmployeeSelectedToBeEvaluated"]) &&
                             evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && evd.PlanName != 24
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

                }
                Table1.Rows.Add(tr);
                rowcounter++;
            }
        }

        protected void btnCleare_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string selectedLanguage = Session["SelectedLanguage"].ToString();
            string loggedINCompanyId = Session["LogedInUserCompanyId"].ToString();
            int evaluatorId = (from Em in db.Employees where Em.CompanyId == loggedINCompanyId select Em).SingleOrDefault().Id;
            // if (selectedLanguage == "AM")
            // {
            int co = Table1.Rows.Count;
            for (int k = 1; k < co; k++)
            {
                DataAccess.SixMonthPlan ep = new DataAccess.SixMonthPlan();
                ep.PlanSetByEmployeeId = evaluatorId;
                ep.PlanSetForEmployeeId = Convert.ToInt32(Session["EmployeeSelectedToBeEvaluated"]);
                ep.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                ep.DatePlanned = DateTime.Now;
                Label lblQid = (Label)Table1.Rows[k].Cells[6].FindControl(selectedLanguage + k.ToString());
                ep.PlanName = Convert.ToInt32(lblQid.Text);
                ep.IsSubmitted = false;

                DataAccess.SixMonthPlan checkExistance = (from cex in db.SixMonthPlans
                                                          where cex.PlanSetByEmployeeId == evaluatorId && cex.PlanSetForEmployeeId ==Convert.ToInt32(Session["EmployeeSelectedToBeEvaluated"]) &&
                                                          cex.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                          cex.PlanName == Convert.ToInt32(lblQid.Text)
                                                          select cex).FirstOrDefault();
                if (checkExistance != null)
                {
                    for (int i = 2; i < 6; i++)
                    {
                        TableCell tc = Table1.Rows[k].Cells[i];
                        Label theId = (Label)Table1.Rows[k].Cells[0].FindControl(k.ToString());
                        RadioButton rb = (RadioButton)tc.FindControl(theId.Text.ToString() + selectedLanguage + i);
                        bool ischecked = rb.Checked;
                        if (ischecked)
                        {
                            char t = rb.ID.Last();
                            checkExistance.PriorityGiven = t.ToString();
                        }
                        db.SubmitChanges();
                    }
                }
                else
                {
                    for (int i = 2; i < 6; i++)
                    {
                        TableCell tc = Table1.Rows[k].Cells[i];
                        Label theId = (Label)Table1.Rows[k].Cells[0].FindControl(k.ToString());
                        RadioButton rb = (RadioButton)tc.FindControl(theId.Text.ToString() + selectedLanguage + i);
                        bool ischecked = rb.Checked;
                        if (ischecked)
                        {
                            char t = rb.ID.Last();
                            ep.PriorityGiven = t.ToString();
                        }                        
                    }
                    db.SixMonthPlans.InsertOnSubmit(ep);
                    db.SubmitChanges();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSelectEmployee_Click(object sender, EventArgs e)
        {
            Session["EmployeeSelectedToBeEvaluated"] = Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue);
            BtnSave.Enabled = true;
            btnSubmit.Enabled = true;
            btnCleare.Enabled = true;
            for (int i = 1; i < Table1.Rows.Count;)
            {
                Table1.Rows.RemoveAt(i);
            }
            this.Page_Load(null, EventArgs.Empty);
        }
    }
}