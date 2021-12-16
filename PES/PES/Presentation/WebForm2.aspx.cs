using PES.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PES.Presentation
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            var EpointsAM = (from ev in db.LKEvaluationPoints where ev.Language == "AM" && ev.DataTypes==3 select ev).ToList();
            var EpointsEN = (from ev in db.LKEvaluationPoints where ev.Language == "EN" && ev.DataTypes == 3 select ev).ToList();
            int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);


          /*  if (!IsPostBack)
            {
                if (Session["SelectedLanguage"] == null)
                {
                    Session["SelectedLanguage"] = "AM";
                }
            }*/
            if (Session["SelectedLanguage"].ToString() == "AM")
            {                
                LblAdditionalEN.Visible = false;
                LblAdditionalAM.Visible = true;
               LblIntroHeaderEN.Visible = false;
                LblIntroHeaderAM.Visible = true;
                int rows = EpointsAM.Count;
                int cols = 7;

                int rowcounter = 1;

                var evaluated2 = (from evd in db.EvaluatedPoints
                                  where evd.EvaluationPointName == 24
  && evd.EmployeeId == loggerId && evd.EvaluatorId == loggerId &&
  evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select evd).SingleOrDefault();

                if (evaluated2 != null)
                {
                    TARAdditionalPoints.InnerText = evaluated2.EvaluationPointGiven.ToString();
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
                            // tr2.Cells.Add(c);
                            // c.Controls.Add(new LiteralControl((eAM.Id).ToString()));
                            tr.Cells.Add(c);
                        }
                        if (i == 1)
                        {
                            c.Controls.Add(new Label() { ID = (rowcounter + eAM.Language).ToString(), Text = eAM.EvaluationName.ToString() });
                            //c.Controls.Add(new LiteralControl(eAM.EvaluationName));
                            tr.Cells.Add(c);
                        }
                        if (i != 0 && i != 1 && i != 6)
                        {
                            var evaluated = (from evd in db.EvaluatedPoints
                                             where evd.EvaluationPointName == eAM.Id
             && evd.EmployeeId == loggerId && evd.EvaluatorId == loggerId &&
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

            else
            {
                // AmharicHeader.Visible = false;
                // englishHeader.Visible = true;
                LblAdditionalAM.Visible = false;
                LblAdditionalEN.Visible = true;
                LblIntroHeaderEN.Visible = true;
                LblIntroHeaderAM.Visible = false;
                int rows = EpointsEN.Count;
                int cols = 7;

                int rowNumber = 1;

                var evaluated2 = (from evd in db.EvaluatedPoints
                                  where evd.EvaluationPointName == 23
                                  && evd.EmployeeId == loggerId && evd.EvaluatorId == loggerId &&
                                  evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select evd).SingleOrDefault();
                if (evaluated2 != null)
                {
                    TARAdditionalPoints.InnerText = evaluated2.EvaluationPointGiven.ToString();
                }

                foreach (var eEN in EpointsEN)
                {
                    TableRow tr2 = new TableRow();

                    for (int i = 0; i < cols; i++)
                    {
                        TableCell c = new TableCell();
                        if (i == 0)
                        {
                            //c.Controls.Add(new LiteralControl((eEN.Id).ToString()));
                            c.Controls.Add(new Label() { ID = rowNumber.ToString(), Text = rowNumber.ToString() });
                            tr2.Cells.Add(c);
                        }
                        if (i == 1)
                        {
                            c.Controls.Add(new Label() { ID = (rowNumber + eEN.Language).ToString(), Text = eEN.EvaluationName.ToString() });
                            // c.Controls.Add(new LiteralControl(eEN.EvaluationName));
                            tr2.Cells.Add(c);
                        }
                        if (i != 0 && i != 1 && i != 6)
                        //else
                        {

                            var evaluated = (from evd in db.EvaluatedPoints
                                             where evd.EvaluationPointName == eEN.Id
             && evd.EmployeeId == loggerId && evd.EvaluatorId == loggerId &&
             evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && evd.EvaluationPointName != 23
                                             select evd).SingleOrDefault();
                            if (evaluated != null && Convert.ToInt32(evaluated.EvaluationPointGiven) == i)
                            {
                                c.Controls.Add(new RadioButton() { ID = (rowNumber + eEN.Language + i).ToString(), Checked = true, GroupName = eEN.EvaluationName.ToString() });
                                tr2.Cells.Add(c);
                            }
                            else
                            {
                                c.Controls.Add(new RadioButton() { ID = (rowNumber + eEN.Language + i).ToString(), GroupName = eEN.EvaluationName.ToString() });
                                tr2.Cells.Add(c);
                            }


                        }
                        if (i == 6)
                        {
                            c.Controls.Add(new Label() { ID = eEN.Language + rowNumber.ToString(), Text = eEN.Id.ToString() });
                            tr2.Cells.Add(c);
                            tr2.Cells[6].Visible = false;
                        }
                    }
                    Table1.Rows.Add(tr2);
                    rowNumber++;
                }

            }

        }

        protected void btnCleare_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedLanguage = Session["SelectedLanguage"].ToString();
                string loggedINCompanyId = Session["LogedInUserCompanyId"].ToString();
                int evaluatorId = (from Em in db.Employees where Em.CompanyId == loggedINCompanyId select Em).SingleOrDefault().Id;
                if (selectedLanguage == "AM")
                {
                    int co = Table1.Rows.Count;
                    for (int k = 1; k < co-1; k++)
                    {
                        DataAccess.EvaluatedPoint ep = new DataAccess.EvaluatedPoint();
                        ep.EmployeeId = evaluatorId;
                        ep.EvaluatorId = evaluatorId;
                        ep.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                        ep.evaluationDate = DateTime.Now;
                        Label lblQid = (Label)Table1.Rows[k].Cells[6].FindControl(selectedLanguage + k.ToString());
                        ep.EvaluationPointName = Convert.ToInt32(lblQid.Text);
                        ep.IsSubmitted = false;
                        
                        DataAccess.EvaluatedPoint checkExistance = (from cex in db.EvaluatedPoints
                                              where cex.EmployeeId == evaluatorId &&
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

                    DataAccess.EvaluatedPoint checkExistance2 = (from cext in db.EvaluatedPoints
                                                                 where cext.EmployeeId == evaluatorId &&
                                                                 cext.EvaluatorId == evaluatorId &&
                                                                 cext.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                                 cext.EvaluationPointName == 24
                                                                 select cext).SingleOrDefault();
                    //int theeidd = checkExistance2.Id;
                    if (checkExistance2 != null)
                    {
                        checkExistance2.EvaluationPointGiven = TARAdditionalPoints.InnerText.ToString(); 
                        db.SubmitChanges();
                    }
                    else
                    {
                        DataAccess.EvaluatedPoint ep2 = new DataAccess.EvaluatedPoint();
                        ep2.EmployeeId = evaluatorId;
                        ep2.EvaluatorId = evaluatorId;
                        ep2.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                        ep2.evaluationDate = DateTime.Now;
                        ep2.EvaluationPointName = 24;
                        ep2.EvaluationPointGiven = TARAdditionalPoints.InnerText.ToString();
                        ep2.IsSubmitted = false;
                        db.EvaluatedPoints.InsertOnSubmit(ep2);
                        db.SubmitChanges();
                    }


                }
                if (selectedLanguage == "EN")
                {
                    int co = Table1.Rows.Count;
                    for (int k = 1; k < co - 1; k++)
                    {
                        DataAccess.EvaluatedPoint ep = new DataAccess.EvaluatedPoint();
                        ep.EmployeeId = evaluatorId;
                        ep.EvaluatorId = evaluatorId;
                        ep.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                        ep.evaluationDate = DateTime.Now;
                        Label lblQid = (Label)Table1.Rows[k].Cells[6].FindControl(selectedLanguage + k.ToString());
                        ep.EvaluationPointName = Convert.ToInt32(lblQid.Text);
                        ep.IsSubmitted = false;

                        DataAccess.EvaluatedPoint checkExistance = (from cex in db.EvaluatedPoints
                                                                    where cex.EmployeeId == evaluatorId &&
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
                                    //ep.EvaluationPointGiven = t.ToString();
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
                        DataAccess.EvaluatedPoint checkExistance2 = (from cext in db.EvaluatedPoints
                                                                     where cext.EmployeeId == evaluatorId &&
                                                                     cext.EvaluatorId == evaluatorId &&
                                                                     cext.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                                     cext.EvaluationPointName == 23
                                                                     select cext).SingleOrDefault();
                        //int theeidd = checkExistance2.Id;
                        if (checkExistance2 != null)
                        {
                            checkExistance2.EvaluationPointGiven = TARAdditionalPoints.InnerText.ToString();
                            db.SubmitChanges();
                        }
                        else
                        {
                            DataAccess.EvaluatedPoint ep2 = new DataAccess.EvaluatedPoint();
                            ep2.EmployeeId = evaluatorId;
                            ep2.EvaluatorId = evaluatorId;
                            ep2.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                            ep2.evaluationDate = DateTime.Now;
                            ep2.EvaluationPointName = 23;
                            ep2.EvaluationPointGiven = TARAdditionalPoints.InnerText.ToString();
                            ep2.IsSubmitted = false;
                            db.EvaluatedPoints.InsertOnSubmit(ep2);
                            db.SubmitChanges();
                        }

                    } 
                }
            }
            catch (Exception exx)
            {
                Response.Write(exx.Message);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}