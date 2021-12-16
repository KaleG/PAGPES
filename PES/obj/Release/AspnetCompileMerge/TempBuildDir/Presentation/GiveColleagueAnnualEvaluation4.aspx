<%@ Page Title="Give colleage ammual feedback" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="GiveColleagueAnnualEvaluation4.aspx.cs" Inherits="PES.Presentation.GiveColleagueAnnualEvaluation4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12" id="viewParticipantsRegion" style="margin-left: 1%" runat="server">
            <table style="border: thin dotted #cc7a00; margin-bottom: 15px; margin-top: 5px; width: 95%; margin-left: 1%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
                <tr>
                    <td class="formTable" colspan="2">
                        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1_SelectedColleagues" DataTextField="EmployeeFullName" DataValueField="EmployeeId" Font-Names="Book Antiqua" Height="100%" Width="100%" Style="margin-left: 0px;" Rows="6" OnSelectedIndexChanged="btnEvaluateSelected_Click"></asp:ListBox>
                    </td>
                </tr>
                <tr>                    
                    <td class="formTable">
                        <asp:LinkButton ID="btnEvaluateSelected" runat="server" Style="width: 98%; margin: 5px;" CssClass="btn" Text="Evaluate Selected" OnClick="btnEvaluateSelected_Click" BorderColor="#cc7a00" BorderStyle="Dotted"><span class="glyphicon glyphicon-ok"></span> Evaluate Selected</asp:LinkButton>
                    </td>
                    <td class="formTable">
                        <asp:LinkButton ID="btnReject" runat="server" Style="width: 98%; margin: 5px;" CssClass="btn" Text="Reject" OnClick="btnReject_Click" BorderColor="#cc7a00" BorderStyle="Dotted"><span class="glyphicon glyphicon-remove"></span> Reject</asp:LinkButton>
                    </td>
                </tr>

            </table>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1_SelectedColleagues" ConnectionString='<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>' SelectCommand="SELECT * FROM [View_employe_EvaluatorCollueage] WHERE (([EvaluatorColleague] = @EmployeeId) AND ([period] = @period))">
                <SelectParameters>
                    <asp:SessionParameter SessionField="loggerId" Name="EmployeeId" Type="Int32"></asp:SessionParameter>
                    <asp:SessionParameter SessionField="EvaluationPeriod" Name="period" Type="Int32"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>

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

            <div class="row" style=" width:95%; margin-left:2%;">
    <asp:CheckBox ID="ChkIDontMind" Text="I don't mind if the employee see the evaluation" runat="server"  />
    </div>

            <div class="row" style="width: 95%; margin-left: 2%; background-color: #f5f8fa; margin-bottom: 5px; margin-top: 5px; height: 40px">
                <div class="col-lg-2 col-lg-offset-4">
            <asp:Button ID="LinkButton3" OnClientClick="return dataSaved()" Style="width: 100%; margin: 5px;" CssClass="btn btn-default" runat="server" Text="Clear" Enabled="false" OnClick="LinkButton3_Click" />
                </div>
                <div class="col-lg-2">
            <asp:Button ID="LinkButton4" Style="width: 100%; margin: 5px;" CssClass="btn btn-default" runat="server" Text="Save" Enabled="false" OnClick="LinkButton4_Click" />
                </div>
            </div>

        </div>
    </div>
    <script>
        function dataSaved() {
            var someSession = '<%=Session["UserLoggedInID1"] %>';
            if (someSession != null) {
                //alert("Data Successfully Updated" );
                var  i = "";
            }            
        }
    </script>
</asp:Content>
