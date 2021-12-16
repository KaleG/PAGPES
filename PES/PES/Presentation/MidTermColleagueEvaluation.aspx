<%@ Page Title="" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="MidTermColleagueEvaluation.aspx.cs" Inherits="PES.Presentation.MidTermColleagueEvaluation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="border: thin dotted #00FFFF; margin-bottom: 15px;margin-top: 5px; width: 95%; margin-left: 2%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
         <tr>
            <td class="formTable">
                <asp:DropDownList ID="DDLEvaluatedEmployee" runat="server" BackColor="#C3CDDB" 
                    CssClass="" DataSourceID="SQLSEmployeesList"
                    DataTextField="FullENName" DataValueField="Id" Height="30px" Width="100%" 
                    Font-Names="Book Antiqua">
                    <asp:ListItem>--Select Evaluator </asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SQLSEmployeesList" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>" SelectCommand="SELECT * FROM [View_EmployessList]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:Button ID="BtnSelectEmployee" runat="server" Text="Evaluate Selected Employee" CssClass="btn btn-primary" OnClick="BtnSelectEmployee_Click" Width="100%" Height="30px" />
            </td>
        </tr>
    </table>

     <div class="row" style=" width:95%; margin-left:2%;background-color: #f2f2f2; margin-bottom: 5px;margin-top: 5px; height: 21px">
    <asp:Label runat="server" style="font-family:'Book Antiqua';font-size:16px;" class="label" Text="እባክዎ ከዚህ በታች ያሉት ነጥቦች ላይ ተመኩዘው የስራ ባልደረባዎን ይመዝኑ፡፡" ID="LblIntroHeaderAM" ForeColor="Black"></asp:Label>
    <asp:Label runat="server" ForeColor="Black" style="font-family:'Book Antiqua';font-size:16px;" class="label" Text="Performance Evaluation to be Filled by Line Manager." ID="LblIntroHeaderEN"></asp:Label>
     </div> 

    <asp:Table Style="width:95%; margin-left:2%" class="table table-condensed table-hover table-striped table-bordered table-responsive" ID="Table1" runat="server">
        <asp:TableHeaderRow ID="englishHeader" runat="server">

            <asp:TableHeaderCell># </asp:TableHeaderCell>
            <asp:TableHeaderCell>Evaluation Points (የምዘና ነጥቦች) </asp:TableHeaderCell>
            <asp:TableHeaderCell>Unacceptable (ተቀባይነት የሌለው) </asp:TableHeaderCell>
            <asp:TableHeaderCell>Need Improvement (መሻሻል ይፈልጋል)</asp:TableHeaderCell>
            <asp:TableHeaderCell>Meet Expectations (የሚጠበቅበት ደርሷል)</asp:TableHeaderCell>
            <asp:TableHeaderCell>Exceeds Expectations (ከሚጠበቀው በላይ ነው)</asp:TableHeaderCell>

        </asp:TableHeaderRow>

    </asp:Table>

    <div class="row" style=" width:95%; margin-left:2%;background-color: #f2f2f2; margin-bottom: 40px;margin-top: 40px; height: 100px">
        <asp:Label runat="server" style="font-family:'Book Antiqua';font-size:14px;" class="label" Text="ከላይ የተዘረዘሩትን የስራ አፈፃፀም መገምገሚያዎች ላይ እንዲሁም የሰራተኛውን የስራ አፈፃፀም በተመለከተ የቅርብ ሃላፊ አስተያየት" ID="LblAdditionalAM" ForeColor="Black"></asp:Label>
        <asp:Label runat="server" ForeColor="Black" style="font-family:'Book Antiqua';font-size:14px;" class="label" Text="Line Manager Statement on the performance evaluation filled out above as well as her/his opinion of the performance of the staff member " ID="LblAdditionalEN"></asp:Label>
        <textarea enableviewstate="false" runat="server" class="md-textarea form-control" id="TARAdditionalPoints" cols="20" rows="3"></textarea>
    </div>


    <div class="row" style="width:95%; margin-left:2%; overflow-y: scroll; background-color: #f2f2f2; margin-bottom: 40px;margin-top: 40px; height: 100px">
        <div class="col-lg-2 col-lg-offset-3">
            <asp:Button Style="width: 100%; margin: 5px;" CssClass="btn btn-primary" ID="btnCleare" runat="server" Enabled="false" Text="Clear" OnClick="btnCleare_Click" />
        </div>
        <div class="col-lg-2">
            <asp:Button Style="width: 100%; margin: 5px;" CssClass="btn btn-primary" ID="BtnSave" runat="server" Text="Save" Enabled="false" OnClick="BtnSave_Click" />
        </div>
        <div class="col-lg-2">
            <asp:Button Style="width: 100%; margin: 5px;" CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Submit" Enabled="false" OnClick="btnSubmit_Click" />
        </div>
    </div>

</asp:Content>
