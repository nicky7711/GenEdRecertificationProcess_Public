<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCreateArea.aspx.cs" Inherits="CIS4396Solution.AdminCreateArea" %>

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
                            <h1>Manage Areas</h1>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <div class="pull-right">
                            <button type="button" class="btn btn-success" data-toggle="modal" data-target="#createModal">Create new area</button>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <asp:GridView ID="gvAreaControl" GridLines="None" AllowSorting="true" OnSorting="gvAreaControl_Sorting" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvAreaControl_OnPageIndexChaning" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="false" BackColor="White" OnRowCommand="gvAreaControl_OnRowCommand">
                            <Columns>
                                <asp:BoundField DataField="AreaCd" SortExpression="AreaCd" HeaderText="Area Code" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="30%" />
                                <asp:BoundField DataField="AreaNm" SortExpression="AreaNm" HeaderText="Area Name" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="50%" />
                                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" HeaderText="Edit" Text="Edit" CommandName="EditArea" ItemStyle-HorizontalAlign="Left" />
                                <asp:ButtonField ButtonType="Button" DataTextField="ActiveInd" ControlStyle-CssClass="btn btn-info" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" HeaderText="Activation" CommandName="ActivateArea" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                            <PagerStyle VerticalAlign="Bottom" CssClass="GridPager" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal for add -->
    <div class="modal fade" id="createModal" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: #a41e35; color: white;">
                    <button type="button" class="close" style="color:white; opacity:1;" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Create a New Area</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Label ID="lblAreaCode1" CssClass="control-label" Text="Area Code" runat="server"></asp:Label>
                                <asp:TextBox ID="txtAreaCode1" CssClass="form-control input-lg" Placeholder="" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Area Code is required*"
                                    ControlToValidate="txtAreaCode1" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Label ID="lblAreaName1" CssClass="control-label" Text="Area Name" runat="server"></asp:Label>
                                <asp:TextBox ID="txtAreaName1" CssClass="form-control input-lg" Placeholder="" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Area Name is required*"
                                    ControlToValidate="txtAreaName1" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAddArea" ValidationGroup="Popup" UseSubmitBehavior="false" CssClass="btn btn-lg btn-success" Text="Add" runat="server" OnClick="btnAddArea_Click" />
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
                        <h4 class="modal-title">Delete Area</h4>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure you want to delete this area?</p>
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
                    <button type="button" class="close" style="color:white; opacity:1;" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Edit Existing Area</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Label ID="lblAreaCode2" CssClass="control-label" Text="Area Code" runat="server"></asp:Label>
                                <asp:TextBox ID="txtAreaCode2" CssClass="form-control input-lg" Placeholder="" autofocus="true" required="true" runat="server" ReadOnly="true"></asp:TextBox>
                                <br />
                                <asp:Label ID="lblAreaName2" CssClass="control-label" Text="Area Name" runat="server"></asp:Label>
                                <asp:TextBox ID="txtAreaName2" CssClass="form-control input-lg" Placeholder="" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Area Name is required*"
                                    ControlToValidate="txtAreaName2" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup2"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSaveArea" ValidationGroup="Popup2" UseSubmitBehavior="false" CssClass="btn btn-lg btn-success" Text="Save" runat="server" OnClick="btnSaveArea_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
