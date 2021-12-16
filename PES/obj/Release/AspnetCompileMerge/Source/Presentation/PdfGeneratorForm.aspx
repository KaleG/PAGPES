<%@ Page Title="PdfGeneratorForm" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="PdfGeneratorForm.aspx.cs" Inherits="PES.Presentation.PdfGeneratorForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="BtnGenertePdf" OnClick="BtnGenertePdf_Click" runat="server" Text="Button" />
</asp:Content>
