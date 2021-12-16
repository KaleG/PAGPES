using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class AnnualColleagueFeedBack : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();

            if (!IsPostBack)
            {
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
                            c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), GroupName = eAM.EvaluationName.ToString() });
                            tr.Cells.Add(c);
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
            }
        }

        protected void BtnAddEvaluatorColleague_Click(object sender, EventArgs e)
        {
            try
            {
                // ViewState["Inserted"] = "False";
                if (DDLParticipants.SelectedValue != null)               
                {
                    var checkCount = (from cc in db.Employee_evaluatorColleagues
                                      where cc.EvaluatorColleague == Convert.ToInt32(DDLParticipants.SelectedValue) &&
                                      cc.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                      select cc).ToList().DefaultIfEmpty();
                    DataAccess.Employee_evaluatorColleague chechPreSElection = (from cc in db.Employee_evaluatorColleagues
                                                                                where cc.EvaluatorColleague == Convert.ToInt32(DDLParticipants.SelectedValue) &&
                                                                                cc.EmployeeId == Convert.ToInt32(Session["loggerId"]) &&
                                                                                cc.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                                select cc).SingleOrDefault();
                    if (checkCount.Count() <= 5 && chechPreSElection == null && ListBox1.Items.Count <= 4)
                    {
                        DataAccess.Employee_evaluatorColleague eec = new DataAccess.Employee_evaluatorColleague()
                        {
                            EmployeeId = Convert.ToInt32(Session["loggerId"]),
                            EvaluatorColleague = Convert.ToInt32(DDLParticipants.SelectedValue),
                            period = Convert.ToInt32(Session["EvaluationPeriod"]),
                            LastReminderSent = new DateTime(2020, 05, 05)
                        };
                        db.Employee_evaluatorColleagues.InsertOnSubmit(eec);
                        db.SubmitChanges();
                        ListBox1.DataBind();
                        ViewState["Inserted"] = "True";
                    }

                    if (checkCount.Count() > 5)
                    {
                        Response.Write("<script>alert('Selected Employee is not Able to Evaluate, Please Select Other Colleague');</script>");
                    }

                }
            }
            catch (Exception ex)
            {
                var exx = ex.Message;
                Response.Write("<script>alert('Please Select the Correct Employee');</script>");
            }
        }
    

        protected void BtnRemoveColleage_Click(object sender, EventArgs e)
        {
            try
            {
                TARAdditionalPoints.Text = string.Empty;
                int ColleagueId = System.Convert.ToInt32(ListBox1.SelectedValue);

                DataAccess.Employee_evaluatorColleague ee = (from et in db.Employee_evaluatorColleagues
                                                             where
                  et.EvaluatorColleague == ColleagueId
                  && et.EmployeeId == Convert.ToInt32(Session["loggerId"])
                  && et.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                                             select et).SingleOrDefault();
                db.Employee_evaluatorColleagues.DeleteOnSubmit(ee);
                db.SubmitChanges();
                ListBox1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGetSelected_Click(object sender, EventArgs e)
        {
            try
            {
                TARAdditionalPoints.Text = string.Empty;
                var EpointsAM = (from ev in db.LKColleagueFeedBAckPoints where ev.DataType == 3 select ev).ToList();
                int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);

                //check if i doint mind is selected

                DataAccess.EvaluationDisclosure Ediscloser = (from d in db.EvaluationDisclosures
                                                              where d.EvaluatedEmployeId == loggerId &&
                                 d.EvalutorId == Convert.ToInt32(ListBox1.SelectedValue) &&
                                 d.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                              select d).SingleOrDefault();
                if (Convert.ToBoolean(Ediscloser.IDontMind) && Convert.ToBoolean(Ediscloser.AdminOpinionOnDisclosore))
                {
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
                                                 && evd.EvaluatorColleagueId == Convert.ToInt32(ListBox1.SelectedValue)
                 && evd.EmployeeId == loggerId &&
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
                                        && evd.EvaluatorColleagueId == Convert.ToInt32(ListBox1.SelectedValue)
           && evd.EmployeeId == loggerId &&
           evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                        select evd).SingleOrDefault();

                    if (evaluated233 != null)
                    {
                        TARAdditionalPoints.Text = evaluated233.EvaluationPointGiven.ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('You are not allowed to see the evaluation');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(error occurred contact system admins)</script>");
            }
        }

        protected void DDLParticipants_DataBound(object sender, EventArgs e)
        {
            DDLParticipants.Items.Insert(0, new System.Web.UI.WebControls.ListItem("  ------   Please Select Employee   ------", ""));
        }
    } 
}