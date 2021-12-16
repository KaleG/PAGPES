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
    public partial class MyEmployesEvaluation : System.Web.UI.Page
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

                if (!IsPostBack)
                {

                    var EpointsAM = (from ev in db.LKEmployeesToLineMGREvaluations where ev.DataTypes == 3 select ev).ToList();
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
                            if (i == 8)
                            {
                                c.Controls.Add(new Label() { ID = ("AM" + rowcounter).ToString(), Text = eAM.Id.ToString() });
                                tr.Cells.Add(c);
                                tr.Cells[8].Visible = false;
                            }
                        }
                        Table1.Rows.Add(tr);
                        rowcounter++;
                    }
                }
            }
            catch (Exception ex)
            {
                string eee = ex.Message;
            }
        }

        protected void BtnSelectEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserLoggedInID1"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                Session["PageTitle"] = this.Title.ToString();



                var checkExist = (from x in db.EmployeesToLineMGREvaluationForms
                                  where
                                                                     x.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
                                      x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();
                if (checkExist != null)
                {
                    TbxDirectOperational.Text = checkExist.DirectJobRElated.ToString();
                    TbxAdministrative.Text = checkExist.AdministrativeRElative.ToString();
                    TbxStaffDevelopemtn.Text = checkExist.StaffDevelopement.ToString();
                    TbxGeneral2.Text = checkExist.Generaln.ToString();
                }


                var EpointsAM = (from ev in db.LKEmployeesToLineMGREvaluations where ev.DataTypes == 3 select ev).ToList();
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
                            var evaluated = (from evd in db.EmployeesToLineMGREvaluations
                                             where evd.EvaluationPointName == eAM.Id
                                             && 
                                             evd.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
             evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
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
                            tr.Cells[8].Visible = false;
                        }
                    }
                    Table1.Rows.Add(tr);
                    rowcounter++;
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
                var checkExist = (from x in db.EmployeesToLineMGREvaluationForms
                                  where x.EmployeeId == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) &&
    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();
                //if (checkExist != null) { 
                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(PES.Properties.Resources.Capture, System.Drawing.Imaging.ImageFormat.Jpeg);
                pic.ScaleAbsolute(550f, 80f);
                string theEmp = "Employee :" + " " + (from L in db.Employees where L.Id == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) select L).SingleOrDefault().EName.ToString() + " " + (from L in db.Employees where L.Id == Convert.ToInt32(DDLEvaluatedEmployee.SelectedValue) select L).SingleOrDefault().ELName.ToString();
                string theLmg = "Line Manager :" + " " + (from L in db.Employees where L.Id == Convert.ToInt32(checkExist.LineManagerId) select L).SingleOrDefault().EName.ToString() + " " + (from L in db.Employees where L.Id == Convert.ToInt32(checkExist.LineManagerId) select L).SingleOrDefault().ELName.ToString();

                Document pdfDoc = new Document(PageSize.A4, 35, 25, 25, 25);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.AddLanguage("am");
                pdfDoc.Open();
                //pic.SetAbsolutePosition(0, 0);
                pdfDoc.Add(pic);
                //BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\NYALA.TTF", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                pdfDoc.Add(new Paragraph("\n"));
                Paragraph Text = new Paragraph("Employee to Line Manager Evaluation", font);
                pdfDoc.Add(Text);
                pdfDoc.Add(new Paragraph("\n"));
                Paragraph LineMgr = new Paragraph(theLmg, font);
                pdfDoc.Add(LineMgr);
                pdfDoc.Add(new Paragraph("\n"));
                Paragraph theeple = new Paragraph(theEmp, font);
                pdfDoc.Add(theeple);
                pdfDoc.Add(new Paragraph("\n"));

                Paragraph p1 = new Paragraph();
                Chunk ck1 = new Chunk("Direct operational related", font);
                ck1.SetUnderline(1, -3);
                pdfDoc.Add(new Phrase(ck1));
                Paragraph p2 = new Paragraph(checkExist.DirectJobRElated.ToString(), font);
                pdfDoc.Add(p2);
                pdfDoc.Add(new Paragraph("\n"));
                Chunk p3 = new Chunk("Administrative/ Supervision related", font);
                p3.SetUnderline(1, -3);
                pdfDoc.Add(new Phrase(p3));
                Paragraph p4 = new Paragraph(checkExist.AdministrativeRElative.ToString(), font);
                pdfDoc.Add(p4);
                pdfDoc.Add(new Paragraph("\n"));
                Chunk p5 = new Chunk("Staff development related", font);
                p5.SetUnderline(1, -3);
                pdfDoc.Add(new Phrase(p5));
                Paragraph p6 = new Paragraph(checkExist.StaffDevelopement.ToString(), font);
                pdfDoc.Add(p6);
                pdfDoc.Add(new Paragraph("\n"));
                Chunk p7 = new Chunk("አጠቃላይ ነገሮች General", font);
                p7.SetUnderline(1, -3);
                pdfDoc.Add(new Phrase(p7));
                Paragraph p8 = new Paragraph(checkExist.Generaln.ToString(), font);
                pdfDoc.Add(p8);
                pdfDoc.Add(new Paragraph("\n"));

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
                t1.AddCell(new Paragraph("Unsatisfactory", font));
                t1.AddCell(new Paragraph("Needs Improvement", font));
                t1.AddCell(new Paragraph("Fully Successful", font));
                t1.AddCell(new Paragraph("Commendable", font));
                t1.AddCell(new Paragraph("Outstanding", font));

                var EpointsAM = (from ev in db.LKEmployeesToLineMGREvaluations where ev.DataTypes == 3 select ev).ToList();
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
                                t1.AddCell(new Paragraph(eAM.EvaluationName.ToString(), font));
                            }
                            else
                            {
                                //c.Controls.Add(new Label() { Text = eAM.EvaluationName.ToString() });
                                //tr.Cells.Add(c);
                                t1.AddCell(new Paragraph(eAM.EvaluationName.ToString(), font));
                            }
                        }
                        if (i != 0 && i != 1 && i != 8)
                        {
                            var evaluated = (from evd in db.EmployeesToLineMGREvaluations
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

                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=EmployeetoLineManagerEvaluation.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            { Response.Write("<script> alert('Incorrect Data Sent Please Try Again');</script>"); }
        }

        protected void DDLEvaluatedEmployee_DataBound(object sender, EventArgs e)
        {
            DDLEvaluatedEmployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("  ------   Please Select Employee   ------", ""));
        }
    }
}