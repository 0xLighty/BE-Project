<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project_OnlineQuiz.Admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <div class="col-12">
    <h1>Dashboard</h1>
    <hr />
    </div>
    
    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <asp:Panel ID="panel1" runat="server" Visible="false">
                    <div class="card-footer">
                        <br />
                        <div class="alert alert-danger text-center" style="color: black; background-color: white">
                            <asp:Label ID="Label1" runat="server" />
                            <asp:Label ID="Label2" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="panel_index_warning" runat="server" Visible="false">
                    <div class="card-footer">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="lbl_indexwarning" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
                <div class="text-center">
                            <asp:Label ID="Label3" runat="server" /><asp:Label ID="Label4" runat="server" />
                        </div>

            </div>
        </div>
    </div>
</asp:Content>
