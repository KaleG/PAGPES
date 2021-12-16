<%@ Page Title="Next Six Month Plan By Line Manager Report" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="6MonthPlanReports.aspx.cs" Inherits="PES.Presentation._6MonthPlanReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="border: thin dotted #00FFFF; margin-bottom: 15px;margin-top: 5px; width: 95%; margin-left: 2%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
         <tr>  
             <td>
                 <asp:Label CssClass="label label-info" Width="100%" Height="30px" ID="Label2" runat="server" Text="Select Evaluator" Font-Size="Medium"></asp:Label>
            </td>
             <td class="formTable">
                <asp:DropDownList ID="DDLEvaluators" runat="server" BackColor="#C3CDDB" 
                    CssClass="" DataSourceID="SQLSEmployeesList"
                    DataTextField="FullENName" DataValueField="Id" Height="30px" Width="100%"
                    Font-Names="Book Antiqua">
                    <asp:ListItem>--Select Evaluator </asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SQLSEvaluatorList" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>" SelectCommand="SELECT * FROM [View_EmployessList]"></asp:SqlDataSource>
            </td>
             <td>
                 <asp:Label ID="Label1" CssClass="label label-info" Width="100%" Height="30px" runat="server" Text="Select Employee" Font-Size="Medium"></asp:Label>
            </td>

              <td class="formTable">
                <asp:DropDownList ID="DDLEvaluatedEmployee" runat="server" BackColor="#C3CDDB" 
                    CssClass="" DataSourceID="SQLSEmployeesList"
                    DataTextField="FullENName" DataValueField="Id" Height="30px" Width="100%"
                    Font-Names="Book Antiqua">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SQLSEmployeesList" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>" SelectCommand="SELECT * FROM [View_EmployessList]"></asp:SqlDataSource>
            </td>
             <td>
                <asp:Button ID="BtnGetReport" runat="server" Text="Get Report" CssClass="btn btn-primary" OnClick="BtnGetReport_Click" Width="100%" Height="30px" />
            </td>           
        </tr>
    </table>

     <asp:Table Style="width:95%; margin-left:2%" class="table table-condensed table-hover table-striped table-bordered table-responsive" ID="Table1" runat="server">
        <asp:TableHeaderRow ID="englishHeader" runat="server">

            <asp:TableHeaderCell># </asp:TableHeaderCell>
            <asp:TableHeaderCell>Major Focus Areas  (የምዘና ነጥቦች) </asp:TableHeaderCell>
            <asp:TableHeaderCell>Top Priority (ከፍተኛ ቅድሚያ) </asp:TableHeaderCell>
            <asp:TableHeaderCell>Medium Priority (መካከለኛ  ቅድሚያ)</asp:TableHeaderCell>
            <asp:TableHeaderCell>Lower Priority (መጨረሻ ቅድሚያ)</asp:TableHeaderCell>
            <asp:TableHeaderCell>Remark (ማስታወሻ)</asp:TableHeaderCell>

        </asp:TableHeaderRow>

    </asp:Table>

     <div class="row" style=" width:95%; margin-left:2%;background-color: #f2f2f2; margin-bottom: 25px;margin-top: 25px; height: 100px">
        <asp:Label runat="server" style="font-family:'Book Antiqua';font-size:14px;" class="label" Text="እባክዎ ሌሎች ከስራ አፈፃፀሞ ጋር የተያያዙ ነገሮች ካሉ ያብራሩ፡፡ ተጨማሪ ገጽ መጠቀም ይችላሉ፡፡  " ID="LblAdditionalAM" ForeColor="Black"></asp:Label>
        <asp:Label runat="server" ForeColor="Black" style="font-family:'Book Antiqua';font-size:14px;" class="label" Text="Please specify any thing in relation to your performance. You can use additional page too! " ID="LblAdditionalEN"></asp:Label>
        <textarea enableviewstate="false" runat="server" class="md-textarea form-control" id="TARAdditionalPoints" cols="20" rows="3"></textarea>
    </div>


</asp:Content>
