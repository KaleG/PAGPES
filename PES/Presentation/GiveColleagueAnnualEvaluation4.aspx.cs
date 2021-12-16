using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class GiveColleagueAnnualEvaluation4 : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();

            //if (!IsPostBack) {
            //    LinkButton3.Enabled = false;
            //    LinkButton4.Enabled = false;
            //}

            var EpointsAM = (from ev in db.LKColleagueFeedBAckPoints where ev.DataType == 3 select ev).ToList();
            int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);

            var knownEvaluationPoints = (from ev in db.LKColleagueFeedBAckPoints where ev.DataType == 3 select ev).ToList();
            int rows = knownEvaluationPoints.Count;
            int cols = 7;

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
                            c.Controls.Add(new Label() { ID = (eAM.Id.ToString() + eAM.DataType.ToString()), Text = eAM.EvaluationNameAmharic.ToString() });
                            tr.Cells.Add(c);
                        }
                        else
                        {
                            c.Controls.Add(new Label() { ID = (eAM.Id.ToString() + eAM.DataType.ToString()), Text = eAM.EvaluationName.ToString() });
                            tr.Cells.Add(c);
                        }
                    }
                    if (i != 0 && i != 1 && i != 6)
                    {
                        //               var evaluated = (from evd in db.AnnualColleagueEvaluations
                        //                                where evd.EvaluationPointName == eAM.Id
                        //                                && evd.EvaluatorColleagueId == loggerId
                        //&& evd.EmployeeId == Convert.ToInt32(ListBox1.SelectedValue) &&
                        //evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && evd.EvaluationPointName != 15
                        //                                select evd).SingleOrDefault();
                        //               if (evaluated != null && Convert.ToInt32(evaluated.EvaluationPointGiven) == i)
                        //               {
                        //    c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), GroupName = eAM.EvaluationName.ToString() });
                        //    tr.Cells.Add(c);
                        //}
                        //else
                        //{
                        c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), GroupName = eAM.EvaluationName.ToString() });
                        tr.Cells.Add(c);
                        //}
                    }
                    if (i == 6)
                    {
                        c.Controls.Add(new Label() { ID = ("AM" + rowcounter).ToString(), Text = eAM.Id.ToString() });
                        tr.Cells.Add(c);
                        tr.Cells[6].Visible = false;
                    }
                }
                Table1.Rows.Add(tr);
                rowcounter++;
            }



            // }
            // catch (Exception exx) { string err = exx.Message; }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //cleare button clicked

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                ///save button click            
                int co = Table1.Rows.Count;
                for (int k = 1; k < co; k++)
                {
                    DataAccess.AnnualColleagueEvaluation ace = new DataAccess.AnnualColleagueEvaluation();
                    ace.EmployeeId = Convert.ToInt32(Session["SelectedFromListBox"]);
                    ace.EvaluatorColleagueId = Convert.ToInt32(Session["loggerId"]);
                    ace.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                    ace.EavluationDate = DateTime.Now.Date;
                    Label lblQid = (Label)Table1.Rows[k].Cells[6].FindControl("AM" + k.ToString());
                    ace.EvaluationPointName = Convert.ToInt32(lblQid.Text);
                    ace.IsSubmitted = true;

                    DataAccess.AnnualColleagueEvaluation checkExistance = (from cex in db.AnnualColleagueEvaluations
                                                                           where cex.EmployeeId == Convert.ToInt32(Convert.ToInt32(Session["SelectedFromListBox"])) &&
                                                                cex.EvaluatorColleagueId == Convert.ToInt32(Session["loggerId"]) &&
                                                                cex.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                                cex.EvaluationPointName == Convert.ToInt32(lblQid.Text)
                                                                           select cex).FirstOrDefault();
                    if (checkExistance != null)
                    {
                        for (int i = 2; i < 6; i++)
                        {
                            TableCell tc = Table1.Rows[k].Cells[i];
                            Label theId = (Label)Table1.Rows[k].Cells[0].FindControl(k.ToString());
                            RadioButton rb = (RadioButton)tc.FindControl(k + "AM" + i);
                            bool ischecked = rb.Checked;
                            if (ischecked)
                            {
                                char t = rb.ID.Last();
                                checkExistance.EvaluationPointGiven = t.ToString();
                                checkExistance.IsSubmitted = true;
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
                            RadioButton rb = (RadioButton)tc.FindControl(k + "AM" + i);
                            bool ischecked = rb.Checked;
                            if (ischecked)
                            {
                                char t = rb.ID.Last();
                                ace.EvaluationPointGiven = t.ToString();
                            }
                        }
                        db.AnnualColleagueEvaluations.InsertOnSubmit(ace);
                        db.SubmitChanges();
                    }
                }

                bool idontmind = false;

                if (ChkIDontMind.Checked == true)
                {
                    idontmind = true;
                }

                DataAccess.EvaluationDisclosure des = (from de in db.EvaluationDisclosures
                                                       where de.EvaluatedEmployeId == Convert.ToInt32(Convert.ToInt32(Session["SelectedFromListBox"])) &&
                                                        de.EvalutorId == Convert.ToInt32(Session["loggerId"]) &&
                                                        de.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                       select de).SingleOrDefault();
                if (des != null)
                {
                    des.IDontMind = idontmind;
                }
                else
                {
                    DataAccess.EvaluationDisclosure desnew = new DataAccess.EvaluationDisclosure();
                    desnew.EvalutorId = Convert.ToInt32(Session["loggerId"]);
                    desnew.EvaluatedEmployeId = Convert.ToInt32(Convert.ToInt32(Session["SelectedFromListBox"]));
                    desnew.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                    desnew.IDontMind = idontmind;
                    //desnew.AdminOpinionOnDisclosore = true;
                    db.EvaluationDisclosures.InsertOnSubmit(desnew);
                }
                db.SubmitChanges();


                int planNameIDD = 15;

                DataAccess.AnnualColleagueEvaluation checkExistance234 = (from cext in db.AnnualColleagueEvaluations
                                                                          where cext.EmployeeId == Convert.ToInt32(Convert.ToInt32(Session["SelectedFromListBox"])) &&
                                                                          cext.EvaluatorColleagueId == Convert.ToInt32(Session["loggerId"]) &&
                                                                          cext.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                                          cext.EvaluationPointName == planNameIDD
                                                                          select cext).SingleOrDefault();
                //int theeidd = checkExistance2.Id;
                if (checkExistance234 != null)
                {
                    checkExistance234.EvaluationPointGiven = TARAdditionalPoints.Text.ToString();
                    db.SubmitChanges();
                }
                else
                {
                    DataAccess.AnnualColleagueEvaluation ep2 = new DataAccess.AnnualColleagueEvaluation();
                    ep2.EmployeeId = Convert.ToInt32(Convert.ToInt32(Session["SelectedFromListBox"]));
                    ep2.EvaluatorColleagueId = Convert.ToInt32(Session["loggerId"]);
                    ep2.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                    ep2.EavluationDate = DateTime.Now;
                    ep2.EvaluationPointName = planNameIDD;
                    ep2.EvaluationPointGiven = TARAdditionalPoints.Text.ToString();
                    ep2.IsSubmitted = true;
                    db.AnnualColleagueEvaluations.InsertOnSubmit(ep2);
                    db.SubmitChanges();
                }
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('error occurred contact system admins');</script>");
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                //TARAdditionalPoints.Text = string.Empty;
                int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);
                int ColleagueId = System.Convert.ToInt32(ListBox1.SelectedValue);

                DataAccess.Employee_evaluatorColleague ee = (from et in db.Employee_evaluatorColleagues
                                                             where
                  et.EvaluatorColleague == loggerId
                  && et.EmployeeId == ColleagueId
                  && et.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                                             select et).SingleOrDefault();
                db.Employee_evaluatorColleagues.DeleteOnSubmit(ee);
                db.SubmitChanges();
                ListBox1.DataBind();
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex) {
                Response.Write(ex.Message);
            }
        }

        protected void btnEvaluateSelected_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                if (Session["SelectedFromListBox"] != null)
                {
                   // LinkButton3.Attributes.Remove("disabled");
                   // LinkButton4.Attributes.Remove("disabled");
                    LinkButton4.Enabled = true;
                    LinkButton3.Enabled = true;
                }
                Session["SelectedFromListBox"] = ListBox1.SelectedValue;
                TARAdditionalPoints.Text = string.Empty;
                for (int i = 1; i < Table1.Rows.Count;)
                {
                    Table1.Rows.RemoveAt(i);
                }

                var EpointsAM = (from ev in db.LKColleagueFeedBAckPoints where ev.DataType == 3 select ev).ToList();
                int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);


                int rows = EpointsAM.Count;
                int cols = 7;

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
                                c.Controls.Add(new Label() { ID = (eAM.Id.ToString() + eAM.DataType.ToString()), Text = eAM.EvaluationNameAmharic.ToString() });
                                tr.Cells.Add(c);
                            }
                            else
                            {
                                c.Controls.Add(new Label() { ID = (eAM.Id.ToString() + eAM.DataType.ToString()), Text = eAM.EvaluationName.ToString() });
                                tr.Cells.Add(c);
                            }
                        }
                        if (i != 0 && i != 1 && i != 6)
                        {
                            var evaluated = (from evd in db.AnnualColleagueEvaluations
                                             where evd.EvaluationPointName == eAM.Id
                                             && evd.EvaluatorColleagueId == loggerId
             && evd.EmployeeId == Convert.ToInt32(ListBox1.SelectedValue) &&
             evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && evd.EvaluationPointName != 15
                                             select evd).SingleOrDefault();
                            if (evaluated != null && Convert.ToInt32(evaluated.EvaluationPointGiven) == i)
                            {
                                c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), Checked = true, GroupName = eAM.EvaluationName.ToString() });
                                tr.Cells.Add(c);
                            }
                            else
                            {
                                c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), GroupName = eAM.EvaluationName.ToString() });
                                tr.Cells.Add(c);
                            }
                        }
                        if (i == 6)
                        {
                            c.Controls.Add(new Label() { ID = ("AM" + rowcounter).ToString(), Text = eAM.Id.ToString() });
                            tr.Cells.Add(c);
                            tr.Cells[6].Visible = false;
                        }
                    }
                    Table1.Rows.Add(tr);
                    rowcounter++;
                }


                var evaluated233 = (from evd in db.AnnualColleagueEvaluations
                                    where evd.EvaluationPointName == 15
                                    && evd.EvaluatorColleagueId == loggerId
       && evd.EmployeeId == Convert.ToInt32(ListBox1.SelectedValue) &&
       evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                    select evd).SingleOrDefault();

                if (evaluated233 != null)
                {
                    TARAdditionalPoints.Text = evaluated233.EvaluationPointGiven.ToString();
                }

                DataAccess.EvaluationDisclosure Ediscloser = (from d in db.EvaluationDisclosures
                                                              where d.EvaluatedEmployeId == Convert.ToInt32(ListBox1.SelectedValue) &&
                                 d.EvalutorId == loggerId &&
                                 d.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                              select d).SingleOrDefault();
                if (Ediscloser != null)
                {
                    if (Convert.ToBoolean(Ediscloser.IDontMind))
                    {
                        ChkIDontMind.Checked = true;
                    }
                    else
                    {
                        ChkIDontMind.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}