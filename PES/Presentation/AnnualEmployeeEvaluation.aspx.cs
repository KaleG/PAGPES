using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class AnnualEmployeeEvaluation : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserLoggedInID1"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                Session["PageTitle"] = this.Title.ToString();

                if (Session["SelectedEmployeeFromDDL"] != null)
                {
                    BtnClearForm.Enabled = true;
                    BtnClearTable.Enabled = true;
                    BtnClearYesNo.Enabled = true;
                    BtnSaveForm.Enabled = true;
                    BtnSAveTable.Enabled = true;
                    BtnSaveYesNo.Enabled = true;
                }

                var EpointsAM = (from ev in db.LKLineMgrFeedBAckPoints where ev.DataTypes == 3 select ev).ToList();
                int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);
                Session["LoggedINEMployee"] = loggerId;
                             

                int rows = EpointsAM.Count;
                int cols = 9;

                int rowcounter = 1;

                foreach (var eAM in EpointsAM)
                {
                    TableRow tr = new TableRow();
                    for (int i = 0; i < cols; i++)
                    {
                        TableCell c = new TableCell();
                        if (i == 0)
                        {
                            c.Controls.Add(new Label() { ID = "K" + rowcounter.ToString(), Text = rowcounter.ToString() });
                            tr.Cells.Add(c);
                        }
                        if (i == 1)
                        {
                            if (Session["SelectedLanguage"].ToString() == "AM")
                            {
                                c.Controls.Add(new Label() { Text = eAM.EvaluationNameAmharic.ToString() });
                                tr.Cells.Add(c);
                            }
                            else
                            {
                                c.Controls.Add(new Label() { Text = eAM.EvaluationName.ToString() });
                                tr.Cells.Add(c);
                            }
                        }
                        if (i != 0 && i != 1 && i != 8)
                        {
                            var evaluated = (from evd in db.AnnualLineManagerEvaluations
                                             where evd.EvaluationPointName == eAM.Id
             && evd.EmployeeId == Convert.ToInt32(Session["SelectedEmployeeFromDDL"]) &&
             evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                             select evd).SingleOrDefault();
                            if (evaluated != null && Convert.ToInt32(evaluated.EvaluationPointGiven) == i)
                            {
                                c.Controls.Add(new RadioButton() { ID = "K" + rowcounter.ToString() + "AM" + i, Checked = true, GroupName = eAM.EvaluationName.ToString() });
                                tr.Cells.Add(c);
                            }
                            else
                            {
                                c.Controls.Add(new RadioButton() { ID = "K" + rowcounter.ToString() + "AM" + i, GroupName = eAM.EvaluationName.ToString() });
                                tr.Cells.Add(c);
                            }
                        }
                        if (i == 8)
                        {
                            c.Controls.Add(new Label() { ID = "AM" + rowcounter.ToString(), Text = eAM.Id.ToString() });
                            tr.Cells.Add(c);
                            tr.Cells[8].Visible = false;
                        }
                    }
                    Table1.Rows.Add(tr);
                    rowcounter++;
                }
            }
            catch (Exception ex) {
                string err = ex.Message;
            }
        }

        protected void BtnClearForm_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                var checkExist = (from x in db.AnnualEmployeeEvaluationNotes
                                  where x.EmployeeId == Convert.ToInt32(Session["SelectedEmployeeFromDDL"])
    && x.LineManagerId == Convert.ToInt32(Session["loggerId"]) &&
    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();
                if (checkExist != null)
                {
                    db.AnnualEmployeeEvaluationNotes.DeleteOnSubmit(checkExist);
                    db.SubmitChanges();

                    TbxDirectOpertional.Text = string.Empty;
                    TbxAdministrative.Text = string.Empty;
                    TbxClientHandling.Text = string.Empty;
                    TbxGeneral.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        protected void BtnSaveForm_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                var checkExist = (from x in db.AnnualEmployeeEvaluationNotes
                                  where x.EmployeeId == Convert.ToInt32(Session["SelectedEmployeeFromDDL"])
    && x.LineManagerId == Convert.ToInt32(Session["loggerId"]) &&
    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();
                if (checkExist != null)
                {
                    checkExist.evaluationDate = DateTime.Now.Date;
                    checkExist.DirectJobRElated = TbxDirectOpertional.Text.ToString();
                    checkExist.AdministrativeRalated = TbxAdministrative.Text.ToString();
                    checkExist.ClientHandlingRElated = TbxClientHandling.Text.ToString();
                    checkExist.General = TbxGeneral.Text.ToString();
                }
                else
                {
                    DataAccess.AnnualEmployeeEvaluationNote AEN = new DataAccess.AnnualEmployeeEvaluationNote()
                    {
                        EmployeeId = Convert.ToInt32(Session["SelectedEmployeeFromDDL"]),
                        LineManagerId = Convert.ToInt32(Session["loggerId"]),
                        EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]),
                        evaluationDate = DateTime.Now.Date,
                        DirectJobRElated = TbxDirectOpertional.Text.ToString(),
                        AdministrativeRalated = TbxAdministrative.Text.ToString(),
                        ClientHandlingRElated = TbxClientHandling.Text.ToString(),
                        General = TbxGeneral.Text.ToString()
                    };
                    db.AnnualEmployeeEvaluationNotes.InsertOnSubmit(AEN);
                }
                db.SubmitChanges();
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }

        protected void BtnClearTable_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                string selectedLanguage = Session["SelectedLanguage"].ToString();
                string loggedINCompanyId = Session["LogedInUserCompanyId"].ToString();
                int evaluatorId = (from Em in db.Employees where Em.CompanyId == loggedINCompanyId select Em).SingleOrDefault().Id;

                List<DataAccess.AnnualLineManagerEvaluation> ToBeDeleted = (from cex in db.AnnualLineManagerEvaluations
                                                                            where cex.EmployeeId == Convert.ToInt32(Session["SelectedEmployeeFromDDL"]) &&
                                                                            cex.EvaluatorLineMgrId == evaluatorId &&
                                                                            cex.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                            select cex).ToList();

                db.AnnualLineManagerEvaluations.DeleteAllOnSubmit(ToBeDeleted);
                db.SubmitChanges();
            }
            catch (Exception ex) {
                string err = ex.Message;
            }
        }

        protected void BtnSAveTable_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                string selectedLanguage = Session["SelectedLanguage"].ToString();
                string loggedINCompanyId = Session["LogedInUserCompanyId"].ToString();
                int evaluatorId = (from Em in db.Employees where Em.CompanyId == loggedINCompanyId select Em).SingleOrDefault().Id;

                int co = Table1.Rows.Count;
                for (int k = 1; k < co; k++)
                {
                    DataAccess.AnnualLineManagerEvaluation ep = new DataAccess.AnnualLineManagerEvaluation();
                    ep.EmployeeId = Convert.ToInt32(Convert.ToInt32(Session["SelectedEmployeeFromDDL"]));
                    ep.EvaluatorLineMgrId = evaluatorId;
                    ep.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                    ep.EvaluatinDate = DateTime.Now.Date;
                    Label lblQid = (Label)Table1.Rows[k].Cells[8].FindControl("AM" + k.ToString());
                    ep.EvaluationPointName = Convert.ToInt32(lblQid.Text);
                    ep.IsSubmitted = true;

                    DataAccess.AnnualLineManagerEvaluation checkExistance = (from cex in db.AnnualLineManagerEvaluations
                                                                             where cex.EmployeeId == Convert.ToInt32(Convert.ToInt32(Session["SelectedEmployeeFromDDL"])) &&
                                                                             cex.EvaluatorLineMgrId == evaluatorId &&
                                                                             cex.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                                             cex.EvaluationPointName == Convert.ToInt32(lblQid.Text)
                                                                             select cex).FirstOrDefault();
                    if (checkExistance != null)
                    {
                        for (int i = 2; i < 8; i++)
                        {
                            TableCell tc = Table1.Rows[k].Cells[i];
                            Label theId = (Label)Table1.Rows[k].Cells[0].FindControl("K" + k.ToString());
                           // RadioButton rb = (RadioButton)tc.FindControl(theId.Text.ToString() + "AM" + i);
                            RadioButton rb = (RadioButton)tc.FindControl("K"+k.ToString() + "AM" + i);
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
                        for (int i = 2; i < 8; i++)
                        {
                            TableCell tc = Table1.Rows[k].Cells[i];
                            Label theId = (Label)Table1.Rows[k].Cells[0].FindControl("K" + k.ToString());
                           // RadioButton rb = (RadioButton)tc.FindControl(theId.Text.ToString() + "AM" + i);
                            RadioButton rb = (RadioButton)tc.FindControl("K" + k.ToString() + "AM" + i);
                            bool ischecked = rb.Checked;
                            if (ischecked)
                            {
                                char t = rb.ID.Last();
                                ep.EvaluationPointGiven = t.ToString();
                            }
                        }
                        db.AnnualLineManagerEvaluations.InsertOnSubmit(ep);
                        db.SubmitChanges();
                    }
                }
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex) {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }

        protected void BtnClearYesNo_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSaveYesNo_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                DataAccess.AnnualEmployeeEvaluationYesNo AE = (from x in db.AnnualEmployeeEvaluationYesNos
                                                               where
                  x.EmployeeId == Convert.ToInt32(Session["SelectedEmployeeFromDDL"]) &&
                  x.LineManagerId == Convert.ToInt32(Session["loggerId"]) &&
                  x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                               select x).SingleOrDefault();
                if (AE != null)
                {
                    AE.FullySuccessfull = Q1G.SelectedValue.ToString();
                    AE.OutStandingPerformance = Q2G.SelectedValue.ToString();
                    AE.Unsatisfactory = Q3G.SelectedValue.ToString();
                    AE.ShouldBePromoted = Q4G.SelectedValue.ToString();
                    
                }
                else {
                    DataAccess.AnnualEmployeeEvaluationYesNo AENew = new DataAccess.AnnualEmployeeEvaluationYesNo() { 
                        EmployeeId= Convert.ToInt32(Session["SelectedEmployeeFromDDL"]),
                        LineManagerId=Convert.ToInt32(Session["loggerId"]),
                        EvaluationPeriod= Convert.ToInt32(Session["EvaluationPeriod"]),
                       FullySuccessfull=Q1G.SelectedValue.ToString(),
                       OutStandingPerformance= Q2G.SelectedValue.ToString(),
                       Unsatisfactory= Q3G.SelectedValue.ToString(),
                       ShouldBePromoted= Q4G.SelectedValue.ToString(),
                };
                    db.AnnualEmployeeEvaluationYesNos.InsertOnSubmit(AENew);
                }
                db.SubmitChanges();
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception exx) {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }
        protected void BtnSelectEmployee_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                BtnClearForm.Enabled = true;
                BtnClearTable.Enabled = true;
                BtnClearYesNo.Enabled = true;
                BtnSaveForm.Enabled = true;
                BtnSAveTable.Enabled = true;
                BtnSaveYesNo.Enabled = true;

                TbxAdministrative.Text = string.Empty;
                TbxClientHandling.Text = string.Empty;
                TbxDirectOpertional.Text = string.Empty;
                TbxGeneral.Text = string.Empty;

                //Q1G.Items.FindByValue("Yes").Selected = false;
                //Q1G.Items.FindByValue("No").Selected = false;
                // Q2G.Items.FindByValue("Yes").Selected = false;
                //Q2G.Items.FindByValue("No").Selected = false;
                // Q3G.Items.FindByValue("Yes").Selected = false;
                //Q3G.Items.FindByValue("No").Selected = false;
                // Q4G.Items.FindByValue("Yes").Selected = false;
                //Q4G.Items.FindByValue("No").Selected = false;
                
                Session["SelectedEmployeeFromDDL"] = Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue);
                for (int i = 1; i < Table1.Rows.Count;)
                {
                    Table1.Rows.RemoveAt(i);
                }

                var checkExist = (from x in db.AnnualEmployeeEvaluationNotes
                                  where x.EmployeeId == Convert.ToInt32(Session["SelectedEmployeeFromDDL"]) &&
                                  x.LineManagerId == Convert.ToInt32(Session["loggerId"]) &&
    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();
                if (checkExist != null)
                {
                    TbxDirectOpertional.Text = checkExist.DirectJobRElated.ToString();
                    TbxAdministrative.Text = checkExist.AdministrativeRalated.ToString();
                    TbxClientHandling.Text = checkExist.ClientHandlingRElated.ToString();
                    TbxGeneral.Text = checkExist.General.ToString();
                }

     //           var checkExist2 = (from x in db.AnnualEmployeeEvaluationYesNos
     //                              where x.EmployeeId == Convert.ToInt32(Session["SelectedEmployeeFromDDL"]) &&
     //                              x.LineManagerId == Convert.ToInt32(Session["loggerId"]) &&
     //x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
     //                              select x).SingleOrDefault();

     //           if (checkExist2 != null)
     //           {
     //               TbxDirectOpertional.Text = checkExist.DirectJobRElated.ToString();
     //               TbxAdministrative.Text = checkExist.AdministrativeRalated.ToString();
     //               TbxClientHandling.Text = checkExist.ClientHandlingRElated.ToString();
     //               TbxGeneral.Text = checkExist.General.ToString();
     //           }

                var checkYesNo = (from x in db.AnnualEmployeeEvaluationYesNos
                                  where x.EmployeeId == Convert.ToInt32(Session["SelectedEmployeeFromDDL"]) &&
    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();
                if (checkYesNo != null)
                {
                    Q1G.SelectedIndex = Q1G.Items.IndexOf(Q1G.Items.FindByValue(checkYesNo.FullySuccessfull.ToString()));
                    Q2G.SelectedIndex = Q2G.Items.IndexOf(Q2G.Items.FindByValue(checkYesNo.OutStandingPerformance.ToString()));
                    Q3G.SelectedIndex = Q3G.Items.IndexOf(Q3G.Items.FindByValue(checkYesNo.Unsatisfactory.ToString()));
                    Q4G.SelectedIndex = Q4G.Items.IndexOf(Q4G.Items.FindByValue(checkYesNo.ShouldBePromoted.ToString()));
                }

                var EpointsAM = (from ev in db.LKLineMgrFeedBAckPoints where ev.DataTypes == 3 select ev).ToList();
                int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);
                Session["LoggedINEMployee"] = loggerId;

                int rows = EpointsAM.Count;
                int cols = 9;

                int rowcounter = 1;

                foreach (var eAM in EpointsAM)
                {
                    TableRow tr = new TableRow();
                    for (int i = 0; i < cols; i++)
                    {
                        TableCell c = new TableCell();
                        if (i == 0)
                        {
                            c.Controls.Add(new Label() { ID = "K" + rowcounter.ToString(), Text = rowcounter.ToString() });
                            tr.Cells.Add(c);
                        }
                        if (i == 1)
                        {
                            if (Session["SelectedLanguage"].ToString() == "AM")
                            {
                                c.Controls.Add(new Label() { Text = eAM.EvaluationNameAmharic.ToString() });
                                tr.Cells.Add(c);
                            }
                            else
                            {
                                c.Controls.Add(new Label() { Text = eAM.EvaluationName.ToString() });
                                tr.Cells.Add(c);
                            }
                        }
                        if (i != 0 && i != 1 && i != 8)
                        {
                            var evaluated = (from evd in db.AnnualLineManagerEvaluations
                                             where evd.EvaluationPointName == eAM.Id
             && evd.EmployeeId == Convert.ToInt32(Session["SelectedEmployeeFromDDL"]) &&
             evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                             select evd).SingleOrDefault();
                            if (evaluated != null && Convert.ToInt32(evaluated.EvaluationPointGiven) == i)
                            {
                                c.Controls.Add(new RadioButton() { ID = "K" + rowcounter.ToString() + "AM" + i, Checked = true, GroupName = eAM.EvaluationName.ToString() });
                                tr.Cells.Add(c);
                            }
                            else
                            {
                                c.Controls.Add(new RadioButton() { ID = "K" + rowcounter.ToString() + "AM" + i, GroupName = eAM.EvaluationName.ToString() });
                                tr.Cells.Add(c);
                            }
                        }
                        if (i == 8)
                        {
                            c.Controls.Add(new Label() { ID = "AM" + rowcounter.ToString(), Text = eAM.Id.ToString() });
                            tr.Cells.Add(c);
                            tr.Cells[8].Visible = false;
                        }
                    }
                    Table1.Rows.Add(tr);
                    rowcounter++;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                //Response.Write(ex.Message);
                Response.Write("<script>alert('Incorrect Data Sent - Possible solution - Please Select the Correct Employee');</script>");
            }
        }

        protected void DDLEvaluatedEmployee_DataBound(object sender, EventArgs e)
        {
            DDLEvaluatedEmployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("  ------   Please Select Employee   ------", ""));
        }
    }
}