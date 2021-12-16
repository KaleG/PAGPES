<%@ Page Title="" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="EvaluationByLineManager.aspx.cs" Inherits="PES.Presentation.EvaluationByLineManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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
        <asp:Label runat="server" style="font-family:'Book Antiqua';font-size:14px;" class="label" Text="እባክዎ ሌሎች ከስራ አፈፃፀሞ ጋር የተያያዙ ነገሮች ካሉ ያብራሩ፡፡ ተጨማሪ ገጽ መጠቀም ይችላሉ፡፡ " ID="LblAdditionalAM" ForeColor="Black"></asp:Label>
        <asp:Label runat="server" ForeColor="Black" style="font-family:'Book Antiqua';font-size:14px;" class="label" Text="Please specify any thing in relation to your performance. You can use additional page too!" ID="LblAdditionalEN"></asp:Label>
        <textarea enableviewstate="false" runat="server" class="md-textarea form-control" id="TARAdditionalPoints" cols="20" rows="3"></textarea>
    </div>


   


</asp:Content>
