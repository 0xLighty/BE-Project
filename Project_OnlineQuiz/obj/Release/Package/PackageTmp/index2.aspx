<%@ Page Title="" Language="C#" MasterPageFile="~/usermaster.Master" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="Project_OnlineQuiz.index2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" runat="server">
    <h2 class="my-4">My Exams</h2>
    <hr />
    <!-- Category Section -->
    <div class="row">
        <asp:Repeater ID="gridview_categorylist" runat="server">
            <ItemTemplate>
                <div class="col-lg-3 mb-3">
                    <div class="card h-100 text-center">
                        <h4 class="card-header"><%# Eval("exam_name") %></h4><br />
                        <h6><%# Eval("exam_description") %></h6><br />
                        Date:<h6><%# Eval("exam_date") %></h6><br />                       
                        Duration:<h6><%# Eval("exam_duration") %></h6><br />                
                        Total Marks:<h6><%# Eval("exam_marks") %></h6><br />   
                        Negative Marks:<h6><%# Eval("exam_negativemarks") %></h6><br />
                        Total Questions:<h6><%# Eval("exam_totalquestions") %></h6><br />
                        Passing Marks:<h6><%# Eval("exam_pass") %></h6>
                        <div class="card-footer">
                            <asp:HyperLink ID="btn_category" runat="server" CssClass="btn btn-primary" ForeColor="White"    NavigateUrl='<%# "~/question.aspx?eid=" +  Eval("exam_id") %>'>Take Exam</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <asp:Panel ID="panel_categoryshow_warning" runat="server" Visible="false">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="lbl_categoryshowwarning" runat="server" />
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
