<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="PES.Presentation.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-lg-12" id="EditRegion" style="width: 100%;" runat="server">
                <h3 style="font-family: 'Book Antiqua'">Edit User and Password</h3>

                <table style="border: thin dotted #00FFFF; width: 95%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px; margin-top: inherit; margin-right: inherit; margin-bottom: inherit; margin-left: 10px;">
                    <tr>
                        <td class="formTable">
                            <asp:Label ID="Label81" runat="server" Text="Old Password :"></asp:Label></td>
                        <td class="formTable">
                            <asp:TextBox TextMode="Password" CssClass="formTbx" ID="TbxOldPassword"  Height="30px" name="TbxOldPassword" runat="server" EnableViewState="False"></asp:TextBox>
                        </td>
                    </tr>

                   <tr>
                        <td class="formTable">
                            <asp:Label ID="Label8" runat="server" Text="User Name :"></asp:Label></td>
                        <td class="formTable">
                            <asp:TextBox CssClass="formTbx" ID="TbxUserName" placeholder="Enter user name" Height="30px" name="TbxUserName" runat="server" EnableViewState="False"></asp:TextBox>
                        </td>
                    </tr>                   

                    <tr>
                        <td class="formTable">
                            <asp:Label ID="Label101" runat="server" Text="New Password :"></asp:Label>
                        </td>
                        <td class="formTable">
                            <asp:TextBox TextMode="Password" CssClass="formTbx" ID="TbxNewPass" Height="30px" name="TbxNewPass" runat="server"></asp:TextBox>
                        </td>
                    </tr>        

                    <tr>
                        <td class="formTable">
                            <asp:Label ID="Label10" runat="server" Text="New Password Again :"></asp:Label></td>
                        <td class="formTable">
                            <asp:TextBox TextMode="Password" CssClass="formTbx" ID="TbxNewPass2"  Height="30px" name="TbxNewPass2" runat="server"></asp:TextBox>
                        </td>
                    </tr>        

                    <tr>
                        <td class="formTable">&nbsp;</td>
                        <td class="formTable">
                            <asp:Button ID="BtnSaveEdit" runat="server" OnClientClick="return validatePasses();" Text="Save Changes" CssClass="btn btn-primary" Width="100%" OnClick="BtnSaveEdit_Click" /></td>

                    </tr>
                </table>
            </div>
        </div>
    </div>
    <script>

        function validatePasses() {
            var pwd1 = document.getElementById("TbxNewPass").innerHTML();
            var pwd2 = document.getElementById("TbxNewPass").innerHTML();
            if (pwd1 == pwd2) {
                return true;
            }
            else {
                alert("Password Does not match");
                return false;
            }
        }
    </script>
</asp:Content>
