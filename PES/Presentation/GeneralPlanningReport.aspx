<%@ Page Title="General Planning Report" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="GeneralPlanningReport.aspx.cs" Inherits="PES.Presentation.GeneralPlanningReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-lg-2 col-lg-offset-10">
    <h6 style ="color:#357EB5">Top Priority</h6>
    <h6 style ="color:#F2CA00">Medium Priority</h6>
    <h6 style ="color:#DB003D">Low Priority</h6>
    </div>
    </div>


   <asp:Table Style="width:95%; margin-left:2%" class="table table-condensed table-hover table-striped table-bordered table-responsive" ID="Table11" runat="server">

       </asp:Table>

</asp:Content>
