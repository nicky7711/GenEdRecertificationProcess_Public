<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCreateDepartment.aspx.cs" Inherits="CIS4396.AdminCreateDepartment" %>

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
    <style type="text/css">
        .hidden {
            display: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="col-xs-12 col-md-10 col-md-offset-1">
            <div class="card">
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2">
                        <div class="page-header">
                            <h1>Manage Departments</h1>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <div class="pull-right">
                            <button type="button" class="btn btn-success" data-toggle="modal" data-target="#createModal">Create new department</button>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <asp:GridView ID="gvDepartmentControl" GridLines="None" AllowSorting="true" OnSorting="gvDepartmentControl_Sorting" AllowPaging="true" PageSize="10"
                            OnPageIndexChanging="gvDepartmentControl_OnPageIndexChaning" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="false"
                            BackColor="White" OnRowCommand="gvDepartmentControl_OnRowCommand">
                            <Columns>
                                <asp:BoundField DataField="CollegeId" HeaderText="College ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                <asp:BoundField DataField="CollegeCd" SortExpression="CollegeCd" HeaderText="College Code" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="20%" />
                                <asp:BoundField DataField="DeptNm" SortExpression="DeptNm" HeaderText="Department Name" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="20%" />
                                <asp:BoundField DataField="SubjectCd" SortExpression="SubjectCd" HeaderText="Subject Code" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" />
                                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" HeaderText="EditDept" Text="Edit" CommandName="EditDepartment" ItemStyle-HorizontalAlign="Left" />
                                <%--<asp:TemplateField HeaderText="Activation" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" >
                                <ItemTemplate>
                                    <asp:Button ID="btnActivation" runat="server" Text="Activation" CssClass="btn btn-default" />
                                </ItemTemplate>--%>
                                <%--</asp:TemplateField>--%>
                                <asp:ButtonField ButtonType="Button" DataTextField="ActiveInd" ControlStyle-CssClass="btn btn-info" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" HeaderText="Activation" CommandName="ActivateDepartment" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                            <PagerStyle VerticalAlign="Bottom" CssClass="GridPager" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal for add department -->
    <div class="modal fade" id="createModal" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: #a41e35; color: white;">
                    <button type="button" class="close" style="color:white; opacity:1;" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Create a New Department</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Label ID="lblCollegeCode1" CssClass="control-label" Text="College Code" runat="server"></asp:Label>
                                <asp:TextBox ID="txtCollegeCode1" CssClass="form-control input-lg" Placeholder="" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="required*"
                                    ControlToValidate="txtCollegeCode1" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Label ID="lblDepartmentName1" CssClass="control-label" Text="Department Name" runat="server"></asp:Label>
                                <asp:TextBox ID="txtDepartmentName1" CssClass="form-control input-lg" Placeholder="" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="required*"
                                    ControlToValidate="txtDepartmentName1" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Label ID="lblSubjectCode1" CssClass="control-label" Text="Subject Code" runat="server"></asp:Label>
                                <asp:TextBox ID="txtSubjectCode1" CssClass="form-control input-lg" Placeholder="" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="required*"
                                    ControlToValidate="txtSubjectCode1" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAddDepartment" ValidationGroup="Popup" UseSubmitBehavior="false" CssClass="btn btn-lg btn-success" Text="Add" runat="server" OnClick="btnAddDepartment_Click" />
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
                            <h4 class="modal-title">Delete Department</h4>
                        </div>
                        <div class="modal-body">
                            <p>Are you sure you want to delete this department?</p>
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
                    <h4 class="modal-title">Edit Existing Department</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Label ID="lblCollegeCode2" CssClass="control-label" Text="College Code" runat="server"></asp:Label>
                                <asp:TextBox ID="txtCollegeCode2" CssClass="form-control input-lg" Placeholder="" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="required*"
                                    ControlToValidate="txtCollegeCode2" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup2"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Label ID="lblDepartmentName2" CssClass="control-label" Text="Department Name" runat="server"></asp:Label>
                                <asp:TextBox ID="txtDepartmentName2" CssClass="form-control input-lg" Placeholder="" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="required*"
                                    ControlToValidate="txtDepartmentName2" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup2"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Label ID="lblSubjectCode2" CssClass="control-label" Text="Subject Code" runat="server"></asp:Label>
                                <asp:TextBox ID="txtSubjectCode2" CssClass="form-control input-lg" Placeholder="" autofocus="true" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="required*"
                                    ControlToValidate="txtSubjectCode2" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup2"></asp:RequiredFieldValidator>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSaveDepartment" ValidationGroup="Popup2" UseSubmitBehavior="false" CssClass="btn btn-lg btn-success" Text="Save" runat="server" OnClick="btnSaveDepartment_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
