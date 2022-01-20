﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="detailsexamquestion.aspx.cs" Inherits="Project_OnlineQuiz.Admin.detailsexamquestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <div class="col-md-12">
        <div class="card">
            <%--Button For edit--%>
            <div class="btn-group bg-danger">
                <asp:Button ID="btn_detailsexamquestion" runat="server" Text="Details Exam Question" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" BackColor="#343A40" />
            </div>
            <div class="card mb-3">
                <div class="card-body">
                    <%-- For showing the details --%>
                    <div class="table table-responsive">
                        <asp:DetailsView ID="gridview_examdetails" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateRows="False" OnPageIndexChanging="gridview_examdetails_PageIndexChanging">
                            <Fields>
                                
                                <asp:BoundField DataField="exam_description" HeaderText="Exam Discription" NullDisplayText="No Discription">
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:BoundField DataField="question_name" HeaderText="Question">
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "Handler1.ashx?id_Image="+ Eval("id") + "&str=myImg"%>' Height="100px" Width="100px" AlternateText="No Image" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="opt_one" HeaderText="Option One" NullDisplayText="Image">
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image2" runat="server" ImageUrl='<%# "Handler1.ashx?id_Image="+ Eval("id") + "&str=popt_one"%>' Height="100px" Width="100px" AlternateText="No Image" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="opt_two" HeaderText="Option Two" NullDisplayText="Image" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image3" runat="server" ImageUrl='<%# "Handler1.ashx?id_Image="+ Eval("id") + "&str=popt_two"%>' Height="100px" Width="100px" AlternateText="No Image" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="opt_three" HeaderText="Option three" NullDisplayText="Image" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image4" runat="server" ImageUrl='<%# "Handler1.ashx?id_Image="+ Eval("id") + "&str=popt_three"%>' Height="100px" Width="100px" AlternateText="No Image" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="opt_four" HeaderText="Option four" NullDisplayText="Image" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image5" runat="server" ImageUrl='<%# "Handler1.ashx?id_Image="+ Eval("id") + "&str=popt_four"%>' Height="100px" Width="100px" AlternateText="No Image" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="question_answer" HeaderText="Correct answer" NullDisplayText="Image" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="marks" HeaderText="Mark(s)" NullDisplayText="Image" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                    </asp:BoundField>
                            </Fields>
                            <FooterTemplate>
                                <asp:Button ID="btn_backquestion" runat="server" Text="Back TO Question" CssClass="btn btn-info" BackColor="#343A40" BorderStyle="None" ForeColor="White" PostBackUrl="~/admin/exam.aspx" />
                            </FooterTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:DetailsView>
                        <asp:Panel ID="panel_examdetails_warning" runat="server" Visible="false">
                            <div class="card-footer">
                                <br />
                                <div class="alert alert-danger text-center">
                                    <asp:Label ID="lbl_examdetailswarning" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
