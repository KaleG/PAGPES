using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class AllEmployeesReport : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnSelectEvaluator_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSelectEmployee_Click(object sender, EventArgs e)
        {

        }

        protected void BtnGetReport_Click(object sender, EventArgs e)
        {           
            var EpointsAM = (from ev in db.LKEvaluationPoints where ev.Language == Session["SelectedLanguage"].ToString() && ev.DataTypes == 3 select ev).ToList();
            int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);


            if (Session["SelectedLanguage"].ToString() == "AM")
            {
                // LblAdditionalEN.Visible = false;
                // LblAdditionalAM.Visible = true;
            }
            else
            {
                // LblAdditionalEN.Visible = true;
                // LblAdditionalAM.Visible = false;
            }
            int rows = EpointsAM.Count;
            int cols = 7;

            int rowcounter = 1;

            /*var evaluated2 = (from evd in db.EvaluatedPoints
                              where evd.EvaluationPointName == 24
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
                        c.Controls.Add(new Label() { ID = (rowcounter + eAM.Language).ToString(), Text = eAM.EvaluationName.ToString() });
                        tr.Cells.Add(c);
                    }
                    if (i != 0 && i != 1 && i != 6)
                    {
                        var evaluated = (from evd in db.EvaluatedPoints
                                         where evd.EvaluationPointName == eAM.Id
         && evd.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) && evd.EvaluatorId == Convert.ToInt32(DDLEvaluators.SelectedValue) &&
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
    }
}