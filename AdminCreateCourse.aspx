<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCreateCourse.aspx.cs" Inherits="CIS4396Solution.AdminCreateCourse" %>

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
                            <h1>Manage Courses</h1>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <div class="pull-right">
                            <button type="button" class="btn btn-success" data-toggle="modal" data-target="#createModal">Create new course</button>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1">
                        <asp:GridView ID="gvCourseControl" GridLines="None" AllowSorting="true" OnSorting="gvCourseControl_Sorting" AllowPaging="true" PageSize="10"
                            OnPageIndexChanging="gvCourseControl_OnPageIndexChanging" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="false"
                            BackColor="White" OnRowCommand="gvCourseControl_OnRowCommand">
                            <Columns>
                                <asp:BoundField DataField="CourseId" HeaderText="Course ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" SortExpression="CourseTitle" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="30%" />
                                <asp:BoundField DataField="CourseNum" HeaderText="Course Number" SortExpression="CourseNum" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="15%" />
                                <asp:BoundField DataField="SubjectCd" HeaderText="Subject Code" SortExpression="SubjectCd" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="15%" />
                                <asp:BoundField DataField="CourseSubjectNum" HeaderText="Course Subject Number" SortExpression="CourseSubjectNum" Visible="false" ItemStyle-Wrap="true" ItemStyle-Width="15%" />
                                <asp:BoundField DataField="AreaCd" HeaderText="Area Code" SortExpression="AreaCd" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ItemStyle-Wrap="true" ItemStyle-Width="15%" />
                                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" HeaderText="Edit" Text="Edit" CommandName="EditCourse" ItemStyle-HorizontalAlign="Left" />
                                <asp:ButtonField ButtonType="Button" DataTextField="ActiveInd" ControlStyle-CssClass="btn btn-info" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" HeaderText="Activation" CommandName="ActivateCourse" ItemStyle-HorizontalAlign="Left" />
                                <%--<asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" HeaderText="Delete" Text="Delete" CommandName="DeleteCourse" ItemStyle-HorizontalAlign="Left" />--%>
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
                    <button type="button" class="close" style="color: white; opacity: 1;" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Create a Course</h4>
                </div>
                <div class="modal-body">
                    <asp:ScriptManager ID="ScriptManager1"
                               runat="server" />
                    <asp:UpdatePanel ID="upCreateModal" runat="server" OnLoad="upCreateModal_Load">
                        <ContentTemplate>
                            <asp:Label ID="lblMessage" CssClass="text-primary" runat="server" Text=""></asp:Label>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12">
                                        <asp:Label ID="lblColleges" CssClass="control-label" Text="College" runat="server"></asp:Label>
                                        <asp:DropDownList ID="ddlColleges" CssClass="form-control input-lg" autofocus="true" required="true"
                                            runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlColleges_SelectedIndexChanged">
                                            <asp:ListItem Value="">Choose a college</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-4">
                                        <asp:Label ID="lblCourseTitle" CssClass="control-label" Text="Course Title" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtCourseTitle" CssClass="form-control input-lg" Placeholder="Course Title" required="true" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="required*"
                                            ControlToValidate="txtCourseTitle" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label ID="lblCourseNumber" CssClass="control-label" Text="Course Number" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtCourseNumber" CssClass="form-control input-lg" Placeholder="Course Number" required="true" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="required*"
                                            ControlToValidate="txtCourseNumber" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label ID="lblCourseArea" CssClass="control-label" Text="Course Area" runat="server"></asp:Label>
                                        <asp:DropDownList ID="ddlCourseArea" CssClass="form-control input-lg" required="true" runat="server">
                                            <asp:ListItem Value="">Choose course area</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-6">
                                        <asp:Label ID="lblDepartment" CssClass="control-label" Text="Department" runat="server"></asp:Label>
                                        <asp:DropDownList ID="ddlDepartment" CssClass="form-control input-lg" autofocus="true" required="true" runat="server">
                                            <asp:ListItem Value="">Choose a department</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Label ID="lblSubjectCode" CssClass="control-label" Text="Subject Code" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtSubjectCode" CssClass="form-control input-lg" Placeholder="Subject Code" required="true" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="required*"
                                            ControlToValidate="txtSubjectCode" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCreateCourse" ValidationGroup="Popup" UseSubmitBehavior="false" CssClass="btn btn-lg btn-success" Text="Add" runat="server" OnClick="btnCreateCourse_Click" />
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
                            <h4 class="modal-title">Delete Course</h4>
                        </div>
                        <div class="modal-body">
                            <p>Are you sure you want to delete this course?</p>
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
                    <h4 class="modal-title">Edit a Course</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="upEditModal" runat="server" OnLoad="upEditModal_Load">
                        <ContentTemplate>
                            <asp:Label ID="Label1" CssClass="text-primary" runat="server" Text=""></asp:Label>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12">
                                        <asp:Label ID="Label2" CssClass="control-label" Text="College" runat="server"></asp:Label>
                                        <asp:DropDownList ID="ddlColleges2" CssClass="form-control input-lg" autofocus="true" AutoPostBack="true"
                                             required="true" runat="server" OnSelectedIndexChanged="ddlColleges2_SelectedIndexChanged">
                                            <asp:ListItem Value="">Choose a college</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-4">
                                        <asp:Label ID="Label3" CssClass="control-label" Text="Course Title" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtCourseTitle2" CssClass="form-control input-lg" Placeholder="Course Title" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="required*"
                                            ControlToValidate="txtCourseTitle2" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup2"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label ID="Label4" CssClass="control-label" Text="Course Number" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtCourseNumber2" CssClass="form-control input-lg" Placeholder="Course Number" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="required*"
                                            ControlToValidate="txtCourseNumber2" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup2"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label ID="Label5" CssClass="control-label" Text="Course Area" runat="server"></asp:Label>
                                        <asp:DropDownList ID="ddlCourseArea2" CssClass="form-control input-lg" runat="server">
                                            <asp:ListItem Value="">Choose course area</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-6">
                                        <asp:Label ID="Label6" CssClass="control-label" Text="Department" runat="server"></asp:Label>
                                        <asp:DropDownList ID="ddlDepartment2" CssClass="form-control input-lg" autofocus="true" required="true" runat="server">
                                            <asp:ListItem Value="">Choose a department</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Label ID="Label7" CssClass="control-label" Text="Subject Code" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtSubjectCode2" CssClass="form-control input-lg" Placeholder="Subject Code" required="true" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="required*"
                                            ControlToValidate="txtSubjectCode2" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Popup2"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnEditCourse" ValidationGroup="Popup2" UseSubmitBehavior="false" CssClass="btn btn-lg btn-success" Text="Save" runat="server" OnClick="btnEditCourse_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>