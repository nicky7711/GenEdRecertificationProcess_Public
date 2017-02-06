<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCreateCoursePackage.aspx.cs" Inherits="CIS4396Solution.AdminCreateCoursePackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/build/css/bootstrap-datetimepicker.css" rel="stylesheet">
    <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
    <script src="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/src/js/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript">
        function openCommentModal() {
            $('#commentModal').modal('show');
        }
        function closeCommentModal() {
            $('#commentModal').modal('hide');
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
                            <h1>Create a Course Package</h1>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2">
                        <div class="form-horizontal">
                            <div class="col-xs-12 col-md-6">
                                <asp:Label ID="lblSubmissionDeadline" CssClass="control-label" Text="Submission Deadline" runat="server"></asp:Label>
                                <div class="form-group">
                                    <div class='input-group date' id='datetimepicker1' style="width: 100%">
                                        <asp:TextBox ID="txtDeadline" CssClass="form-control input-lg" required="required" runat="server"></asp:TextBox>
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
                            <div class="col-xs-12 col-md-6">
                                <asp:Label ID="Label1" CssClass="control-label" Text="Academic Year" runat="server"></asp:Label>
                                <asp:DropDownList ID="ddlAcademicYear" CssClass="form-control input-lg" Width="100%" required="true" runat="server">
                                </asp:DropDownList>
                                <div class="help-block with-errors"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2">
                        <div class="form-horizontal">
                            <div class="col-xs-12 col-md-6">
                                <asp:Label ID="lblCourse" CssClass="control-label" Text="Course" runat="server"></asp:Label>
                                <asp:DropDownList ID="ddlCourses" CssClass="form-control input-lg" required="true" runat="server">
                                </asp:DropDownList>
                                <div class="help-block with-errors"></div>
                            </div>
                            <div class="col-xs-12 col-md-6">
                                <asp:Label ID="lblCourseCoordinator" CssClass="control-label" Text="Course Coordinator" runat="server"></asp:Label>
                                <asp:DropDownList ID="ddlCoordinator" CssClass="form-control input-lg" required="true" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2">
                        <div class="form-horizontal">
                            <div class="col-md-6">
                                <asp:Label ID="lblProbation" CssClass="control-label" Text="Probation" runat="server"></asp:Label>
                                <asp:CheckBox ID="chkProbation" CssClass="" runat="server" />
                            </div>
                            <div class="col-xs-12 col-md-6">
                                <div class="pull-right">
                                    <asp:Button ID="btnCreateCoursePackage" Text="Create" CssClass="btn btn-success btn-lg" Width="100%" OnClick="btnCreateCoursePackage_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
            </div>
        </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="commentModal" role="dialog" style="text-align: center">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <h2>Do you want to add another Department/Portfolio to this Course Package?</h2>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnYes" UseSubmitBehavior="false" CssClass="btn btn-lg btn-success" Text="Yes" runat="server" OnClick="btnYes_Click" />
                    <asp:Button ID="btnNo" UseSubmitBehavior="false" CssClass="btn btn-lg btn-danger" Text="No" runat="server" OnClick="btnNo_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
