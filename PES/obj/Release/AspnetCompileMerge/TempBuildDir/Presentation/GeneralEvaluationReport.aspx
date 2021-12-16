<%@ Page Title="General Evaluation Report" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="GeneralEvaluationReport.aspx.cs" Inherits="PES.Presentation.GeneralEvaluationReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-lg-2 col-lg-offset-10">
    <h6 id="lblUnacceptable" runat="server" style ="color:#418CF0">UnAcceptable</h6>
    <h6 id="lblNeedImprovement" runat="server" style ="color:#F2CA00">Need Improvement</h6>
    <h6 id="lblMeetexpectation" runat="server" style ="color:#DB003D">Meet Expectation</h6>
    <h6 id="lblExceedexpectation" runat="server" style ="color:#056492">Exceed Expectation</h6>
    </div>
    </div>
    <asp:Table Style="width:95%; margin-left:2%" class="table table-condensed table-hover table-striped table-bordered table-responsive" ID="Table11" runat="server">
           
           </asp:Table>
    
   
</asp:Content>
