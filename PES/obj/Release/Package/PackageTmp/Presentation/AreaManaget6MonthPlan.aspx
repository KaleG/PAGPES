﻿<%@ Page Title="Next Six Month Plan By Your Line Manager" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="AreaManaget6MonthPlan.aspx.cs" Inherits="PES.Presentation.AreaManaget6MonthPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row" style=" width:95%; margin-left:2%;background-color: #f2f2f2; margin-bottom: 5px;margin-top: 5px; height: 21px">
    <asp:Label runat="server" style="font-family:'Book Antiqua';font-size:16px;" class="label" Text="ከዚህ የሚከተሉት ላይ ለሚቀጥሉት ስድስት ወራት በአትኩሮት መስራት እፈልጋለሁ፡፡" ID="LblIntroHeaderAM" ForeColor="Black"></asp:Label>
    <asp:Label runat="server" ForeColor="Black" style="font-family:'Book Antiqua';font-size:16px;" class="label" Text="I would like to focus on the following for the next six months" ID="LblIntroHeaderEN"></asp:Label>
     </div> 

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
