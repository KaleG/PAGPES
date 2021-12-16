<%@ Page Title="" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="PES.Presentation.WebForm3" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Chart runat="server" ID="ctl00" DataSourceID="SqlDataSource1">
        <series><asp:Series Name="Series1" XValueMember="EvaluationPointGiven" YValueMembers="EvaluationPointName"></asp:Series></series>
        <chartareas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></chartareas>
    </asp:Chart>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString %>" SelectCommand="SELECT * FROM [View_EvaluationPoint12]">
    </asp:SqlDataSource>
</asp:Content>
