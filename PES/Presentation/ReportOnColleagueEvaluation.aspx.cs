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
    public partial class ReportOnColleagueEvaluation : System.Web.UI.Page
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

        protected void btnGetSelected_Click(object sender, EventArgs e)
        {
            try
            {
                BtnSaveStauts.Enabled = true;
                TARAdditionalPoints.Text = string.Empty;
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
               // DivAreaOfColleagueFeedBAck.Visible = true;

                DataAccess.EvaluationDisclosure Ediscloser = (from d in db.EvaluationDisclosures
                                                              where d.EvaluatedEmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                 d.EvalutorId == Convert.ToInt32(ListBox1.SelectedValue) &&
                                 d.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                              select d).SingleOrDefault();
                if (Ediscloser.IDontMind == true)
                {
                    LblIdontMind.Text = "Evaluator opinion : I don't Mind if the Employee See the Evaluation";
                }
                else
                {
                    LblIdontMind.Text = "Evaluator opinion : I don't Want the Employee to See the Evaluation";
                }


                if (Convert.ToBoolean(Ediscloser.AdminOpinionOnDisclosore))
                {
                    ChkLetEmployeeView.Checked = true;
                }
                else
                {
                    ChkLetEmployeeView.Checked = false;
                }

            }
            catch (Exception exx)
            { Response.Write("<script> alert('Evaluation Result is not Ready - Please Try Again');</script>"); }
        }

        public static BaseFont GetFont(string fontName)
        {
            return BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~/Bin/" + fontName + ".ttf"), BaseFont.WINANSI, BaseFont.EMBEDDED);
        }

        protected void BtnExporttoPdf_Click(object sender, EventArgs e)
        {
            try
            {
                var evaluated233 = (from evd in db.AnnualColleagueEvaluations
                                    where evd.EvaluationPointName == 15
                                    && evd.EvaluatorColleagueId == Convert.ToInt32(ListBox1.SelectedValue)
       && evd.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
       evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                    select evd).SingleOrDefault();

                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(PES.Properties.Resources.Capture, System.Drawing.Imaging.ImageFormat.Jpeg);
                pic.ScaleAbsolute(550f, 80f);

                string theEmp = "Employee :" + " " + (from L in db.Employees where L.Id == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) select L).SingleOrDefault().EName.ToString() + " " + (from L in db.Employees where L.Id == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) select L).SingleOrDefault().ELName.ToString();
                string theLmg = "Colleague :" + " " + (from L in db.Employees where L.Id == Convert.ToInt32(evaluated233.EvaluatorColleagueId) select L).SingleOrDefault().EName.ToString() + " " + (from L in db.Employees where L.Id == Convert.ToInt32(evaluated233.EvaluatorColleagueId) select L).SingleOrDefault().ELName.ToString();

                Document pdfDoc = new Document(PageSize.A4, 35, 25, 25, 25);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.AddLanguage("am");
                // pdfDoc.AddLanguage("pl");
                pdfDoc.AddLanguage("en-us");
                pdfDoc.Open();
                //pic.SetAbsolutePosition(0, 0);
                pdfDoc.Add(pic);
                //BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //BaseFont bfAM = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                // BaseFont sm = GetFont("Nyala"); //The fontName here should exactly match` the` file name in bin folder
                // iTextSharp.text.Font font = new iTextSharp.text.Font(sm, 10, iTextSharp.text.Font.NORMAL);
                // iTextSharp.text.Font fontAM = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                //BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\NYALA.TTF", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                pdfDoc.Add(new Paragraph("\n"));
                Paragraph Text = new Paragraph("Employee to Employee Evaluation", font);
                pdfDoc.Add(Text);
                pdfDoc.Add(new Paragraph("\n"));
                Paragraph LineMgr = new Paragraph(theLmg, font);
                pdfDoc.Add(LineMgr);
                pdfDoc.Add(new Paragraph("\n"));
                Paragraph theeple = new Paragraph(theEmp, font);
                pdfDoc.Add(theeple);

                pdfDoc.Add(new Paragraph("\n"));

                PdfPTable t1 = new PdfPTable(6);
                t1.WidthPercentage = 100;
                //t1.SpacingBefore = 45f;
                t1.TotalWidth = 206f;
                // t1.AddCell("N0.", font,);
                t1.AddCell(new Paragraph("No.", font));
                t1.AddCell(new Paragraph("Evaluation Points", font));
                t1.AddCell(new Paragraph("Unacceptable", font));
                t1.AddCell(new Paragraph("Need Improvement", font));
                t1.AddCell(new Paragraph("Meet Expectations", font));
                t1.AddCell(new Paragraph("Exceeds Expectations", font));

                var EpointsAM = (from ev in db.LKColleagueFeedBAckPoints where ev.DataType == 3 select ev).ToList();
                int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);
                Session["LoggedINEMployee"] = loggerId;

                int rows = EpointsAM.Count;
                int cols = 7;

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
                                t1.AddCell(new Paragraph(eAM.EvaluationName.ToString(), font));
                            }
                            else
                            {
                                //c.Controls.Add(new Label() { Text = eAM.EvaluationName.ToString() });
                                //tr.Cells.Add(c);
                                t1.AddCell(new Paragraph(eAM.EvaluationName.ToString(), font));
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
                float[] widths = new float[] { 1, 4, 3, 3, 3, 3 };
                t1.SetWidths(widths);
                pdfDoc.Add(t1);

                pdfDoc.Add(new Paragraph("\n"));

                Chunk ck1 = new Chunk("Please specify any thing in relation to your performance. You can use additional page too!", font);
                ck1.SetUnderline(1, -3);
                pdfDoc.Add(new Phrase(ck1));
                pdfDoc.Add(new Paragraph("\n"));
                Paragraph p8 = new Paragraph(evaluated233.EvaluationPointGiven.ToString(), font);
                pdfDoc.Add(p8);
                pdfDoc.Add(new Paragraph("\n"));

                DataAccess.EvaluationDisclosure Ediscloser2 = (from d in db.EvaluationDisclosures
                                                               where d.EvaluatedEmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                  d.EvalutorId == Convert.ToInt32(ListBox1.SelectedValue) &&
                                  d.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                               select d).SingleOrDefault();
                if (Ediscloser2.IDontMind == true)
                {
                    //LblIdontMind.Text = "Evaluator opinion : I don't Mind if am the Employee See the Evaluation";
                    Paragraph p8idm1 = new Paragraph("Evaluator opinion : I don't Mind if the Employee See the Evaluation", font);
                    pdfDoc.Add(p8idm1);
                    pdfDoc.Add(new Paragraph("\n"));
                }
                else
                {
                    //LblIdontMind2.Text = "Evaluator opinion : I don't Want the Employee to See the Evaluation";
                    Paragraph p8idm2 = new Paragraph("Evaluator opinion : I don't Want the Employee to See the Evaluation", font);
                    pdfDoc.Add(p8idm2);
                    pdfDoc.Add(new Paragraph("\n"));
                }

                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=EmployeetoEmployeeEvaluation.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            { Response.Write("<script> alert('Incorrect Data Sent Please Try Again');</script>"); }
        }

        protected void BtnSaveStauts_Click(object sender, EventArgs e)
        {
            bool AdminOpinionOnDisclosore = false;

            if (ChkLetEmployeeView.Checked == true)
            {
                AdminOpinionOnDisclosore = true;
            }

            DataAccess.EvaluationDisclosure Ediscloser = (from d in db.EvaluationDisclosures
                                                          where d.EvaluatedEmployeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                             d.EvalutorId == Convert.ToInt32(ListBox1.SelectedValue) &&
                             d.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                          select d).SingleOrDefault();
            if (Ediscloser != null)
            {
                Ediscloser.AdminOpinionOnDisclosore = AdminOpinionOnDisclosore;
                db.SubmitChanges();
            }
        }

        protected void DDLEvaluatedEmployee_DataBound(object sender, EventArgs e)
        {
            DDLEvaluatedEmployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("  ------   Please Select Employee   ------", ""));
        }

        protected void BtnSelectEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (DDLEvaluatedEmployee.SelectedIndex == 0)
                {
                    { Response.Write("<script> alert('Incorrect Data Sent Please Select Employee Again');</script>"); }
                }
            }
            catch (Exception ex)
            { Response.Write("<script> alert('Incorrect Data Sent Please Try Again');</script>"); }
        }
    }
}