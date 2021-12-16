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
    public partial class LineManagersEvaluationReport : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();
            int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);
            Session["LoggedINEMployee"] = loggerId;
        }

        protected void BtnSelectEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (DDLEvaluatedEmployee.SelectedIndex != 0)
                {
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
                        Table1.Rows.Add(tr);
                        rowcounter++;
                    }
                }
                else {
                    Response.Write("<script>alert('Incorrect Data Sent - Possible solution - Please Select the Correct Employee');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Incorrect Data Sent - Please Try Again');</script>");
            }
        }

        protected void BtnExporttoPdf_Click(object sender, EventArgs e)
        {
            try
            {
                var checkExist = (from x in db.AnnualEmployeeEvaluationNotes
                                  where x.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();

                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(PES.Properties.Resources.Capture, System.Drawing.Imaging.ImageFormat.Jpeg);
                pic.ScaleAbsolute(550f, 80f);
                string theEmp = "Employee :" + " " + (from L in db.Employees where L.Id == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) select L).SingleOrDefault().EName.ToString() + " " + (from L in db.Employees where L.Id == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) select L).SingleOrDefault().ELName.ToString();
                var theLineManager = (from lm in db.Employee_LineManagers where lm.employeeID == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) select lm).SingleOrDefault();
                string theLmg = "Line Manager :" + " " + (from L in db.Employees where L.Id == Convert.ToInt32(theLineManager.LineManager) select L).SingleOrDefault().EName.ToString() + " " + (from L in db.Employees where L.Id == Convert.ToInt32(theLineManager.LineManager) select L).SingleOrDefault().ELName.ToString();

                Document pdfDoc = new Document(PageSize.A4, 35, 25, 25, 25);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.AddLanguage("am");
                pdfDoc.Open();
                //pic.SetAbsolutePosition(0, 0);
                pdfDoc.Add(pic);
                //BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                //FontFactory.Register("/Resources/NYALA.ttf", "nyala");
                //var font3 = FontFactory.GetFont("nyala");

                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\NYALA.TTF", BaseFont.IDENTITY_H, true);
               // Font NormalFont = new iTextSharp.text.Font(bf, 12, Font.NORMAL, Color.BLACK);

                //TtfUnicodeWriter TTFU = new TtfUnicodeWriter(pdfWriter);

                //BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                //FontFactory.Register("/Resources/NYALA.ttf", "nyala");
               // var font3 = FontFactory.GetFont("nyala");

                pdfDoc.Add(new Paragraph("\n"));
                Paragraph Text = new Paragraph("Line Manager to Employee Evaluation", font);
                pdfDoc.Add(Text);
                pdfDoc.Add(new Paragraph("\n"));
                Paragraph LineMgr = new Paragraph(theLmg, font);
                pdfDoc.Add(LineMgr);
                pdfDoc.Add(new Paragraph("\n"));
                Paragraph theeple = new Paragraph(theEmp, font);
                pdfDoc.Add(theeple);
                pdfDoc.Add(new Paragraph("\n"));

                if (checkExist != null)
                {
                    Paragraph p1 = new Paragraph();
                    Chunk ck1 = new Chunk("Direct operational related", font);
                    ck1.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(ck1));
                    Paragraph p2 = new Paragraph(checkExist.DirectJobRElated.ToString(), font);
                    
                    pdfDoc.Add(p2);
                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p3 = new Chunk("Administrative related", font);
                    p3.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p3));
                    Paragraph p4 = new Paragraph(checkExist.AdministrativeRalated.ToString(), font);
                    pdfDoc.Add(p4);
                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p5 = new Chunk("Client Handling related", font);
                    p5.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p5));
                    Paragraph p6 = new Paragraph(checkExist.ClientHandlingRElated.ToString(), font);
                    pdfDoc.Add(p6);
                    pdfDoc.Add(new Paragraph("\n"));
                    Chunk p7 = new Chunk("General", font);
                    p7.SetUnderline(1, -3);
                    pdfDoc.Add(new Phrase(p7));
                    Paragraph p8 = new Paragraph(checkExist.General.ToString(), font);
                    pdfDoc.Add(p8);
                    pdfDoc.Add(new Paragraph("\n"));
                }
                pdfDoc.NewPage();
                pdfDoc.Add(pic);
                pdfDoc.Add(new Paragraph("\n"));
                PdfPTable t1 = new PdfPTable(8);
                t1.WidthPercentage = 100;
                //t1.SpacingBefore = 45f;
                t1.TotalWidth = 206f;

                t1.AddCell(new Paragraph("No.", font));
                t1.AddCell(new Paragraph("Performance Factor", font));
                t1.AddCell(new Paragraph("N/A", font));
                t1.AddCell(new Paragraph("Unsatisfactory ", font));
                t1.AddCell(new Paragraph("Needs Improvement ", font));
                t1.AddCell(new Paragraph("Fully Successful", font));
                t1.AddCell(new Paragraph("Commendable ", font));
                t1.AddCell(new Paragraph("Outstanding ", font));

                var EpointsAM = (from ev in db.LKLineMgrFeedBAckPoints where ev.DataTypes == 3 select ev).ToList();
                int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);
                Session["LoggedINEMployee"] = loggerId;

                int rows = EpointsAM.Count;
                int cols = 9;

                int rowcounter = 1;

                foreach (var eAM in EpointsAM)
                {
                    //TableRow tr = new TableRow();
                    for (int i = 0; i < cols; i++)
                    {
                        // TableCell c = new TableCell();
                        if (i == 0)
                        {
                            // c.Controls.Add(new Label() { Text = rowcounter.ToString() });
                            // tr.Cells.Add(c);
                            t1.AddCell(new Paragraph(rowcounter.ToString(), font));
                        }
                        if (i == 1)
                        {
                            if (Session["SelectedLanguage"].ToString() == "AM")
                            {
                                //c.Controls.Add(new Label() { Text = eAM.EvaluationNameAmharic.ToString() });
                                //tr.Cells.Add(c);
                                t1.AddCell(new Paragraph(eAM.EvaluationNameAmharic.ToString(), font));
                            }
                            else
                            {
                                //c.Controls.Add(new Label() { Text = eAM.EvaluationName.ToString() });
                                //tr.Cells.Add(c);
                                t1.AddCell(new Paragraph(eAM.EvaluationNameAmharic.ToString(), font));
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
                                //c.Controls.Add(new RadioButton() { Checked = true, GroupName = eAM.EvaluationName.ToString() });
                                //tr.Cells.Add(c);
                                t1.AddCell("*");
                            }
                            else
                            {
                                // c.Controls.Add(new RadioButton() { GroupName = eAM.EvaluationName.ToString() });
                                // tr.Cells.Add(c);
                                t1.AddCell("");
                            }
                        }
                    }
                    //t1.Rows.Add(tr);
                    rowcounter++;
                }
                //t1.SetWidths(8);
                float[] widths = new float[] { 1, 5, 1, 2, 2, 2, 2, 2 };
                t1.SetWidths(widths);
                pdfDoc.Add(t1);

                pdfDoc.Add(new Paragraph("\n"));

                Chunk p13 = new Chunk("Rating Officers General Comment and Notes", font);
                p13.SetUnderline(1, -3);
                pdfDoc.Add(new Phrase(p13));
                pdfDoc.Add(new Paragraph("\n"));

                var checkExist2 = (from x in db.AnnualEmployeeEvaluationYesNos
                                   where x.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
     x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                   select x).SingleOrDefault();
                if (checkExist2 != null)
                {
                    Paragraph p15 = new Paragraph("1. The rated employee is performing at the Fully Successful level or above, and should be granted the next step within the Grade.", font);
                    pdfDoc.Add(p15);
                    Chunk p16 = new Chunk(checkExist2.FullySuccessfull.ToString(), font);
                    p16.SetUnderline(1, -3);
                    pdfDoc.Add(p16);
                    Paragraph p17 = new Paragraph("2. The employee has demonstrated outstanding performance and should be granted the next two-step within the Grade.", font);
                    pdfDoc.Add(p17);
                    Chunk p18 = new Chunk(checkExist2.OutStandingPerformance.ToString(), font);
                    p18.SetUnderline(1, -3);
                    pdfDoc.Add(p18);
                    Paragraph p19 = new Paragraph("3. The employee has demonstrated unsatisfactory performance that he/she needs to improve and do not deserve step increase.", font);
                    pdfDoc.Add(p19);
                    Chunk p111 = new Chunk(checkExist2.Unsatisfactory.ToString(), font);
                    p111.SetUnderline(1, -3);
                    pdfDoc.Add(p111);
                    Paragraph p112 = new Paragraph("4. The employee has demonstrated the ability to perform the responsibilities assigned at the next level of the career ladder and should be promoted when eligible (must have received a summary rating of Fully Successful or higher).", font);
                    pdfDoc.Add(p112);
                    Chunk p113 = new Chunk(checkExist2.ShouldBePromoted.ToString(), font);
                    p113.SetUnderline(1, -3);
                    pdfDoc.Add(p113);
                }
                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=LineManagertoEmployeeEvaluation.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            { Response.Write("<script>alert('Incorrect Data Sent - Please Try Again');</script>"); }
        }

        protected void DDLEvaluatedEmployee_DataBound(object sender, EventArgs e)
        {
            DDLEvaluatedEmployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("  ------   Please Select Employee   ------", ""));
        }
    }
}
