<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCompletedReviews.aspx.cs" Inherits="CIS4396Solution.AdminCompletedReviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-10 col-md-offset-1">
        <div class="card">
            <div class="col-xs-10 col-xs-offset-1">
                <div class="page-header">
                    <h1>Completed Portfolios</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <label class="control-label">Reviews</label>
                    <div class="col-md-8 col-md-offset-2">
                        <asp:GridView ID="gvQuestionnaire" GridLines="None" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="gvQuestionnaire_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="QuestionnaireId" Visible="false" />
                                <asp:BoundField DataField="UserId" HeaderText="User" HeaderStyle-CssClass="text-center" ItemStyle-Width="30%"></asp:BoundField>
                                <asp:BoundField DataField="PortfolioId" HeaderText="Item Type" HeaderStyle-CssClass="text-center" ItemStyle-Width="35%"></asp:BoundField>
                                <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" HeaderText="View" HeaderStyle-CssClass="text-center" Text="<i aria-hidden='true' class='glyphicon glyphicon-zoom'></i>" CommandName="ViewQuestionnaire" ItemStyle-HorizontalAlign="Center">
                                    <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                            <FooterStyle BackColor="#202723" />
                            <HeaderStyle BackColor="#e6e6e6" ForeColor="Black" />
                            <PagerStyle BackColor="#202723" ForeColor="#202723" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                    </div>
                    <!-- Modal - No Comments-->
                    <div class="modal fade" id="cmtNAModal" role="dialog">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Reviewer Comments</h4>
                                </div>
                                <div class="modal-body">
                                    <p>No comments were submitted.</p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Modal 1 -->
                    <div class="modal fade" id="cmtModal" role="dialog">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Reviewer Comments</h4>
                                </div>
                                <div class="modal-body">
                                    <p>Mary Conran - This course meets fulfillments for the program goals, but some departments do not meet what is needed for the area goals.</p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Modal 2 -->
                    <div class="modal fade" id="cmtModal2" role="dialog">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Reviewer Comments</h4>
                                </div>
                                <div class="modal-body">
                                    <p>Michael Hesson - This course has gone off track for what is required for the area goals.</p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
