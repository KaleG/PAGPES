using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

using System.Web.Http;
using System.Web.Http.WebHost;


namespace PES.Presentation
{
    public partial class GeneralPlanningReport : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();
            try
            {
                List<DataAccess.LKSixMonthPlan> ListOfPlanningPoints = (from evp in db.LKSixMonthPlans
                                                                             where evp.DataTypeSelection == 3
                                                                             select evp).ToList();
                foreach (DataAccess.LKSixMonthPlan ep in ListOfPlanningPoints)
                {
                    int evaluationNAme = ep.Id;
                    int CountTwo = (from sel in db.SixMonthPlans where sel.PlanName == evaluationNAme && sel.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && sel.PriorityGiven == "2" select sel).Count();
                    int CountThree = (from sel in db.SixMonthPlans where sel.PlanName == evaluationNAme && sel.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && sel.PriorityGiven == "3" select sel).Count();
                    int CountFour = (from sel in db.SixMonthPlans where sel.PlanName == evaluationNAme && sel.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && sel.PriorityGiven == "4" select sel).Count();

                    Chart ch = new Chart();
                    Series s = new Series();
                    s.ChartType = SeriesChartType.Pie;

                    s.Points.AddXY("", CountTwo);
                    s.Points.AddXY("", CountThree);
                    s.Points.AddXY("", CountFour);

                    ChartArea ca = new ChartArea();
                    ca.AxisX.Title = "Rating";
                    ca.AxisY.Title = "Value";

                    ch.ChartAreas.Add(ca);
                    ch.Series.Add(s);

                    TableRow tr = new TableRow();
                    for (int i = 0; i < 4; i++)
                    {
                        TableCell tc = new TableCell();
                        if (i == 0)
                        {
                            tc.Controls.Add(new Label() { Text = ep.Id.ToString() });
                            tr.Cells.Add(tc);
                        }
                        if (i == 1)
                        {
                            if (Session["SelectedLanguage"].ToString() == "AM")
                            {
                                tc.Controls.Add(new Label() { Text = ep.PlanNameAmharic.ToString() });
                                tr.Cells.Add(tc);
                            }
                            else {
                                tc.Controls.Add(new Label() { Text = ep.PlanName.ToString() });
                                tr.Cells.Add(tc);
                            }
                        }
                        if (i == 2)
                        {
                            tc.Controls.Add(ch);
                            tr.Cells.Add(tc);
                        }
                        if (i == 3)
                        {
                            tc.Controls.Add(new Label() { Text = "" });
                            tr.Cells.Add(tc);
                        }
                    }
                    Table11.Rows.Add(tr);

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}