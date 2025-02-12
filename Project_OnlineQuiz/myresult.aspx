﻿<%@ Page Title="" Language="C#" MasterPageFile="~/usermaster.Master" AutoEventWireup="true" CodeBehind="myresult.aspx.cs" Inherits="Project_OnlineQuiz.myresult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" runat="server">
    <div class="card-header">
        <h2>My Result</h2>
    </div>
    <asp:TextBox ID="getemail" runat="server" Visible ="false"></asp:TextBox>
    <asp:GridView ID="gridmyresult" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered" OnPageIndexChanging="gridmyresult_PageIndexChanging" PageSize="8" OnSelectedIndexChanged="gridmyresult_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="user_enroll" HeaderText="Student Enrollment" NullDisplayText="Student not found"/>
            <asp:BoundField DataField="exam_name" HeaderText="Exam Name" NullDisplayText="no exam name"/>
            
            <asp:BoundField DataField="exam_totalquestions" HeaderText="Total Question" />
            <asp:BoundField DataField="status" HeaderText="Result" />
            <asp:BoundField DataField="exam_marks" HeaderText="Total Marks" />
            <asp:BoundField DataField="score" HeaderText="Your Score" />
        </Columns>
    </asp:GridView>
        <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <asp:Panel ID="panel_myresultshow_warning" runat="server" Visible="false">
                    <br />
                    <div class="alert alert-danger text-center">
                        <asp:Label ID="lbl_myresultshowwarning" runat="server" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
