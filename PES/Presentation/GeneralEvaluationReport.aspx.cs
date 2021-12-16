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
    public partial class GeneralEvaluationReport : System.Web.UI.Page
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
                List<DataAccess.LKEvaluationPoint> ListOfEvaluationPoints = (from evp in db.LKEvaluationPoints
                                                                             where evp.DataTypes == 3 
                                                                             select evp).ToList();
                foreach (DataAccess.LKEvaluationPoint ep in ListOfEvaluationPoints)
                {
                    int evaluationNAme = ep.Id;
                    int CountTwo = (from sel in db.EvaluatedPoints where sel.EvaluationPointName == evaluationNAme && sel.EvaluationPeriod== Convert.ToInt32(Session["EvaluationPeriod"]) && sel.EvaluationPointGiven == "2" select sel).Count();
                    int CountThree = (from sel in db.EvaluatedPoints where sel.EvaluationPointName == evaluationNAme && sel.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && sel.EvaluationPointGiven == "3" select sel).Count();
                    int CountFour = (from sel in db.EvaluatedPoints where sel.EvaluationPointName == evaluationNAme && sel.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && sel.EvaluationPointGiven == "4" select sel).Count();
                    int CountFive = (from sel in db.EvaluatedPoints where sel.EvaluationPointName == evaluationNAme && sel.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) && sel.EvaluationPointGiven == "5" select sel).Count();

                    Chart ch = new Chart();
                    Series s = new Series();
                    s.ChartType = SeriesChartType.Pie;
                    // DataPoint dp1 = new DataPoint();
                    // dp1.AxisLabel = "Rating";
                    //dp1.YValues ={ 10.0, 20,30};
                    // { Convert.ToDouble(CountTwo),Convert.ToDouble(CountThree), CountFour, CountFive};

                    s.Points.AddXY("", CountTwo);
                    s.Points.AddXY("", CountThree);
                    s.Points.AddXY("", CountFour);
                    s.Points.AddXY("", CountFive);

                    //s.Points.AddXY(Convert.ToDouble(CountTwo), CountTwo);
                    //s.Points.AddXY("NI", CountThree);
                    //s.Points.AddXY("ME", 40);
                    //s.Points.AddXY("EE", 20);

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
                                tc.Controls.Add(new Label() { Text = ep.EvaluationNameAmharic.ToString() });
                                tr.Cells.Add(tc);
                            }
                            else {
                                tc.Controls.Add(new Label() { Text = ep.EvaluationName.ToString() });
                                tr.Cells.Add(tc);
                            }
                        }
                        if (i == 2)
                        {                           
                            //int[] yValues = { CountTwo, CountThree, CountFour, CountFive };
                            //string[] xValues = { "Unacceptable", "Need Improvement", "Meet Expectation", "Exceed Expectaltion" };
                            //// Create a pie chart 
                            //tc.Controls.Add(new Label() { Text = "Unacceptable = " + CountTwo.ToString() });
                            //tc.Controls.Add(new Label() { Text = "\n Need Improvement = " + CountThree.ToString() });
                            //tc.Controls.Add(new Label() { Text = "\r\n Meet Expectation = " + CountFour.ToString() });
                            //tc.Controls.Add(new Label() { Text = "Exceed Expectaltion = " + CountFive.ToString() });

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