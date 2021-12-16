<%@ Page Title="User Management" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="PES.Presentation.UserManagement" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr />
    <div class="row">

        
    <div class="row" style="width: 95%; margin-left: 2%;">
        <div class="col-lg-9">
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow><asp:TableCell>
<asp:TextBox ID="txtSearch" runat="server" CssClass="formTbx" />
                   </asp:TableCell> <asp:TableCell>
<asp:Button Text="Search" runat="server" CssClass="btn btn-primary" OnClick="Search" />
                 </asp:TableCell> </asp:TableRow>
            </asp:Table>
                </div>
        <div class="col-lg-1">
            <asp:Button Text="Get Employes with no Line Manager" runat="server" CssClass="btn btn-primary" OnClick="Search" />
            </div>
        </div>
<hr />

        <div class="col-lg-8" >
    <div class="col-lg-12" style="width:95%;margin-left:2%;">
           <asp:GridView Style="margin-top: 5px" ID="GridView1" runat="server" class="table table-bordered table-condensed table-responsive table-hover " AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1_EmployeList" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" Font-Size="14px" AllowSorting="True" AllowPaging="True" PageSize="20">
                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" InsertVisible="False" SortExpression="Id"></asp:BoundField>
                    <asp:BoundField DataField="EName" HeaderText="Name" SortExpression="EName"></asp:BoundField>
                    <asp:BoundField DataField="ELName" HeaderText="Last Name" SortExpression="ELName"></asp:BoundField>

                    <asp:BoundField DataField="ENameAM" HeaderText="ስም" SortExpression="ENameAM"></asp:BoundField>
                    <asp:BoundField DataField="ELNameAM" HeaderText="የአባት ስም" SortExpression="ELNameAM"></asp:BoundField>
                    <asp:BoundField DataField="CompanyId" HeaderText="Company Id" SortExpression="CompanyId"></asp:BoundField>
                    <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57"></EditRowStyle>

                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle BackColor="#C3CDDB" Font-Bold="True" ForeColor="Black"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#E3EAEB"></RowStyle>

                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
            </asp:GridView>
        </div>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1_EmployeList" ConnectionString='<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>' SelectCommand="SELECT [Id], [EName], [ELName], [CompanyId], [ENameAM], [ELNameAM] FROM [Employees]"></asp:SqlDataSource>
        </div>
        <div class="col-lg-4">
            <table style="border: thin dotted #00FFFF; margin-bottom: 15px; margin-top: 5px; width: 95%; margin-left: 2%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
                <tr>
                    <td class="formTable">
                        <h5 style="color: #cc7a00;" runat="server">First Name</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="TbxFirstNameEN" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td class="formTable">
                        <h5 style="color: #cc7a00;" runat="server">Last Name</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="TbxLastNameEN" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formTable">
                        <h5 style="color: #cc7a00;" runat="server">ስም</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="TbxFirstNameAM" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                    </td>
                </tr>
               
                <tr>
                    <td class="formTable">
                        <h5 style="color: #cc7a00;" runat="server">የአባት ስም</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="TbxLastNameAM" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formTable">
                        <h5 style="color: #cc7a00;" runat="server">Company ID</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="TbxCompanyID" runat="server" CssClass="form-control formTbx" Style=""></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="formTable">
                        <h5 style="color: #cc7a00;" runat="server">User Role</h5>
                        <td class="formTable">
                            <asp:DropDownList ID="DDLUSerRole" runat="server" BackColor="#C3CDDB" Style="color: #cc7a00;"
                                CssClass="_Telerik_Opera11" Height="30px" Width="100%"
                                Font-Names="Book Antiqua" DataSourceID="SqlDataSource1_UserRole" DataTextField="RoleName" DataValueField="Id">
                            </asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource1_UserRole" ConnectionString='<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>' SelectCommand="SELECT [Id], [RoleName] FROM [LKUsersRoles]"></asp:SqlDataSource>
                        </td>
                </tr>

                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>

                <tr>
                    <td class="formTable">
                        <h5 style="color: #cc7a00;" runat="server">Line Manager</h5>
                        <td class="formTable">
                            <asp:DropDownList ID="DDLLineMgr" runat="server" BackColor="#C3CDDB" Style="color: #cc7a00;"
                                CssClass="_Telerik_Opera11" Height="30px" Width="100%"
                                Font-Names="Book Antiqua" DataSourceID="SqlDataSource1" DataTextField="FullENName" DataValueField="Id">
                            </asp:DropDownList>                            
                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>' SelectCommand="SELECT [FullENName], [Id], [ELFullNameEN] FROM [View_EmployessList]"></asp:SqlDataSource>
                        </td>
                </tr>

                <tr>
                    <td class="formTable">
                        <asp:LinkButton ID="BtnREgister" runat="server" Style="width: 98%; margin: 5px;" CssClass="btn" OnClientClick="successfullysaved()" Text="Register/Update" OnClick="BtnREgister_Click" BorderColor="#00FFFF" BorderStyle="Dotted"><span class="glyphicon glyphicon-ok"></span> Register/Update</asp:LinkButton>
                    </td>
                    <td class="formTable">
                        <asp:LinkButton ID="BtnDelete" runat="server" Style="width: 98%; margin: 5px;" CssClass="btn" Text="Delete" OnClientClick="successfullysaved()" OnClick="BtnDelete_Click" BorderColor="#00FFFF" BorderStyle="Dotted"><span class="glyphicon glyphicon-ok"></span> Delete</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="BtnResetUserNameAndPassword" runat="server" Style="width: 98%; margin: 5px;" CssClass="btn" Text="Delete" OnClientClick="successfullysaved()" OnClick="BtnResetUserNameAndPassword_Click" BorderColor="#00FFFF" BorderStyle="Dotted"><span class="glyphicon glyphicon-ok"></span> Reset UserName and Password</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>

     <script>
         function successfullysaved() {
             alert("Data Successfully Saved");
         }

         $(document).ready(function () {
             $('#_Table1').dataTable();
         });
     </script>  


</asp:Content>
