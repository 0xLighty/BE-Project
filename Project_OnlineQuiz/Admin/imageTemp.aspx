<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imageTemp.aspx.cs" Inherits="Project_OnlineQuiz.Admin.imageTemp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" 
    style="background-repeat: no-repeat;">
<div>
<h4 style="color: #800000"> This Application is Created by vithal wadje for C# Corner</h4>
<table>
<tr>
<td>
&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Name:&nbsp<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Select Image:&nbsp<asp:FileUpload ID="FileUpload1" runat="server" />
</td>
</tr>
</table>
<asp:Button ID="btnimguplod" runat="server" Text="Upload Image" onclick="upload" />
<br />
    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#006600"></asp:Label>
</div>

<div>
<asp:GridView ID="Gridview1" CssClass="Gridview" runat="server" Width="500px"
HeaderStyle-BackColor="#7779AF" HeaderStyle-ForeColor="white">
<Columns>

<asp:TemplateField HeaderText="Image">
<ItemTemplate>

<asp:Image ID="Image1" runat="server" ImageUrl='<%# "Handler1.ashx?id_Image="+ Eval("id") %>' Height="400px" Width="600px"/>

</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</div>
</form>
</body>
</html>
