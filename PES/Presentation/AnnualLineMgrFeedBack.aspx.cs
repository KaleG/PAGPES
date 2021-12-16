using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class AnnualLineMgrFeedBack : System.Web.UI.Page
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
                int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);
                Session["LoggedINEMployee"] = loggerId;

                var checkExist = (from x in db.AnnualEmployeeEvaluationNotes
                                  where x.EmployeeId == Convert.ToInt32(Session["loggerId"]) &&
    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();
                if (checkExist != null)
                {
                    TbxDirectOperational.Text= checkExist.DirectJobRElated.ToString();
                    TbxAdministrative.Text= checkExist.AdministrativeRalated.ToString();
                    TbxClientHandling.Text=checkExist.ClientHandlingRElated.ToString();
                    TbxGeneral2.Text = checkExist.General.ToString();
                }

                var checkYesNo = (from x in db.AnnualEmployeeEvaluationYesNos
                                  where x.EmployeeId == Convert.ToInt32(Session["loggerId"]) &&
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


                int rows = EpointsAM.Count;
                int cols = 8;

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
                                c.Controls.Add(new Label() { ID = (eAM.Id.ToString() + eAM.DataTypes.ToString()), Text = eAM.EvaluationNameAmharic.ToString() });
                                tr.Cells.Add(c);
                            }
                            else
                            {
                                c.Controls.Add(new Label() { ID = (eAM.Id.ToString() + eAM.DataTypes.ToString()), Text = eAM.EvaluationName.ToString() });
                                tr.Cells.Add(c);
                            }
                        }
                        if (i != 0 && i != 1 && i != 8)
                        {
                            var evaluated = (from evd in db.AnnualLineManagerEvaluations
                                             where evd.EvaluationPointName == eAM.Id
                                             && evd.EvaluatorLineMgrId != loggerId
             && evd.EmployeeId == loggerId &&
             evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && evd.EvaluationPointName != 15
                                             select evd).SingleOrDefault();
                            if (evaluated != null && Convert.ToInt32(evaluated.EvaluationPointGiven) == i)
                            {
                                if (Session["SelectedLanguage"].ToString() == "AM")
                                {
                                    c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), Checked = true, GroupName = eAM.EvaluationNameAmharic.ToString() });
                                    tr.Cells.Add(c);
                                }
                                else
                                {
                                    c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), Checked = true, GroupName = eAM.EvaluationName.ToString() });
                                    tr.Cells.Add(c);
                                }
                            }
                            else
                            {
                                if (Session["SelectedLanguage"].ToString() == "AM")
                                {
                                    c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), GroupName = eAM.EvaluationNameAmharic.ToString() });
                                    tr.Cells.Add(c);
                                }
                                else
                                {
                                    c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), GroupName = eAM.EvaluationName.ToString() });
                                    tr.Cells.Add(c);
                                }
                            }
                        }
                        if (i == 8)
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
            catch (Exception ex) {
                string er = ex.Message;
            }

        }
    }
}