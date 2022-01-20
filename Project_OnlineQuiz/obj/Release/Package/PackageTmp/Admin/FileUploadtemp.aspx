<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUploadtemp.aspx.cs" Inherits="Project_OnlineQuiz.Admin.FileUploadtemp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Select the file:
        <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
    </form>
    <p>
        <input id="Button1" type="button" value="Upload" onclick="upload_Click" /></p>
    <asp:Label ID="Label1" runat="server" />
</body>
</html>
