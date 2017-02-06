<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCreateUser.aspx.cs" Inherits="CIS4396Solution.AdminCreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function openEditModal() {
            $('#editModal').modal('show');
        }
        function openCreateModal() {
            $('#createModal').modal('show');
        }
        function openCheckModal() {
            $('#checkModal').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="col-xs-12 col-md-10 col-md-offset-1">
            <div class="card">
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2">
                        <div class="page-header">
                            <h1>Manage Users</h1>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <div class="pull-right">
                            <button type="button" class="btn btn-success" data-toggle="modal" data-target="#createModal">Create new user</button>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <asp:GridView ID="gvUserControl" GridLines="None" AllowSorting="true" OnSorting="gvUserControl_Sorting" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvUserControl_OnPageIndexChaning" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="false" BackColor="White" OnRowCommand="gvUserControl_OnRowCommand">
                            <Columns>
                                <asp:BoundField DataField="AccessNetID" SortExpression="AccessNetId" HeaderText="AccessNetID" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="25%" />
                                <asp:BoundField DataField="Role" SortExpression="Role" HeaderText="Role" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="25%" />
                                <asp:BoundField DataField="dFullNm" SortExpression="dFullNm" HeaderText="Full Name" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="25%" />
                                <asp:BoundField DataField="dEmail" SortExpression="dEmail" HeaderText="Email" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="25%" />
                                <%--<asp:BoundField DataField="ActiveInd" HeaderText="Activation Status" />--%>
                                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" HeaderText="Edit" Text="Edit" CommandName="EditUser" ItemStyle-HorizontalAlign="Center" />
                                <asp:ButtonField ButtonType="Button" DataTextField="ActiveInd" ControlStyle-CssClass="btn btn-info" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" HeaderText="Activation" CommandName="ActivateUser" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                            <PagerStyle VerticalAlign="Bottom" CssClass="GridPager" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal for add user -->
    <div class="modal fade" id="createModal" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: #a41e35; color: white;">
                    <button type="button" class="close" style="color: white; opacity: 1;" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Create a New User</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Label ID="lblAccessNetIDForCreate" CssClass="control-label" Text="AccessNet ID" runat="server"></asp:Label>
                                <asp:TextBox ID="txtAccessNetIDForCreate" CssClass="form-control input-lg" Placeholder="tua12345" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Validator" runat="server" ErrorMessage="Access Net ID is required*"
                                    ControlToValidate="txtAccessNetIDForCreate" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>

                                <br />
                                <asp:Label ID="lblRoleForCreate" CssClass="control-label" Text="Role" runat="server"></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlRoleForCreate" CssClass="form-control input-lg" autofocus="true" required="true" runat="server">
                                    <asp:ListItem Value="1">Administrator</asp:ListItem>
                                    <asp:ListItem Value="2">GEEC</asp:ListItem>
                                    <asp:ListItem Value="3">GAC</asp:ListItem>
                                    <asp:ListItem Value="4">Department Contact</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:Label ID="lblFullNameForCreate" CssClass="control-label" Text="Full Name" runat="server"></asp:Label>
                                <asp:TextBox ID="txtFullNameForCreate" CssClass="form-control input-lg" Placeholder="John Doe" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Full Name is required*"
                                    ControlToValidate="txtFullNameForCreate" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>

                                <br />
                                <asp:Label ID="lblEmailForCreate" CssClass="control-label" Text="Email" runat="server"></asp:Label>
                                <asp:TextBox ID="txtEmailForCreate" CssClass="form-control input-lg" Placeholder="tua12345@temple.edu" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email is required*"
                                    ControlToValidate="txtEmailForCreate" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>

                                <br />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCreateUser" UseSubmitBehavior="false" ValidationGroup="Popup" CssClass="btn btn-lg btn-success" Text="Create" runat="server" OnClick="btnCreateUser_Click" />
                </div>
            </div>
        </div>
    </div>
    <%--<!-- Modal for delete -->
            <div class="modal fade" id="checkModal" role="dialog">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Delete User</h4>
                        </div>
                        <div class="modal-body">
                            <p>Are you sure you want to delete this user?</p>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnDelete" UseSubmitBehavior="false" CssClass="btn btn-lg btn-danger" Text="Delete" runat="server" OnClick="btnDelete_Click" />
                        </div>
                    </div>
                </div>
            </div>--%>
    <!-- Modal for edit -->
    <div class="modal fade" id="editModal" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: #a41e35; color: white;">
                    <button type="button" class="close" style="color: white; opacity: 1;" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Edit existing user</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Label ID="lblAccessNetID" CssClass="control-label" Text="AccessNet ID" runat="server"></asp:Label>
                                <asp:TextBox ID="txtAccessNetID" CssClass="form-control input-lg" Placeholder="tua12345" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <br />
                                <asp:Label ID="lblRole" CssClass="control-label" Text="Role" runat="server"></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlRole" CssClass="form-control input-lg" autofocus="true" required="true" runat="server">
                                    <asp:ListItem Value="1">Administrator</asp:ListItem>
                                    <asp:ListItem Value="2">GEEC</asp:ListItem>
                                    <asp:ListItem Value="3">GAC</asp:ListItem>
                                    <asp:ListItem Value="4">Department Contact</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:Label ID="lblFullName" CssClass="control-label" Text="Full Name" runat="server"></asp:Label>
                                <asp:TextBox ID="txtFullName" CssClass="form-control input-lg" Placeholder="John Doe" autofocus="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Full Name is required*"
                                    ControlToValidate="txtFullName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup2"></asp:RequiredFieldValidator>

                                <br />
                                <asp:Label ID="lblEmail" CssClass="control-label" Text="Email" runat="server"></asp:Label>
                                <asp:TextBox ID="txtEmail" CssClass="form-control input-lg" Placeholder="tua12345@temple.edu" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email is required*"
                                    ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup2"></asp:RequiredFieldValidator>

                                <br />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSaveUser" ValidationGroup="Popup2" UseSubmitBehavior="false" CssClass="btn btn-lg btn-success" Text="Save" runat="server" OnClick="btnSaveUser_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>