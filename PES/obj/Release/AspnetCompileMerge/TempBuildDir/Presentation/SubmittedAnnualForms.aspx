<%@ Page Title="Submitted Annual Forms" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="SubmittedAnnualForms.aspx.cs" Inherits="PES.Presentation.SubmittedAnnualForms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row" style="width:95%;margin-left:2%;">
        <div class="col-lg-6">
            <h5>UnSubmitted Forms</h5>
            <asp:ListBox ID="LbxUnsubmittedList" runat="server" Font-Names="Book Antiqua" Height="100%" Width="95%" Style="margin-left: 10px;" Rows="15"></asp:ListBox>

        </div>
        <div class="col-lg-6">
            <h5>Submitted Forms</h5>
            <asp:ListBox ID="LbxSubmittedList" runat="server" Font-Names="Book Antiqua" Height="100%" Width="95%" Style="margin-left: 10px;" Rows="15"></asp:ListBox>
        </div>
    </div>

</asp:Content>
