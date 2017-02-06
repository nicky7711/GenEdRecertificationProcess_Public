<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCreatePortfolioDocument.aspx.cs" Inherits="CIS4396Solution.AdminCreatePortfolioDocument" %>

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
                            <h1>Manage Documents</h1>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <div class="pull-right">
                            <button type="button" class="btn btn-success" data-toggle="modal" data-target="#createModal">Create new document type</button>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <asp:GridView ID="gvControl" GridLines="None" AllowSorting="true" OnSorting="gvControl_Sorting" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvControl_OnPageIndexChaning" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="false" BackColor="White" OnRowCommand="gvControl_OnRowCommand">
                            <Columns>
                                <asp:BoundField DataField="DocumentTypeId" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                <asp:BoundField DataField="DocumentName" SortExpression="DocumentName" HeaderText="Document Type Name" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="70%" />
                                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" HeaderText="Edit" Text="Edit" CommandName="EditDocsType" />
                                <asp:ButtonField ButtonType="Button" DataTextField="ActiveInd" ControlStyle-CssClass="btn btn-info" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" HeaderText="Activation" CommandName="ActivateDocsType" ItemStyle-HorizontalAlign="Left" />
                                <%--<asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-warning" HeaderText="ActivationTrigger" ItemStyle-HorizontalAlign="Center" />--%>
                            </Columns>
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
                    <h4 class="modal-title">Create a New Doc Type</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Label ID="lblDocumentNameForCreate" CssClass="control-label" Text="Document Type" runat="server"></asp:Label>
                                <asp:TextBox ID="txtDocumentNameForCreate" CssClass="form-control input-lg" Placeholder="" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="VendorNameValidator" runat="server" ErrorMessage="Document Type is required*"
                                    ControlToValidate="txtDocumentNameForCreate" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAdd" UseSubmitBehavior="false" ValidationGroup="Popup" CssClass="btn btn-lg btn-success" Text="Create" runat="server" OnClick="btnAdd_Click" />
                </div>
            </div>
        </div>
    </div>
    <%-- <!-- Modal for delete -->
            <div class="modal fade" id="checkModal" role="dialog">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Delete Doc Type</h4>
                        </div>
                        <div class="modal-body">
                            <p>Are you sure you want to delete this type of document?</p>
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
                    <h4 class="modal-title">Edit existing document</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Label ID="lblDocumentName" CssClass="control-label" Text="Document Type" runat="server"></asp:Label>
                                <asp:TextBox ID="txtDocumentName" CssClass="form-control input-lg" Placeholder="" autofocus="true" required="require" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Document Type is required*"
                                    ControlToValidate="txtDocumentName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup2"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSave" UseSubmitBehavior="false" ValidationGroup="Popup2" CssClass="btn btn-lg btn-success" Text="Save" runat="server" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
