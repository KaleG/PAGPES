using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PES.Presentation
{
    public partial class AnnualPESheet : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        string TheError = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();

            if (!IsPostBack)
            {
                DataAccess.AreaOfAchievement areaofA = (from aA in db.AreaOfAchievements
                                                        where aA.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                                                        aA.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                        select aA).SingleOrDefault();
                if (areaofA != null)
                {
                    TARDirectJobRElated.Text = areaofA.DirectJobRelated;
                    TARNumOfAssigmentSelf.Text = areaofA.NumberOfAssignmentsByMySelf;
                    TARNumOfAssigmentSelfTogether.Text = areaofA.NumberOfAssignmentsHandledTogether;
                    TARNumOfAssigmentSelfKPI.Text = areaofA.NumberOfAssignmentsWithKPI;
                    TARREmark.Text = areaofA.Remark;
                }

                DataAccess.AreaOfImprovement aeaofimp = (from aA in db.AreaOfImprovements
                                                         where aA.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                                                         aA.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                         select aA).SingleOrDefault();
                if (aeaofimp != null)
                {
                    TbxNumOfError.Text = aeaofimp.NumberOfErrors;
                    TbxNumOfDamage.Text = aeaofimp.NumberOfDummages;
                    TbxNumbOfDelay.Text = aeaofimp.DelayesCaused;
                    TbxOther.Text = aeaofimp.Others;
                    TarRemarkS2.Text = aeaofimp.REmark;
                    TARLastObejctiveAndActionPlan.Text = aeaofimp.LastObjectiveAndAcionPlan;
                    TARMeasureAchivment.Text = aeaofimp.ObjectiveAchivmentMeasure;
                    TARStrategy.Text = aeaofimp.StrategiesUsed;
                    TARNextPlan.Text = aeaofimp.NewYearPlan;
                }

                DataAccess.AdministrativeRelatedIssuePerformance adm = (from x in db.AdministrativeRelatedIssuePerformances
                                                                       where x.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                                                        x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                       select x).SingleOrDefault();
                if (adm != null) {
                    TbxAdministrativePerfomance.Text = adm.PerformanceMeasure.ToString();
                    TbxAdministrativeNextPlan.Text = adm.NewYearPlan.ToString();
                }

                DataAccess.MarketingRelatedIssuePerformance mkt = (from x in db.MarketingRelatedIssuePerformances
                                                                       where x.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                                                        x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                       select x).SingleOrDefault();
                if (mkt != null) {
                    tbxMarketingRElatedPerformance.Text = mkt.PerformanceMeasure.ToString();
                    TbxMarketingRElatedPlan.Text = mkt.NewYearPlan.ToString();
                }
                
                DataAccess.OverAllGeneralPerformance oall = (from x in db.OverAllGeneralPerformances
                                                                       where x.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                                                        x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                       select x).SingleOrDefault();
                if (oall != null) {
                    TbxOverAllGeneralPerformace.Text = oall.PerformanceMeasure.ToString();
                    TbxOverAllGeneralPlan.Text = oall.NewYearPlan.ToString();
                }
                
                DataAccess.AddionalPAGRelatedGeneral adt = (from x in db.AddionalPAGRelatedGenerals
                                                                       where x.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                                                        x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                       select x).SingleOrDefault();
                if (adt != null) {
                    TbxGoodPractice.Text = adt.GoodPractices.ToString();
                    TbxAreasREviewed.Text = adt.AreasToBeReviewed.ToString();
                    TbxEmployeeStatement.Text = adt.EmployeeStatement.ToString();
                }
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                //Clear area of achivment
                DataAccess.AreaOfAchievement aoa = (from areaOfAchive in db.AreaOfAchievements
                                                    where areaOfAchive.EmployeId == Convert.ToInt32(Session["loggerId"])
                                                    && areaOfAchive.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                    select areaOfAchive).SingleOrDefault();

                db.AreaOfAchievements.DeleteOnSubmit(aoa);
                db.SubmitChanges();
                this.Page_Load(sender, e);
            }
            catch (Exception ex) {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
            TARDirectJobRElated.Text = string.Empty;
            TARNumOfAssigmentSelf.Text = string.Empty;
            TARNumOfAssigmentSelfTogether.Text = string.Empty;
            TARNumOfAssigmentSelfKPI.Text = string.Empty;
            TARREmark.Text = string.Empty;
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //SAve area of achivment
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                DataAccess.AreaOfAchievement ifExist = (from x in db.AreaOfAchievements
                                                        where x.EmployeId == Convert.ToInt32(Session["loggerId"])
                       && x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                        select x).SingleOrDefault();
                if (ifExist != null)
                {
                    ifExist.EvaluationDate = DateTime.Now.Date;
                    ifExist.DirectJobRelated = TARDirectJobRElated.Text.ToString();
                    ifExist.NumberOfAssignmentsByMySelf = TARNumOfAssigmentSelf.Text.ToString();
                    ifExist.NumberOfAssignmentsHandledTogether = TARNumOfAssigmentSelfTogether.Text.ToString();
                    ifExist.NumberOfAssignmentsWithKPI = TARNumOfAssigmentSelfKPI.Text.ToString();
                    ifExist.Remark = TARREmark.Text.ToString();
                    db.SubmitChanges();
                }
                else
                {
                    DataAccess.AreaOfAchievement aoa = new DataAccess.AreaOfAchievement()
                    {
                        EmployeId = Convert.ToInt32(Session["loggerId"]),
                        EvaluationDate = DateTime.Now.Date,
                        EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]),
                        DirectJobRelated = TARDirectJobRElated.Text.ToString(),
                        NumberOfAssignmentsByMySelf = TARNumOfAssigmentSelf.Text.ToString(),
                        NumberOfAssignmentsHandledTogether = TARNumOfAssigmentSelfTogether.Text.ToString(),
                        NumberOfAssignmentsWithKPI = TARNumOfAssigmentSelfKPI.Text.ToString(),
                        Remark = TARREmark.Text.ToString()
                    };
                    db.AreaOfAchievements.InsertOnSubmit(aoa);
                    db.SubmitChanges();
                }
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //clear area of improvement
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                DataAccess.AreaOfImprovement aoi = (from aA in db.AreaOfImprovements
                                                    where aA.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                       aA.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                    select aA).SingleOrDefault();
                db.AreaOfImprovements.DeleteOnSubmit(aoi);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
            TbxNumOfError.Text = string.Empty;
            TbxNumOfDamage.Text = string.Empty;
            TbxNumbOfDelay.Text = string.Empty;
            TbxOther.Text = string.Empty; 
            TarRemarkS2.Text = string.Empty;
            TARLastObejctiveAndActionPlan.Text = string.Empty;
            TARMeasureAchivment.Text = string.Empty;
            TARStrategy.Text = string.Empty;
            TARNextPlan.Text = string.Empty;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //save area of improvment
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                DataAccess.AreaOfImprovement IfExist = (from x in db.AreaOfImprovements
                                                        where x.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                       x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                        select x).SingleOrDefault();
                if (IfExist != null)
                {
                    IfExist.EvaluationDate = DateTime.Now.Date;
                    IfExist.NumberOfErrors = TbxNumOfError.Text.ToString();
                    IfExist.NumberOfDummages = TbxNumOfDamage.Text.ToString();
                    IfExist.DelayesCaused = TbxNumbOfDelay.Text.ToString();
                    IfExist.Others = TbxOther.Text.ToString();
                    IfExist.REmark = TarRemarkS2.Text.ToString();
                    IfExist.LastObjectiveAndAcionPlan = TARLastObejctiveAndActionPlan.Text.ToString();
                    IfExist.ObjectiveAchivmentMeasure = TARMeasureAchivment.Text.ToString();
                    IfExist.StrategiesUsed = TARStrategy.Text.ToString();
                    IfExist.NewYearPlan = TARNextPlan.Text.ToString();
                }
                else
                {
                    DataAccess.AreaOfImprovement aoi = new DataAccess.AreaOfImprovement()
                    {
                        EmployeId = Convert.ToInt32(Session["loggerId"]),
                        EvaluationDate = DateTime.Now.Date,
                        EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]),
                        NumberOfErrors = TbxNumOfError.Text.ToString(),
                        NumberOfDummages = TbxNumOfDamage.Text.ToString(),
                        DelayesCaused = TbxNumbOfDelay.Text.ToString(),
                        Others = TbxOther.Text.ToString(),
                        REmark = TarRemarkS2.Text.ToString(),
                        LastObjectiveAndAcionPlan = TARLastObejctiveAndActionPlan.Text.ToString(),
                        ObjectiveAchivmentMeasure = TARMeasureAchivment.Text.ToString(),
                        StrategiesUsed = TARStrategy.Text.ToString(),
                        NewYearPlan = TARNextPlan.Text.ToString()
                    };
                    db.AreaOfImprovements.InsertOnSubmit(aoi);
                }
                db.SubmitChanges();
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            //Clear administrative related isues performance 
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                DataAccess.AdministrativeRelatedIssuePerformance aoi = (from aA in db.AdministrativeRelatedIssuePerformances
                                                                        where aA.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                                           aA.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                        select aA).SingleOrDefault();
                db.AdministrativeRelatedIssuePerformances.DeleteOnSubmit(aoi);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
            TbxAdministrativePerfomance.Text = string.Empty;
            TbxAdministrativeNextPlan.Text = string.Empty;
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                //SAve administrative related isues performance 
                DataAccess.AdministrativeRelatedIssuePerformance IfExist = (from x in db.AdministrativeRelatedIssuePerformances
                                                                            where x.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                                           x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                            select x).SingleOrDefault();
                if (IfExist != null)
                {
                    IfExist.EvaluatinDAte = DateTime.Now.Date;
                    IfExist.PerformanceMeasure = TbxAdministrativePerfomance.Text.ToString();
                    IfExist.NewYearPlan = TbxAdministrativeNextPlan.Text.ToString();
                }
                else
                {
                    DataAccess.AdministrativeRelatedIssuePerformance aoi = new DataAccess.AdministrativeRelatedIssuePerformance()
                    {
                        EmployeId = Convert.ToInt32(Session["loggerId"]),
                        EvaluatinDAte = DateTime.Now.Date,
                        EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]),
                        PerformanceMeasure = TbxAdministrativePerfomance.Text.ToString(),
                        NewYearPlan = TbxAdministrativeNextPlan.Text.ToString()
                    };
                    db.AdministrativeRelatedIssuePerformances.InsertOnSubmit(aoi);
                }
                db.SubmitChanges();
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                //Clear Marketing related Evaluation
                DataAccess.MarketingRelatedIssuePerformance aoi = (from aA in db.MarketingRelatedIssuePerformances
                                                                   where aA.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                                      aA.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                   select aA).SingleOrDefault();
                db.MarketingRelatedIssuePerformances.DeleteOnSubmit(aoi);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
            tbxMarketingRElatedPerformance.Text = string.Empty;
            TbxMarketingRElatedPlan.Text = string.Empty;
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //save Marketing related Evaluation
            try
            {
                DataAccess.MarketingRelatedIssuePerformance IfExist = (from x in db.MarketingRelatedIssuePerformances
                                                                       where x.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                                      x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                       select x).SingleOrDefault();
                if (IfExist != null)
                {
                    IfExist.EvaluatinDAte = DateTime.Now.Date;
                    IfExist.PerformanceMeasure = tbxMarketingRElatedPerformance.Text.ToString();
                    IfExist.NewYearPlan = TbxMarketingRElatedPlan.Text.ToString();
                }
                else
                {
                    DataAccess.MarketingRelatedIssuePerformance aoi = new DataAccess.MarketingRelatedIssuePerformance()
                    {
                        EmployeId = Convert.ToInt32(Session["loggerId"]),
                        EvaluatinDAte = DateTime.Now.Date,
                        EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]),
                        PerformanceMeasure = tbxMarketingRElatedPerformance.Text.ToString(),
                        NewYearPlan = TbxMarketingRElatedPlan.Text.ToString()
                    };
                    db.MarketingRelatedIssuePerformances.InsertOnSubmit(aoi);
                }
                db.SubmitChanges();
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                //Clear Overall general performance 
                DataAccess.OverAllGeneralPerformance aoi = (from aA in db.OverAllGeneralPerformances
                                                            where aA.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                               aA.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                            select aA).SingleOrDefault();
                db.OverAllGeneralPerformances.DeleteOnSubmit(aoi);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
            TbxOverAllGeneralPerformace.Text = string.Empty;
            TbxOverAllGeneralPlan.Text = string.Empty;
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //SAve Overall general performance 
            try
            {
                DataAccess.OverAllGeneralPerformance IfExist = (from x in db.OverAllGeneralPerformances
                                                                where x.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                               x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                select x).SingleOrDefault();
                if (IfExist != null)
                {
                    IfExist.EvaluatinDAte = DateTime.Now.Date;
                    IfExist.PerformanceMeasure = TbxOverAllGeneralPerformace.Text.ToString();
                    IfExist.NewYearPlan = TbxOverAllGeneralPlan.Text.ToString();
                }
                else
                {
                    DataAccess.OverAllGeneralPerformance aoi = new DataAccess.OverAllGeneralPerformance()
                    {
                        EmployeId = Convert.ToInt32(Session["loggerId"]),
                        EvaluatinDAte = DateTime.Now.Date,
                        EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]),
                        PerformanceMeasure = TbxOverAllGeneralPerformace.Text.ToString(),
                        NewYearPlan = TbxOverAllGeneralPlan.Text.ToString()
                    };
                    db.OverAllGeneralPerformances.InsertOnSubmit(aoi);
                }
                db.SubmitChanges();
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //clear additional pag related general
            try
            {
                //Clear Overall general performance 
                DataAccess.AddionalPAGRelatedGeneral aoi = (from aA in db.AddionalPAGRelatedGenerals
                                                            where aA.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                               aA.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                            select aA).SingleOrDefault();
                db.AddionalPAGRelatedGenerals.DeleteOnSubmit(aoi);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
            TbxGoodPractice.Text = string.Empty;
            TbxAreasREviewed.Text = string.Empty;
            TbxEmployeeStatement.Text = string.Empty;
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //SAve additional pag related general
            try
            {
                DataAccess.AddionalPAGRelatedGeneral IfExist = (from x in db.AddionalPAGRelatedGenerals
                                                                where x.EmployeId == Convert.ToInt32(Session["loggerId"]) &&
                               x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                select x).SingleOrDefault();
                if (IfExist != null)
                {
                    IfExist.EvaluatinDAte = DateTime.Now.Date;
                    IfExist.GoodPractices = TbxGoodPractice.Text.ToString();
                    IfExist.AreasToBeReviewed = TbxAreasREviewed.Text.ToString();
                    IfExist.EmployeeStatement = TbxEmployeeStatement.Text.ToString();
                }
                else
                {
                    DataAccess.AddionalPAGRelatedGeneral aoi = new DataAccess.AddionalPAGRelatedGeneral()
                    {
                        EmployeId = Convert.ToInt32(Session["loggerId"]),
                        EvaluatinDAte = DateTime.Now.Date,
                        EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]),
                        GoodPractices = TbxGoodPractice.Text.ToString(),
                        AreasToBeReviewed = TbxAreasREviewed.Text.ToString(),
                        EmployeeStatement = TbxEmployeeStatement.Text.ToString()
                    };
                    db.AddionalPAGRelatedGenerals.InsertOnSubmit(aoi);
                }
                db.SubmitChanges();
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }

        protected void BtnAreaOfAchievement_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSubmittAll_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                var chechExixt = (from x in db.SubmitedAnnualForms
                                  where x.EmployeeId == Convert.ToInt32(Session["loggerId"])
&& x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();
                if (chechExixt == null)
                {
                    DataAccess.SubmitedAnnualForm sf = new DataAccess.SubmitedAnnualForm()
                    {
                        EmployeeId = Convert.ToInt32(Session["loggerId"]),
                        EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]),
                        IsSubmitted = true,
                        SubmittedDate = DateTime.Today
                    };
                    db.SubmitedAnnualForms.InsertOnSubmit(sf);
                    db.SubmitChanges();                    
                }
                Response.Write("<script>alert('Data Successfully Submitted');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something go wrong contact system admin');</script>");
            }
        }
    }
}