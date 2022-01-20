<%@ Page Title="" Language="C#" MasterPageFile="~/usermaster.Master" AutoEventWireup="true" CodeBehind="question.aspx.cs" Inherits="Project_OnlineQuiz.question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" runat="server">
    <h2 class="m-4">Answer all the questions</h2>
    <hr />
    <asp:TextBox ID="getstringuser" runat="server" Visible="False"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    
    <asp:ScriptManager ID="ScriptManager2" runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Label ID="lblTime" Text="text" runat="server" />
            <asp:Timer ID="timer" runat="server" Interval="1000">
            </asp:Timer>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:GridView ID="gridview_examquestion" runat="server" AutoGenerateColumns="False" GridLines="None" OnSelectedIndexChanged="gridview_examquestion_SelectedIndexChanged">
        <Columns>
           
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("question_id") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lbl_question" runat="server" Text='<%# Eval("question_name") %>'></asp:Label>   <asp:Image ID="Image4" runat="server" ImageUrl='<%# "Admin/Handler1.ashx?id_Image="+ Eval("id") + "&str=myImg"%>' Height="100px" Width="100px" AlternateText=" " />        <asp:Label ID="Label2" runat="server" Text='<%# string.Format("[ {0} ]" , Eval("marks")) %>' Visible="true" ForeColor="Blue" Font-Bold="true"></asp:Label>
                    
                    <br />
                    <asp:RadioButton GroupName="a" Text='<%# string.Format("{0}" , Eval("opt_one")) %>'  ID="option_one" runat="server" />  <asp:Image ID="Image5" runat="server" ImageUrl='<%# "Admin/Handler1.ashx?id_Image="+ Eval("id") + "&str=popt_one"%>' Height="100px" Width="100px" AlternateText=" " />
                    <br />
                    <asp:RadioButton GroupName="a" Text='<%# Eval("opt_two") %>' ID="option_two" runat="server" />   <asp:Image ID="Image1" runat="server" ImageUrl='<%# "Admin/Handler1.ashx?id_Image="+ Eval("id") + "&str=popt_two"%>' Height="100px" Width="100px" AlternateText=" " />             
                    <br />
                    <asp:RadioButton GroupName="a" Text='<%# Eval("opt_three") %>' ID="option_three" runat="server" />   <asp:Image ID="Image2" runat="server" ImageUrl='<%# "Admin/Handler1.ashx?id_Image="+ Eval("id") + "&str=popt_three"%>' Height="100px" Width="100px" AlternateText=" " />
                    <br />
                    <asp:RadioButton GroupName="a" Text='<%# Eval("opt_four") %>' ID="option_four" runat="server" />    <asp:Image ID="Image3" runat="server" ImageUrl='<%# "Admin/Handler1.ashx?id_Image="+ Eval("id") + "&str=popt_four"%>' Height="100px" Width="100px" AlternateText=" " />
                    <hr />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btn_submit_Click" />
    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <asp:Panel ID="panel_questshow_warning" runat="server" Visible="false">
                    <br />
                    <div class="alert alert-danger text-center">
                        <asp:Label ID="lbl_questshowwarning" runat="server" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
