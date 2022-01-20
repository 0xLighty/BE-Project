<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jstTry.aspx.cs" Inherits="Project_OnlineQuiz.Admin.jstTry" %>


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
                <asp:Panel ID="panel_index_warning" runat="server" Visible="false">
                    <div class="card-footer">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="lbl_indexwarning" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    </div>
    </form>
</body>
</html>
