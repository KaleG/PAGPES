using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class Next6MonthPlans : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();
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
                        if (Session["SelectedLanguage"].ToString() == "AM")
                        {
                            c.Controls.Add(new Label() { ID = (rowcounter + "EN").ToString(), Text = eAM.PlanNameAmharic.ToString() });
                            tr.Cells.Add(c);
                        }
                        else
                        {
                            c.Controls.Add(new Label() { ID = (rowcounter + "EN").ToString(), Text = eAM.PlanName.ToString() });
                            tr.Cells.Add(c);
                        }
                    }
                    if (i != 0 && i != 1 && i != 6 && i != 5)
                    {
                        var evaluated = (from evd in db.SixMonthPlans
                                         where evd.PlanName == eAM.Id && evd.PlanSetByEmployeeId == loggerId && evd.PlanSetForEmployeeId == loggerId &&
                             evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && evd.PlanName != 22
                                         select evd).SingleOrDefault();
                        if (evaluated != null && Convert.ToInt32(evaluated.PriorityGiven) == i)
                        {
                            c.Controls.Add(new RadioButton() { ID = (rowcounter + "EN" + i).ToString(), Checked = true, GroupName = eAM.PlanName.ToString() });
                            tr.Cells.Add(c);
                        }
                        else
                        {
                            c.Controls.Add(new RadioButton() { ID = (rowcounter + "EN" + i).ToString(), GroupName = eAM.PlanName.ToString() });
                            tr.Cells.Add(c);
                        }
                    }
                    if (i == 5)
                    {
                        DataAccess.SixMonthPlan evaluatedRemark = (from evd in db.SixMonthPlans
                                         where evd.PlanName == eAM.Id && evd.PlanSetByEmployeeId == loggerId && evd.PlanSetForEmployeeId == loggerId &&
                             evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && evd.PlanName != 22 && evd.UserRemark !=null
                                         select evd).SingleOrDefault();
                        if (evaluatedRemark != null)
                        {
                            c.Controls.Add(new TextBox() { ID = ("Tbx" + rowcounter).ToString(),Text= evaluatedRemark.UserRemark.ToString(),CssClass= "form-control formTbx",TextMode=TextBoxMode.MultiLine ,Rows=1});
                            tr.Cells.Add(c);
                        }
                        else
                        {
                            c.Controls.Add(new TextBox() { ID = ("Tbx" + rowcounter).ToString(), CssClass = "form-control formTbx", TextMode = TextBoxMode.MultiLine, Rows = 1 });
                            tr.Cells.Add(c);
                        }
                    }                
                    if (i == 6)
                    {
                        c.Controls.Add(new Label() { ID = "EN" + rowcounter.ToString(), Text = eAM.Id.ToString() });
                        tr.Cells.Add(c);
                        tr.Cells[6].Visible = false;
                    }

                }
                Table1.Rows.Add(tr);
                rowcounter++;
            }
            // }

            // if (Session["SelectedLanguage"].ToString() == "AM")




            if (!IsPostBack)
            {
                var evaluated2 = (from evd in db.SixMonthPlans
                                  where evd.PlanName == 22
    && evd.PlanSetForEmployeeId == loggerId && evd.PlanSetByEmployeeId == loggerId &&
    evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select evd).SingleOrDefault();

                if (evaluated2 != null)
                {
                    TARAdditionalPoints.Text = evaluated2.PriorityGiven.ToString();
                }
            }

        }
    

        protected void btnCleare_Click(object sender, EventArgs e)
        {
           // string selectedLanguage = Session["SelectedLanguage"].ToString();
            string loggedINCompanyId = Session["LogedInUserCompanyId"].ToString();
            int evaluatorId = (from Em in db.Employees where Em.CompanyId == loggedINCompanyId select Em).SingleOrDefault().Id;

            List<DataAccess.SixMonthPlan> ToBeDeleted = (from cex in db.SixMonthPlans
                                                           where cex.PlanSetForEmployeeId == evaluatorId &&
                                                           cex.PlanSetByEmployeeId == evaluatorId &&
                                                           cex.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                           cex.IsSubmitted == false
                                                           select cex).ToList();

            db.SixMonthPlans.DeleteAllOnSubmit(ToBeDeleted);
            db.SubmitChanges();
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
                ep.PlanSetForEmployeeId = evaluatorId;
                ep.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                ep.DatePlanned = DateTime.Now;
                Label lblQid = (Label)Table1.Rows[k].Cells[6].FindControl("EN" + k.ToString());
                ep.PlanName = Convert.ToInt32(lblQid.Text);
                ep.IsSubmitted = false;
                TextBox tbxRemarks = (TextBox)Table1.Rows[k].Cells[5].FindControl("Tbx" + k.ToString());
                ep.UserRemark = tbxRemarks.Text;

                DataAccess.SixMonthPlan checkExistance = (from cex in db.SixMonthPlans
                                                          where cex.PlanSetByEmployeeId == evaluatorId && cex.PlanSetForEmployeeId==evaluatorId &&
                                                          cex.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                          cex.PlanName == Convert.ToInt32(lblQid.Text)
                                                          select cex).FirstOrDefault();
                if (checkExistance != null)
                {
                    for (int i = 2; i < 5; i++)
                    {
                        TableCell tc = Table1.Rows[k].Cells[i];
                        Label theId = (Label)Table1.Rows[k].Cells[0].FindControl(k.ToString());
                        RadioButton rb = (RadioButton)tc.FindControl(theId.Text.ToString() + "EN" + i);
                        bool ischecked = rb.Checked;
                        if (ischecked)
                        {
                            char t = rb.ID.Last();
                            checkExistance.PriorityGiven = t.ToString();                            
                        }
                        checkExistance.UserRemark = tbxRemarks.Text;
                        //db.SubmitChanges();
                    }
                }
                else
                {
                    for (int i = 2; i < 5; i++)
                    {
                        TableCell tc = Table1.Rows[k].Cells[i];
                        Label theId = (Label)Table1.Rows[k].Cells[0].FindControl(k.ToString());
                        RadioButton rb = (RadioButton)tc.FindControl(theId.Text.ToString() + "EN" + i);
                        bool ischecked = rb.Checked;
                        if (ischecked)
                        {
                            char t = rb.ID.Last();
                            ep.PriorityGiven = t.ToString();
                        }
                    }
                        db.SixMonthPlans.InsertOnSubmit(ep);
                       // db.SubmitChanges();                                       
                }
            }

            int planNameIDD = 22;
            //if (selectedLanguage == "AM")
            //{
            //    planNameIDD = 21;
            //}
            //if (selectedLanguage == "EN")
            //{
            //    planNameIDD = 22;
            //}

            
            DataAccess.SixMonthPlan checkExistance234 = (from cext in db.SixMonthPlans
                                                         where cext.PlanSetForEmployeeId == evaluatorId &&
                                                         cext.PlanSetByEmployeeId == evaluatorId &&
                                                         cext.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                         cext.PlanName == planNameIDD
                                                         select cext).SingleOrDefault();
            //int theeidd = checkExistance2.Id;
            if (checkExistance234 != null)
            {
                checkExistance234.PriorityGiven = TARAdditionalPoints.Text.ToString();
                //db.SubmitChanges();
            }
            else
            {
                DataAccess.SixMonthPlan ep2 = new DataAccess.SixMonthPlan();
                ep2.PlanSetForEmployeeId = evaluatorId;
                ep2.PlanSetByEmployeeId = evaluatorId;
                ep2.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                ep2.DatePlanned = DateTime.Now;
                ep2.PlanName = planNameIDD;
                ep2.PriorityGiven = TARAdditionalPoints.Text.ToString();
                ep2.IsSubmitted = false;                
                db.SixMonthPlans.InsertOnSubmit(ep2);
                
            }

            db.SubmitChanges();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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
                ep.PlanSetByEmployeeId = evaluatorId;
                ep.PlanSetForEmployeeId = Convert.ToInt32(Session["EvaluationPeriod"]);
                ep.DatePlanned = DateTime.Now;
                Label lblQid = (Label)Table1.Rows[k].Cells[6].FindControl("EN" + k.ToString());
                ep.PlanName = Convert.ToInt32(lblQid.Text);
                ep.IsSubmitted = true;
                TextBox tbxRemarks = (TextBox)Table1.Rows[k].Cells[5].FindControl("Tbx" + k.ToString());
                ep.UserRemark = tbxRemarks.Text;

                DataAccess.SixMonthPlan checkExistance = (from cex in db.SixMonthPlans
                                                          where cex.PlanSetByEmployeeId == evaluatorId && cex.PlanSetForEmployeeId == evaluatorId &&
                                                          cex.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                          cex.PlanName == Convert.ToInt32(lblQid.Text)
                                                          select cex).FirstOrDefault();
                if (checkExistance != null)
                {
                    for (int i = 2; i < 5; i++)
                    {
                        TableCell tc = Table1.Rows[k].Cells[i];
                        Label theId = (Label)Table1.Rows[k].Cells[0].FindControl(k.ToString());
                        RadioButton rb = (RadioButton)tc.FindControl(theId.Text.ToString() + "EN" + i);
                        bool ischecked = rb.Checked;
                        if (ischecked)
                        {
                            char t = rb.ID.Last();
                            checkExistance.PriorityGiven = t.ToString();
                            checkExistance.IsSubmitted = true;
                        }
                        db.SubmitChanges();
                    }
                }
                else
                {
                    for (int i = 2; i < 5; i++)
                    {
                        TableCell tc = Table1.Rows[k].Cells[i];
                        Label theId = (Label)Table1.Rows[k].Cells[0].FindControl(k.ToString());
                        RadioButton rb = (RadioButton)tc.FindControl(theId.Text.ToString() + "EN" + i);
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

            int planNameIDD = 22;
            //if (selectedLanguage == "AM")
            //{
            //    planNameIDD = 21;
            //}
            //if (selectedLanguage == "EN")
            //{
            //    planNameIDD = 22;
            //}

            DataAccess.SixMonthPlan checkExistance234 = (from cext in db.SixMonthPlans
                                                         where cext.PlanSetForEmployeeId == evaluatorId &&
                                                         cext.PlanSetByEmployeeId == evaluatorId &&
                                                         cext.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                         cext.PlanName == planNameIDD
                                                         select cext).SingleOrDefault();
            //int theeidd = checkExistance2.Id;
            if (checkExistance234 != null)
            {
                checkExistance234.PriorityGiven = TARAdditionalPoints.Text.ToString();
                checkExistance234.IsSubmitted = true;
                db.SubmitChanges();
            }
            else
            {
                DataAccess.SixMonthPlan ep2 = new DataAccess.SixMonthPlan();
                ep2.PlanSetForEmployeeId = evaluatorId;
                ep2.PlanSetByEmployeeId = evaluatorId;
                ep2.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                ep2.DatePlanned = DateTime.Now;
                ep2.PlanName = planNameIDD;
                ep2.PriorityGiven = TARAdditionalPoints.Text.ToString();
                ep2.IsSubmitted = true;
                db.SixMonthPlans.InsertOnSubmit(ep2);
                db.SubmitChanges();
            }
        }
    }
}