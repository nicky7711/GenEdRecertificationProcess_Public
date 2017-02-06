<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="CIS4396Solution.AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="http://localhost:50189/cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/build/css/bootstrap-datetimepicker.css" rel="stylesheet">
    <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
    <script src="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/src/js/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript">
        function openEditModal() {
            $('#editModal').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="col-xs-12 col-md-10 col-md-offset-1">
            <div class="card">
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2 text-center">
                        <div class="page-header">
                            <h1>Administrative Dashboard</h1>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 text-center">
                        <div class="page-heading">
                            <h2>Filter</h2>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1">
                        <div class="form-horizontal">
                            <div class="col-md-3">
                                <asp:Label ID="lblAcademicYear" Text="Academic Year" runat="server"></asp:Label>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlAcademicYear">
                                    <asp:ListItem Value="2015-2016">2016-2017</asp:ListItem>
                                    <asp:ListItem Value="2015-2016">2015-2016</asp:ListItem>
                                    <asp:ListItem Value="2014-2015">2014-2015</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblCourseTitle" CssClass="page-heading" Text="Course Title" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtTitleSearch" runat="server" placeholder="Course Title"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblCourseNumberTitle" Text="Course Number" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtNumberSearch" runat="server" placeholder="Course Number"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblCourseArea" Text="Course Area" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtCourseArea" runat="server" placeholder="Course Area"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-md-2" style="padding-top:20px;">
                                <asp:Button CssClass="btn btn-primary" runat="server" ID="btnFilter" Text="Filter" Width="100%" OnClick="btnFilter_Click" />
                            </div>
                            <%--<div class="col-xs-12 col-md-2">
                                <asp:Button CssClass="btn btn-danger" runat="server" ID="btnClear" Text="Clear" Width="100%" OnClick="btnClear_Click" />
                            </div>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-8 col-xs-offset-2">
                            <div class="page-header"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-10 col-xs-offset-1 text-center">
                            <div class="page-heading">
                                <h2>Packages</h2>
                                <br />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-10 col-xs-offset-1">
                            <div class="pull-left">
                                <asp:Button CssClass="btn btn-success" runat="server" ID="btnCreatePackage" Text="Create Course Package" OnClick="btnCreatePackage_Click" />
                                <br />
                                <br />
                            </div>
                            <asp:GridView ID="gvPackages" CssClass="table table-responsive table-hover" AllowSorting="true" OnSorting="gvPackages_Sorting" GridLines="None" AllowPaging="true"
                                PageSize="10" BackColor="White" runat="server" AutoGenerateColumns="False" DataKeyNames="PackageId,CourseId" OnRowCommand="gvPackages_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="PackageId" Visible="false" />
                                    <asp:BoundField DataField="CourseId" Visible="false" />
                                    <asp:BoundField DataField="CourseTitle" HeaderText="Course Name" SortExpression="CourseTitle" ItemStyle-Wrap="true" ItemStyle-Width="35%"></asp:BoundField>
                                    <asp:BoundField DataField="CourseNum" HeaderText="Course Number" SortExpression="CourseNum" ItemStyle-Wrap="true" ItemStyle-Width="20%"></asp:BoundField>
                                    <asp:BoundField DataField="AreaCd" HeaderText="Course Area" SortExpression="AreaCd" ItemStyle-Wrap="true" ItemStyle-Width="20%"></asp:BoundField>
                                    <asp:BoundField DataField="Deadline" HeaderText="Due Date" SortExpression="Deadline" ItemStyle-Width="30%"></asp:BoundField>
                                    <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-info" HeaderText="View" 
                                        Text="View" CommandName="ViewPackage" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                    <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-warning" HeaderText="Edit" 
                                        Text="Edit" CommandName="EditPackage" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="#e6e6e6" ForeColor="Black" />
                                <PagerStyle VerticalAlign="Bottom" CssClass="GridPager" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" />
                                <SelectedRowStyle BackColor="#000099" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal for edit -->
    <div class="modal fade" id="editModal" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: #a41e35; color: white;">
                    <button type="button" class="close" style="color:white; opacity:1;" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Edit existing package</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Label ID="lblCourseName" CssClass="control-label" Text="Course Name" runat="server"></asp:Label>
                                <asp:TextBox ID="txtCourseName" CssClass="form-control input-lg" ReadOnly="true" runat="server"></asp:TextBox>
                                <br />
                                <asp:Label ID="lblCourseNumber" CssClass="control-label" Text="Course Number" runat="server"></asp:Label>
                                <asp:TextBox ID="txtCourseNumber" CssClass="form-control input-lg" ReadOnly="true" runat="server"></asp:TextBox>
                                <br />
                                <asp:Label ID="lblSubmissionDeadline" CssClass="control-label" Text="Submission Deadline" runat="server"></asp:Label>
                                <div class="form-group">
                                    <div class='input-group date' id='datetimepicker1' style="width: 100%">
                                        <asp:TextBox ID="txtDeadline" CssClass="form-control input-lg" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="required*"
                                            ControlToValidate="txtDeadline" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                                <script type="text/javascript">
                                    $(function () {
                                        $('#datetimepicker1').datetimepicker();
                                    });
                                </script>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSave" UseSubmitBehavior="false" CssClass="btn btn-lg btn-success" Text="Save" runat="server" ValidationGroup="Popup" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
