using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PES.Presentation
{
    public partial class AnnualEvaluationREportByEmployee : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();

            if (Convert.ToInt32(Session["UserRole"]) != 5)
            {
                DivCEoSection.Visible = false;
            }            
           // DDLEvaluatedEmployee.Items.Insert(0,"Please Select Employee");
           // DDLEvaluatedEmployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Please Select Employee", "Please Select Employee"));
            //DDLEvaluatedEmployee.DataBind();
        }

        protected void BtnSelectEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                TARDirectJobRElated.Text = string.Empty;
                TARNumOfAssigmentSelf.Text = string.Empty;
                TARNumOfAssigmentSelfTogether.Text = string.Empty;
                TARNumOfAssigmentSelfKPI.Text = string.Empty;
                TARREmark.Text = string.Empty;

                TbxNumOfError.Text = string.Empty;
                TbxNumOfDamage.Text = string.Empty;
                TbxNumbOfDelay.Text = string.Empty;
                TbxOther.Text = string.Empty;
                TarRemarkS2.Text = string.Empty;
                TARLastObejctiveAndActionPlan.Text = string.Empty;
                TARMeasureAchivment.Text = string.Empty;
                TARStrategy.Text = string.Empty;
                TARNextPlan.Text = string.Empty;

                TbxAdministrativePerfomance.Text = string.Empty;
                TbxAdministrativeNextPlan.Text = string.Empty;

                tbxMarketingRElatedPerformance.Text = string.Empty;
                TbxMarketingRElatedPlan.Text = string.Empty;

                TbxOverAllGeneralPerformace.Text = string.Empty;
                TbxOverAllGeneralPlan.Text = string.Empty;

                TbxGoodPractice.Text = string.Empty;
                TbxAreasREviewed.Text = string.Empty;
                TbxEmployeeStatement.Text = string.Empty;

                TbxDirectOpertional.Text = string.Empty;
                TbxAdministrative.Text = string.Empty;
                TbxClientHandling.Text = string.Empty;
                TbxGeneral.Text = string.Empty;


                if (DDLEvaluatedEmployee.SelectedValue != null)
                {
                    LblEmployeeName.InnerText = "Name :" + " " + (from L in db.Employees where L.Id == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) select L).SingleOrDefault().EName.ToString() + " " + (from L in db.Employees where L.Id == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) select L).SingleOrDefault().ELName.ToString();
                    LblDate.InnerText = "Date :" + " " + (from L in db.SubmitedAnnualForms
                                                          where L.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                   L.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                          select L).SingleOrDefault().SubmittedDate.ToString();


                    DataAccess.AreaOfAchievement areaofA = (from aA in db.AreaOfAchievements
                                                            where aA.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
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
                                                             where aA.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
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
                                                                            where x.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                                             x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                            select x).SingleOrDefault();
                    if (adm != null)
                    {
                        TbxAdministrativePerfomance.Text = adm.PerformanceMeasure.ToString();
                        TbxAdministrativeNextPlan.Text = adm.NewYearPlan.ToString();
                    }

                    DataAccess.MarketingRelatedIssuePerformance mkt = (from x in db.MarketingRelatedIssuePerformances
                                                                       where x.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                                        x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                       select x).SingleOrDefault();
                    if (mkt != null)
                    {
                        tbxMarketingRElatedPerformance.Text = mkt.PerformanceMeasure.ToString();
                        TbxMarketingRElatedPlan.Text = mkt.NewYearPlan.ToString();
                    }

                    DataAccess.OverAllGeneralPerformance oall = (from x in db.OverAllGeneralPerformances
                                                                 where x.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                                  x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                 select x).SingleOrDefault();
                    if (oall != null)
                    {
                        TbxOverAllGeneralPerformace.Text = oall.PerformanceMeasure.ToString();
                        TbxOverAllGeneralPlan.Text = oall.NewYearPlan.ToString();
                    }

                    DataAccess.AddionalPAGRelatedGeneral adt = (from x in db.AddionalPAGRelatedGenerals
                                                                where x.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                                 x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                select x).SingleOrDefault();
                    if (adt != null)
                    {
                        TbxGoodPractice.Text = adt.GoodPractices.ToString();
                        TbxAreasREviewed.Text = adt.AreasToBeReviewed.ToString();
                        TbxEmployeeStatement.Text = adt.EmployeeStatement.ToString();
                    }
                    var checkExist = (from x in db.AnnualEmployeeEvaluationNotes
                                      where x.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
        x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                      select x).SingleOrDefault();
                    if (checkExist != null)
                    {
                        TbxDirectOpertional.Text = checkExist.DirectJobRElated.ToString();
                        TbxAdministrative.Text = checkExist.AdministrativeRalated.ToString();
                        TbxClientHandling.Text = checkExist.ClientHandlingRElated.ToString();
                        TbxGeneral.Text = checkExist.General.ToString();
                    }
                    var checkExist2 = (from x in db.AnnualEmployeeEvaluationYesNos
                                       where x.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
         x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                       select x).SingleOrDefault();

                    if (checkExist2 != null)
                    {
                        TbxDirectOpertional.Text = checkExist.DirectJobRElated.ToString();
                        TbxAdministrative.Text = checkExist.AdministrativeRalated.ToString();
                        TbxClientHandling.Text = checkExist.ClientHandlingRElated.ToString();
                        TbxGeneral.Text = checkExist.General.ToString();
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
                                c.Controls.Add(new Label() { Text = rowcounter.ToString() });
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
                 && evd.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                 evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                 select evd).SingleOrDefault();
                                if (evaluated != null && Convert.ToInt32(evaluated.EvaluationPointGiven) == i)
                                {
                                    c.Controls.Add(new RadioButton() { Checked = true, GroupName = eAM.EvaluationName.ToString() });
                                    tr.Cells.Add(c);
                                }
                                else
                                {
                                    c.Controls.Add(new RadioButton() { GroupName = eAM.EvaluationName.ToString() });
                                    tr.Cells.Add(c);
                                }
                            }
                            if (i == 8)
                            {
                                c.Controls.Add(new Label() { Text = eAM.Id.ToString() });
                                tr.Cells.Add(c);
                                tr.Cells[8].Visible = false;
                            }
                        }
                        Table12.Rows.Add(tr);
                        rowcounter++;
                    }
                    DataAccess.CEOCommentOnAnnualEvaluation checking = (from x in db.CEOCommentOnAnnualEvaluations
                                                                        where x.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                                                        x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                        select x).SingleOrDefault();
                    if (checking != null)
                    {
                        RbtCEOComment.SelectedIndex = RbtCEOComment.Items.IndexOf(RbtCEOComment.Items.FindByValue(checking.IsupportTheEvaluation));
                        TbxCEOComment.Text = checking.ReasonForTheGibenComment.ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Data Sent - Possible solution - Please Select the Correct Employee');</script>");
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
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
                TbxDirectOpertional.Text = string.Empty;
                TbxAdministrative.Text = string.Empty;
                TbxClientHandling.Text = string.Empty;
                TbxGeneral.Text = string.Empty;
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
                                             && evd.EvaluatorColleagueId == Convert.ToInt32(ListBox1.SelectedValue)
             && evd.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
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
       && evd.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
       evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                    select evd).SingleOrDefault();

                if (evaluated233 != null)
                {
                    TARAdditionalPoints.Text = evaluated233.EvaluationPointGiven.ToString();
                }
                DivAreaOfColleagueFeedBAck.Visible = true;

                var checkYesNo_ = (from x in db.AnnualEmployeeEvaluationYesNos
                                  where x.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();
                if (checkYesNo_ != null)
                {
                    Q1G.SelectedIndex = Q1G.Items.IndexOf(Q1G.Items.FindByValue(checkYesNo_.FullySuccessfull.ToString()));
                    Q2G.SelectedIndex = Q2G.Items.IndexOf(Q2G.Items.FindByValue(checkYesNo_.OutStandingPerformance.ToString()));
                    Q3G.SelectedIndex = Q3G.Items.IndexOf(Q3G.Items.FindByValue(checkYesNo_.Unsatisfactory.ToString()));
                    Q4G.SelectedIndex = Q4G.Items.IndexOf(Q4G.Items.FindByValue(checkYesNo_.ShouldBePromoted.ToString()));
                }


                DataAccess.EvaluationDisclosure Ediscloser = (from d in db.EvaluationDisclosures
                                                              where d.EvaluatedEmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                 d.EvalutorId == Convert.ToInt32(ListBox1.SelectedValue) &&
                                 d.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                              select d).SingleOrDefault();               

                if (Ediscloser.IDontMind == true)
                {
                    LblIdontMind.Text = "Evaluator opinion : I don't Mind if am the Employee See the Evaluation";
                }
                else
                {
                    LblIdontMind.Text = "Evaluator opinion : I don't Want the Employee to See the Evaluation";
                }
            }
            catch (Exception exx) { string err = exx.Message; }
        }
                
        protected void BtnAreaOfColleagueFeedBAck_Click(object sender, EventArgs e)
        {
            if (DivAreaOfColleagueFeedBAck.Style["display"] != "none")
            {
                DivAreaOfColleagueFeedBAck.Style["display"] = "none";
            }
            else
            {
                DivAreaOfColleagueFeedBAck.Style["display"] = "block";
            }
        }

        protected void TbxClear_Click(object sender, EventArgs e)
        {

        }

        protected void TbxSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.CEOCommentOnAnnualEvaluation checking = (from x in db.CEOCommentOnAnnualEvaluations
                                                                    where x.CEoId == Convert.ToInt32(Session["loggerId"]) &&
                                                                    x.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                                                    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                    select x).SingleOrDefault();
                if (checking != null)
                {
                    checking.IsupportTheEvaluation = RbtCEOComment.SelectedValue.ToString();
                    checking.ReasonForTheGibenComment = TbxCEOComment.Text.ToString();
                    db.SubmitChanges();
                }
                else
                {
                    DataAccess.CEOCommentOnAnnualEvaluation newComment = new DataAccess.CEOCommentOnAnnualEvaluation()
                    {
                        EmployeeId = Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue),
                        CEoId = Convert.ToInt32(Session["loggerId"]),
                        EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]),
                        EvaluationDate = DateTime.Now.Date,
                        IsupportTheEvaluation = RbtCEOComment.SelectedValue.ToString(),
                        ReasonForTheGibenComment = TbxCEOComment.Text.ToString(),
                        IsSubmitted = true
                    };
                    db.CEOCommentOnAnnualEvaluations.InsertOnSubmit(newComment);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Incorrect Data Sent - Please Try again');</script>");
            }
        }

        protected void BtnExporttoPdf_Click(object sender, EventArgs e)
        {

            try
            {
    //           // var checkExist = (from x in db.AnnualEmployeeEvaluationNotes
    //                              where x.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
    //x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
    //                              select x).SingleOrDefault();

                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(PES.Properties.Resources.Capture, System.Drawing.Imaging.ImageFormat.Jpeg);
                pic.ScaleAbsolute(550f, 80f);
                string theEmp = "Employee :" + " " + (from L in db.Employees where L.Id == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) select L).SingleOrDefault().EName.ToString() + " " + (from L in db.Employees where L.Id == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) select L).SingleOrDefault().ELName.ToString();
                //string theLmg = "Line Manager :" + " " + (from L in db.Employees where L.Id == Convert.ToInt32(checkExist.LineManagerId) select L).SingleOrDefault().EName.ToString() + " " + (from L in db.Employees where L.Id == Convert.ToInt32(checkExist.LineManagerId) select L).SingleOrDefault().ELName.ToString();

                Document pdfDoc = new Document(PageSize.A4, 35, 25, 25, 25);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.AddLanguage("am");
                pdfDoc.Open();
                //pic.SetAbsolutePosition(0, 0);
                pdfDoc.Add(pic);
               // BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\NYALA.TTF", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font font2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);

                pdfDoc.Add(new Paragraph("\n"));
                Paragraph Text = new Paragraph("Employees Performance Evaluation Sheet", font2);
                pdfDoc.Add(Text);
                pdfDoc.Add(new Paragraph("\n"));                
                Paragraph theeple = new Paragraph(theEmp, font2);
                pdfDoc.Add(theeple);
                pdfDoc.Add(new Paragraph("\n"));
                Paragraph title = new Paragraph("Areas of Achievement / Outstanding Performance", font2);
                pdfDoc.Add(title);
                pdfDoc.Add(new Paragraph("\n"));

                DataAccess.AreaOfAchievement areaofApdf = (from aA in db.AreaOfAchievements
                                                        where aA.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                                        aA.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                        select aA).SingleOrDefault();
                if (areaofApdf != null)
                {

                    Chunk ck1 = new Chunk("Direct Job related", font2);
                    ck1.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(ck1));
                    Paragraph p2 = new Paragraph(areaofApdf.DirectJobRelated.ToString(), font);
                    pdfDoc.Add(p2);
                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p3 = new Chunk("Number of Assignment/ Activities Handled directly by myself", font2);
                    p3.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p3));
                    Paragraph p4 = new Paragraph(areaofApdf.NumberOfAssignmentsByMySelf.ToString(), font);
                    pdfDoc.Add(p4);
                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p5 = new Chunk(" Number of Assignment/ Activities handled together with another colleague", font2);
                    p5.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p5));
                    Paragraph p6 = new Paragraph(areaofApdf.NumberOfAssignmentsHandledTogether.ToString(), font);
                    pdfDoc.Add(p6);
                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p7 = new Chunk("Number of Assignment/ Activities handled together with another colleague Percentage of Assignment/ Activities that I performed within the KPI", font2);
                    p7.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p7));
                    Paragraph p8 = new Paragraph(areaofApdf.NumberOfAssignmentsWithKPI.ToString(), font);
                    pdfDoc.Add(p8);
                    pdfDoc.Add(new Paragraph("\n"));
                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p71 = new Chunk("Remark", font2);
                    p7.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p71));
                    Paragraph p81 = new Paragraph(areaofApdf.Remark.ToString(), font);
                    pdfDoc.Add(p81);
                    pdfDoc.Add(new Paragraph("\n"));

                    pdfDoc.NewPage();
                    pdfDoc.Add(pic);
                    pdfDoc.Add(new Paragraph("\n"));

                    Paragraph title22 = new Paragraph("Areas of Improvement", font2);
                    pdfDoc.Add(title22);
                    pdfDoc.Add(new Paragraph("\n"));
                    Paragraph title221 = new Paragraph("Gaps in Quantifiable form", font2);
                    pdfDoc.Add(title221);
                    pdfDoc.Add(new Paragraph("\n"));
                }
                DataAccess.AreaOfImprovement aeaofimp = (from aA in db.AreaOfImprovements
                                                         where aA.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                                         aA.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                         select aA).SingleOrDefault();
                if (aeaofimp != null)
                {
                    string NumberOfErrors = "Number of errors in relation to assigned work :" + " " + aeaofimp.NumberOfErrors;
                    Paragraph NumberOfErrors2 = new Paragraph(NumberOfErrors, font2);
                    pdfDoc.Add(NumberOfErrors2);

                    string NumberOfDummages = "Number of damages :" + " " + aeaofimp.NumberOfDummages;
                    Paragraph NumberOfDummages2 = new Paragraph(NumberOfDummages, font2);
                    pdfDoc.Add(NumberOfDummages2);

                    string DelayesCaused = "Delays caused due to me :" + " " + aeaofimp.DelayesCaused;
                    Paragraph DelayesCaused2 = new Paragraph(DelayesCaused, font2);
                    pdfDoc.Add(DelayesCaused2);

                    string Others = "Others :" + " " + aeaofimp.Others;
                    Paragraph Others2 = new Paragraph(Others, font2);
                    pdfDoc.Add(Others2);
                    pdfDoc.Add(new Paragraph("\n"));

                    Chunk p712 = new Chunk("Remark", font2);
                    p712.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p712));
                    Paragraph p812 = new Paragraph(aeaofimp.REmark.ToString(), font);
                    pdfDoc.Add(p812);

                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk ck12 = new Chunk("Last Year Individual and/or Departmental Objective revision", font2);
                    ck12.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(ck12));
                    Paragraph p22 = new Paragraph(aeaofimp.LastObjectiveAndAcionPlan.ToString(), font);
                    pdfDoc.Add(p22);

                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p32 = new Chunk("How do you measure your objective achievement performance? (N/A/unacceptable/need improvement/ meet expectation/ Exceed expectation) Please put your justification together.", font2);
                    p32.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p32));
                    Paragraph p42 = new Paragraph(aeaofimp.ObjectiveAchivmentMeasure.ToString(), font);
                    pdfDoc.Add(p42);
                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p52 = new Chunk("What strategy did you use for the effective implementation?", font2);
                    p52.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p52));
                    Paragraph p62 = new Paragraph(aeaofimp.StrategiesUsed.ToString(), font);
                    pdfDoc.Add(p62);
                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p72 = new Chunk("What do you plan for effective objective achievement in the new year?", font2);
                    p72.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p72));
                    Paragraph p82 = new Paragraph(aeaofimp.NewYearPlan.ToString(), font);
                    pdfDoc.Add(p82);
                    pdfDoc.Add(new Paragraph("\n"));

                    pdfDoc.NewPage();
                    pdfDoc.Add(pic);
                    pdfDoc.Add(new Paragraph("\n"));
                }
                DataAccess.AdministrativeRelatedIssuePerformance adm = (from x in db.AdministrativeRelatedIssuePerformances
                                                                        where x.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                                         x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                        select x).SingleOrDefault();
                if (adm != null)
                {
                    Paragraph title3 = new Paragraph("Administrative related  issues performance revision", font2);
                    pdfDoc.Add(title3);
                    pdfDoc.Add(new Paragraph("\n"));
                    Paragraph title33 = new Paragraph("(Adhered to company rules and regulations, Punctual to start work, proper dressing, proper allocation/planning of annual leave, Responsible attitude,  Training attendance, Willingness to assist at various tasks, Proper use of company property, Serving as an example for good practices…..)", font2);
                    pdfDoc.Add(title33);
                    pdfDoc.Add(new Paragraph("\n"));

                    Chunk ck13 = new Chunk("How do you measure your performance?(N / A / unacceptable / need improvement / meet expectation / Exceed expectation) Please put your justification together.", font2);
                    ck13.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(ck13));
                    Paragraph p23 = new Paragraph(adm.PerformanceMeasure.ToString(), font);
                    pdfDoc.Add(p23);
                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p33 = new Chunk("What do you plan for effective Administrative related issues performance achievement in the new year?", font2);
                    p33.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p33));
                    Paragraph p43 = new Paragraph(adm.NewYearPlan.ToString(), font);
                    pdfDoc.Add(p43);
                    pdfDoc.Add(new Paragraph("\n"));
                }

                DataAccess.MarketingRelatedIssuePerformance mkt = (from x in db.MarketingRelatedIssuePerformances
                                                                   where x.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                                    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                                   select x).SingleOrDefault();
                if (mkt != null)
                {

                    Paragraph title4 = new Paragraph("PAG reputation/Marketing  related performance revision", font2);
                    pdfDoc.Add(title4);
                    pdfDoc.Add(new Paragraph("\n"));
                    Paragraph title44 = new Paragraph("(Client satisfaction with quality/quantity of work, professional communication with the client, Communicate clearly and intelligently in person, through email and during telephone, Contribution to bring new market, Ability to maintain existing client….)", font2);
                    pdfDoc.Add(title44);
                    pdfDoc.Add(new Paragraph("\n"));

                    Chunk ck134 = new Chunk("How do you measure your performance? (N/A/unacceptable/need improvement/ meet expectation/ Exceed expectation) Please put your justification together.", font2);
                    ck134.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(ck134));
                    Paragraph p234 = new Paragraph(mkt.PerformanceMeasure.ToString(), font);
                    pdfDoc.Add(p234);
                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p334 = new Chunk("What do you plan for effective PAG reputation/Marketing related performance achievement in the new year?", font2);
                    p334.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p334));
                    Paragraph p434 = new Paragraph(mkt.NewYearPlan.ToString(), font);
                    pdfDoc.Add(p434);
                    pdfDoc.Add(new Paragraph("\n"));
                }

                pdfDoc.NewPage();
                pdfDoc.Add(pic);
                pdfDoc.Add(new Paragraph("\n"));

                DataAccess.OverAllGeneralPerformance oall = (from x in db.OverAllGeneralPerformances
                                                             where x.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                              x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                             select x).SingleOrDefault();

                if (oall != null)
                {
                    Paragraph title5 = new Paragraph("Overall performance/General performance revision", font2);
                    pdfDoc.Add(title5);
                    Paragraph title55 = new Paragraph("How do you measure your performance? (N/A/unacceptable/need improvement/ meet expectation/ Exceed expectation) Please put your justification together.", font2);
                    pdfDoc.Add(title55);
                    Chunk ck151 = new Chunk("How do you measure your performance? (N/A/unacceptable/need improvement/ meet expectation/ Exceed expectation) Please put your justification together.", font2);
                    ck151.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(ck151));
                    Paragraph p252 = new Paragraph(oall.PerformanceMeasure.ToString(), font);
                    pdfDoc.Add(p252);
                    Chunk p353 = new Chunk("What do you plan for effective overall/ General performance achievement in the new year?", font2);
                    p353.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p353));
                    Paragraph p555 = new Paragraph(oall.NewYearPlan.ToString(), font);
                    pdfDoc.Add(p555);
                }

                DataAccess.AddionalPAGRelatedGeneral adt = (from x in db.AddionalPAGRelatedGenerals
                                                            where x.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                             x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                            select x).SingleOrDefault();
                if (adt != null)
                {
                    Paragraph title6 = new Paragraph("Additional points Related with PAG  in general", font2);
                    pdfDoc.Add(title6);

                    Chunk gp1 = new Chunk("Good practices", font2);
                    gp1.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(gp1));
                    Paragraph gp11 = new Paragraph(adt.GoodPractices.ToString(), font);
                    pdfDoc.Add(gp11);

                    Chunk ar1 = new Chunk("Areas to be reviewed", font2);
                    ar1.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(ar1));
                    Paragraph ar11 = new Paragraph(adt.AreasToBeReviewed.ToString(), font);
                    pdfDoc.Add(ar11);

                    Chunk es1 = new Chunk("Employee Statement", font2);
                    es1.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(es1));
                    Paragraph es12 = new Paragraph(adt.EmployeeStatement.ToString(), font);
                    pdfDoc.Add(es12);
                    pdfDoc.Add(new Paragraph("\n"));
                }

                Paragraph title77 = new Paragraph("My work plan for the year 2020/21", font2);
                pdfDoc.Add(title77);
                pdfDoc.Add(new Paragraph("\n"));

                PdfPTable t1 = new PdfPTable(6);
                t1.WidthPercentage = 100;
                //t1.SpacingBefore = 45f;
                t1.TotalWidth = 206f;
                t1.AddCell(new Paragraph("No.", font));
                t1.AddCell(new Paragraph("Smart Objectives", font));
                t1.AddCell(new Paragraph("Action Plan", font));
                t1.AddCell(new Paragraph("End Result", font));
                t1.AddCell(new Paragraph("Start Time", font));
                t1.AddCell(new Paragraph("End Time", font));

                //var EpointsAM = (from ev in db.LKEmployeesToLineMGREvaluations where ev.DataTypes == 3 select ev).ToList();
                var SElectedEmpPlans = (from p in db.WorkPlanforNextYears where p.EmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                             p.EvaluationPlanPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                        select p).ToList();
                int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);
                Session["LoggedINEMployee"] = loggerId;

                int rowcounter = 1;

                foreach (var p in SElectedEmpPlans)
                {
                    t1.AddCell(new Paragraph(rowcounter.ToString(), font));
                    t1.AddCell(new Paragraph(p.SmartObjective.ToString(), font));
                    t1.AddCell(new Paragraph(p.ActionPlan.ToString(), font));
                    t1.AddCell(new Paragraph(p.EndResult.ToString(), font));
                    t1.AddCell(new Paragraph(Convert.ToDateTime(p.TimeFrameStart).ToString("yyyy - MM - dd"), font));
                    t1.AddCell(new Paragraph(Convert.ToDateTime(p.TimeFrameEnd).ToString("yyyy - MM - dd"), font));

                    rowcounter++;
                }
                float[] widths = new float[] { 1, 5, 5, 5, 3, 3 };
                t1.SetWidths(widths);
                pdfDoc.Add(t1);

                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=EmployeeAnnualPerformanceEvaluationSheet.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Incorrect Data Sent - Possible solution - Please Select the Correct Employee');</script>");
            }
        }

        protected void DDLEvaluatedEmployee_DataBound(object sender, EventArgs e)
        {
             DDLEvaluatedEmployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("  ------   Please Select Employee   ------", ""));
        }
    }
}