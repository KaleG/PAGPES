<%@ Page Title="Employee by Employee Evaluation" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="ReportOnColleagueEvaluation.aspx.cs" Inherits="PES.Presentation.ReportOnColleagueEvaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="border: thin dotted #00FFFF; margin-bottom: 5px; margin-top: 5px; width: 95%; margin-left: 2%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
        <tr>
            <td class="formTable">
                <asp:DropDownList ID="DDLEvaluatedEmployee" runat="server" BackColor="#C3CDDB" DataSourceID="SqlDataSource1_LineManagersEmployee"
                    DataTextField="FullENName" DataValueField="Id" Height="30px" Width="100%"
                    Font-Names="Book Antiqua" OnDataBound="DDLEvaluatedEmployee_DataBound">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1_LineManagersEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>" SelectCommand="SELECT [Id], [FullENName] FROM [View_EmployessList]"></asp:SqlDataSource>
            </td>
            <td class="formTable">
                <asp:Button ID="BtnSelectEmployee" runat="server" Text="Get selected empployee feed back" CssClass="btn btn-default" OnClick="BtnSelectEmployee_Click" Width="100%" Height="30px" />
            </td>
            
        </tr>
    </table>

    <div id="DivheaderTxts" class="row" style="display: none; width: 95%; margin-left: 2%;" runat="server">
        <h4 style="color: #cc7a00;" id="Lbl1" runat="server">PAG PERFORMANCE EVALUATION SHEET</h4>
        <h5 style="color: #cc7a00;" id="LblEmployeeName" runat="server"></h5>
        <h5 style="color: #cc7a00;" id="LblDate" runat="server"></h5>
    </div>

    <div class="row" style="width: 95%; margin-left: 2%;">
        <div class="col-lg-12">

            <h4>Employees - Colleague FeedBack </h4>
            <!--<input id="BtnAreaOfColleagueFeedBAck" style="color: #cc7a00;" onclick="show11()" type="button" value="Colleague Feedback" class="btn btn-default btnFormSectoin" />-->
            <div class="row" id="DivAreaOfColleagueFeedBAck" runat="server">
                <div class="col-lg-12" style="width: 95%; margin-left: 2%;">
                    <table style="border: thin dotted #00FFFF; width: 99%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px; margin-top: inherit; margin-right: inherit; margin-bottom: inherit; margin-left: 10px; margin-top: 2%;">
                        <tr>
                            <td class="formTable" colspan="2">
                                <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1_SelectedColleagues" DataTextField="EvaluatorFullName" DataValueField="Id" Font-Names="Book Antiqua" Height="100%" Width="100%" Style="margin-left: 0px;" Rows="6"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="formTable">
                                <asp:LinkButton ID="btnGetSelected" runat="server" Style="width: 98%; margin: 5px;" CssClass="btn" OnClick="btnGetSelected_Click" BorderColor="#cc7a00" BorderStyle="Dotted"><span class="glyphicon glyphicon-ok"></span> Get Selected</asp:LinkButton>
                            </td>
                        </tr>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1_SelectedColleagues" ConnectionString='<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>' SelectCommand="SELECT * FROM [View_employe_EvaluatorCollueage] WHERE (([EmployeeId] = @EmployeeId) AND ([period] = @period))">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DDLEvaluatedEmployee" PropertyName="SelectedValue" Name="EmployeeId" Type="Int32"></asp:ControlParameter>
                                <asp:SessionParameter SessionField="EvaluationPeriod" Name="period" Type="Int32"></asp:SessionParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </table>
                    <asp:Button ID="BtnExporttoPdf" runat="server" OnClick="BtnExporttoPdf_Click" Style="color: #cc7a00; width: 95%; margin-left: 2%;" class="btn btn-default btnFormSectoin" Text="Export to Pdf" />
                    <div class="row">
                        <div class="col-lg-12" id="Div1" style="margin-top: 2%" runat="server">

                            <asp:Table Style="width: 95%; margin-left: 2%" class="table table-condensed table-hover table-striped table-bordered table-responsive" ID="Table1" runat="server">
                                <asp:TableHeaderRow ID="englishHeader" runat="server">

                                    <asp:TableHeaderCell># </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Evaluation Points (የምዘና ነጥቦች) </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Unacceptable (ተቀባይነት የሌለው) </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Need Improvement (መሻሻል ይፈልጋል)</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Meet Expectations (የሚጠበቅበት ደርሷል)</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Exceeds Expectations (ከሚጠበቀው በላይ ነው)</asp:TableHeaderCell>

                                </asp:TableHeaderRow>

                            </asp:Table>

                            <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                                <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="እባክዎ ሌሎች ከስራ አፈፃፀሞ ጋር የተያያዙ ነገሮች ካሉ ያብራሩ፡፡ ተጨማሪ ገጽ መጠቀም ይችላሉ፡፡ " ID="LblAdditionalAM" ForeColor="Black"></asp:Label>
                                <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Please specify any thing in relation to your performance. You can use additional page too!" ID="LblAdditionalEN"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TARAdditionalPoints" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                            </div>

                            <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 5px; margin-top: 5px; height: 20px">
                                <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="" ID="LblIdontMind" ForeColor="Black"></asp:Label>
                            </div>

                            <div class="row" style=" width:95%; margin-left:2%;">
    <asp:CheckBox ID="ChkLetEmployeeView" Text="Let the Employee View This Evaluation" runat="server"  />
    </div>
                            <div class="col-lg-12">
            <asp:Button ID="BtnSaveStauts" OnClientClick="return successfullysaved()" Style="width: 97%; margin-left:1%" CssClass="btn btn-warning" runat="server" Text="Save Status" Enabled="false" OnClick="BtnSaveStauts_Click" />
                    </div>



                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>

        function successfullysaved() {
            alert("Data Successfully Updated");
        }

        function ShowPrintPreview() {

            debugger;
            // document.getElementById("DivAreaOfAchievemtn").hidden = false;
            // document.getElementById("DivAreaOfImrovement") = false;

            var panel0 = document.getElementById("<%=DivheaderTxts.ClientID %>");
                var panelH1 = document.getElementById("<%=DivAreaOfColleagueFeedBAck.ClientID %>");



            panel.style = 'preview-message';
            var printWindow = window.open(panel, '', 'height=700,width=1100');
            printWindow.document.styleSheets = 'preview-message';
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panelH1.innerHTML);

            //printWindow.document.writeln(panel8.innerHTML);
            // printWindow.document.writeln(panel9.innerHTML);
            // printWindow.document.writeln(panel10.innerHTML);
            //printWindow.document.writeln(panel11.innerHTML);

            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 1000);
            return false;
        }

    </script>

</asp:Content>
