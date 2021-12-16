using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class WorkPlanforNextYear : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();
        }

        protected void BtnREgister_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["onSelectRowId"] == null)
                {
                    DataAccess.WorkPlanforNextYear workplan = new DataAccess.WorkPlanforNextYear()
                    {
                        EmployeId = Convert.ToInt32(Session["loggerId"]),
                        SmartObjective = TbxSmartObjective.Text.ToString(),
                        ActionPlan = TbxActionPlan.Text.ToString(),
                        TimeFrameStart = Convert.ToDateTime(Calendar1TimeFrameStart.Text).Date,
                        TimeFrameEnd = Convert.ToDateTime(Calendar1TimeFrameEnd.Text).Date,
                        EndResult = tbxEndResult.Text.ToString(),
                        EvaluationPlanPeriod = Convert.ToInt32(Session["EvaluationPeriod"])
                    };
                    db.WorkPlanforNextYears.InsertOnSubmit(workplan);
                    db.SubmitChanges();
                    GridView1.DataBind();
                }
                else
                {
                    DataAccess.WorkPlanforNextYear updatePlan = (from x in db.WorkPlanforNextYears
                                                                 where x.Id == Convert.ToInt32(Session["onSelectRowId"])
                                                                 select x).SingleOrDefault();
                    updatePlan.SmartObjective = TbxSmartObjective.Text.ToString();
                    updatePlan.ActionPlan = TbxActionPlan.Text.ToString();
                    updatePlan.TimeFrameStart = Convert.ToDateTime(Calendar1TimeFrameStart.Text).Date;
                    updatePlan.TimeFrameEnd = Convert.ToDateTime(Calendar1TimeFrameEnd.Text).Date;
                    updatePlan.EndResult = tbxEndResult.Text.ToString();
                    updatePlan.EvaluationPlanPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                    db.SubmitChanges();
                    GridView1.DataBind();
                }
                Session.Remove("onSelectRowId");
                TbxSmartObjective.Text = string.Empty;
                TbxActionPlan.Text = string.Empty;
                tbxEndResult.Text = string.Empty;
                Calendar1TimeFrameStart.Text = string.Empty;
                Calendar1TimeFrameEnd.Text = string.Empty;
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try {
                DataAccess.WorkPlanforNextYear deletIt = (from x in db.WorkPlanforNextYears
                                                          where x.Id == Convert.ToInt32(Session["onSelectRowId"])
                                                          select x).SingleOrDefault();
                db.WorkPlanforNextYears.DeleteOnSubmit(deletIt);
                db.SubmitChanges();
                Session.Remove("onSelectRowId");
                TbxSmartObjective.Text = string.Empty;
                TbxActionPlan.Text = string.Empty;
                tbxEndResult.Text = string.Empty;
                GridView1.DataBind();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TbxSmartObjective.Text = GridView1.SelectedRow.Cells[3].Text.ToString();
            TbxActionPlan.Text = GridView1.SelectedRow.Cells[4].Text.ToString();
            tbxEndResult.Text = GridView1.SelectedRow.Cells[5].Text.ToString();
            Calendar1TimeFrameStart.Text =Convert.ToDateTime(GridView1.SelectedRow.Cells[6].Text).ToString("yyyy-MM-dd");
            Calendar1TimeFrameEnd.Text = Convert.ToDateTime(GridView1.SelectedRow.Cells[7].Text).ToString("yyyy-MM-dd");
            Session["onSelectRowId"] = GridView1.SelectedRow.Cells[1].Text.ToString();
        }
    }
}