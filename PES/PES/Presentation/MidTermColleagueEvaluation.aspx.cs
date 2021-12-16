using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class MidTermColleagueEvaluation : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        int EmployeeSelectedToBeEvaluated;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            var EpointsAM = (from ev in db.LKEvaluationPoints where ev.Language == Session["SelectedLanguage"].ToString() && ev.DataTypes == 3 select ev).ToList();
            int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);

            if (Session["SelectedLanguage"].ToString() == "AM")
            {
                LblAdditionalAM.Visible = true;
                LblAdditionalEN.Visible = false;
                LblIntroHeaderEN.Visible = false;
                LblIntroHeaderAM.Visible = true;
            }
            else
            {
                LblAdditionalAM.Visible = false;
                LblAdditionalEN.Visible = true;
                LblIntroHeaderEN.Visible = true;
                LblIntroHeaderAM.Visible = false;
            }
            int rows = EpointsAM.Count;
            int cols = 7;

            int rowcounter = 1;

            var evaluated23 = (from evd in db.EvaluatedPoints
                              where evd.EvaluationPointName == 24
&& evd.EmployeeId == Convert.ToInt32(Session["EmployeeSelectedToBeEvaluated"]) && evd.EvaluatorId == loggerId &&
evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                              select evd).SingleOrDefault();

            if (evaluated23 != null)
            {
                TARAdditionalPoints.InnerText = evaluated23.EvaluationPointGiven.ToString();
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
                        c.Controls.Add(new Label() { ID = (rowcounter + eAM.Language).ToString(), Text = eAM.EvaluationName.ToString() });
                        tr.Cells.Add(c);
                    }
                    if (i != 0 && i != 1 && i != 6)
                    {
                        var evaluated = (from evd in db.EvaluatedPoints
                                         where evd.EvaluationPointName == eAM.Id
         && evd.EmployeeId == Convert.ToInt32(Session["EmployeeSelectedToBeEvaluated"]) && evd.EvaluatorId == loggerId &&
         evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && evd.EvaluationPointName != 24
                                         select evd).SingleOrDefault();
                        if (evaluated != null && Convert.ToInt32(evaluated.EvaluationPointGiven) == i)
                        {
                            c.Controls.Add(new RadioButton() { ID = (rowcounter + eAM.Language + i).ToString(), Checked = true, GroupName = eAM.EvaluationName.ToString() });
                            tr.Cells.Add(c);
                        }
                        else
                        {
                            c.Controls.Add(new RadioButton() { ID = (rowcounter + eAM.Language + i).ToString(), GroupName = eAM.EvaluationName.ToString() });
                            tr.Cells.Add(c);
                        }
                    }
                    if (i == 6)
                    {
                        c.Controls.Add(new Label() { ID = eAM.Language + rowcounter.ToString(), Text = eAM.Id.ToString() });
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
            string selectedLanguage = Session["SelectedLanguage"].ToString();
            string loggedINCompanyId = Session["LogedInUserCompanyId"].ToString();
            int evaluatorId = (from Em in db.Employees where Em.CompanyId == loggedINCompanyId select Em).SingleOrDefault().Id;

             List<DataAccess.EvaluatedPoint> ToBeDeleted = (from cex in db.EvaluatedPoints
                                                            where cex.EmployeeId == EmployeeSelectedToBeEvaluated &&
                                                            cex.EvaluatorId == evaluatorId &&
                                                            cex.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                            cex.IsSubmitted == false
                                                            select cex).ToList();

             db.EvaluatedPoints.DeleteAllOnSubmit(ToBeDeleted);
             db.SubmitChanges();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string selectedLanguage = Session["SelectedLanguage"].ToString();
            string loggedINCompanyId = Session["LogedInUserCompanyId"].ToString();
            int evaluatorId = (from Em in db.Employees where Em.CompanyId == loggedINCompanyId select Em).SingleOrDefault().Id;
            
            int co = Table1.Rows.Count;
                for (int k = 1; k < co; k++)
                {
                    DataAccess.EvaluatedPoint ep = new DataAccess.EvaluatedPoint();
                    ep.EmployeeId = Convert.ToInt32(Session["EmployeeSelectedToBeEvaluated"]);
                    ep.EvaluatorId = evaluatorId;
                    ep.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                    ep.evaluationDate = DateTime.Now;
                    Label lblQid = (Label)Table1.Rows[k].Cells[6].FindControl(selectedLanguage + k.ToString());
                    ep.EvaluationPointName = Convert.ToInt32(lblQid.Text);
                    ep.IsSubmitted = false;

                    DataAccess.EvaluatedPoint checkExistance = (from cex in db.EvaluatedPoints
                                                                where cex.EmployeeId == Convert.ToInt32(Session["EmployeeSelectedToBeEvaluated"]) &&
                                                                cex.EvaluatorId == evaluatorId &&
                                                                cex.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                                cex.EvaluationPointName == Convert.ToInt32(lblQid.Text)
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
                                checkExistance.EvaluationPointGiven = t.ToString();
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
                                ep.EvaluationPointGiven = t.ToString();
                            }
                        }
                        db.EvaluatedPoints.InsertOnSubmit(ep);
                        db.SubmitChanges();
                    }
                }

             DataAccess.EvaluatedPoint checkExistance23 = (from cext in db.EvaluatedPoints
                                                          where cext.EmployeeId == Convert.ToInt32(Session["EmployeeSelectedToBeEvaluated"]) &&
                                                          cext.EvaluatorId == evaluatorId &&
                                                          cext.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                          cext.EvaluationPointName == 24
                                                          select cext).SingleOrDefault();
             //int theeidd = checkExistance2.Id;
             if (checkExistance23 != null)
             {
                 checkExistance23.EvaluationPointGiven = TARAdditionalPoints.InnerText.ToString();
                 db.SubmitChanges();
             }
             else
             {
                 DataAccess.EvaluatedPoint ep2 = new DataAccess.EvaluatedPoint();
                 ep2.EmployeeId = Convert.ToInt32(Session["EmployeeSelectedToBeEvaluated"]);
                 ep2.EvaluatorId = evaluatorId;
                 ep2.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                 ep2.evaluationDate = DateTime.Now;
                 ep2.EvaluationPointName = 24;
                 ep2.EvaluationPointGiven = TARAdditionalPoints.InnerText.ToString();
                 ep2.IsSubmitted = false;
                 db.EvaluatedPoints.InsertOnSubmit(ep2);
                 db.SubmitChanges();
             }
            Session.Remove("EmployeeSelectedToBeEvaluated");

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
            this.Page_Load(null,EventArgs.Empty);
        }
    }
}