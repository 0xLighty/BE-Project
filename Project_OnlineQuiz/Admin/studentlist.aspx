<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"  enableEventValidation="false" CodeBehind="studentlist.aspx.cs" Inherits="Project_OnlineQuiz.Admin.studentlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <div class="col-md-12">
        <div class="card">
            <%--Button For select panel--%>
            <div class="btn-group bg-danger">
                <asp:Button ID="btn_panelresult" runat="server" Text="All students" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" BackColor="#343A40" OnClick="btn_panelShow_Click"/>
                
            </div>
            
            
            <div class="card text-center mb-3">
               <asp:Panel ID="panel_showStudents" runat="server" ScrollBars="Auto">
                <div class="card-body">
                    <div class="table-responsive" style="overflow:hidden">
                        <div class="row form-group">
                                
                                 
                                <label class="col-md-6 col-form-label ">Branch</label>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="drp_branch" runat="server" ValidationGroup="TimeSlot" CssClass="form-control" DataTextField="branch" DataValueField="branch">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="TimeSlot" ErrorMessage="You must select an Branch" ControlToValidate="drp_branch" ForeColor="red" Display="Dynamic" EnableClientScript="True" InitialValue="-1" ></asp:RequiredFieldValidator>
                                    </div>
                                
                            </div>
                        <div class="row form-group">
                                
                                 
                                <label class="col-md-6 col-form-label ">Semester</label>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="drp_sem" runat="server" ValidationGroup="TimeSlot" CssClass="form-control" DataTextField="category_name" DataValueField="category_name">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="TimeSlot" ErrorMessage="You must select a semester" ControlToValidate="drp_sem" ForeColor="red" Display="Dynamic" EnableClientScript="True" InitialValue="-1" ></asp:RequiredFieldValidator>
                                    </div>
                                
                            </div>
                        <div class="row form-group">
                                
                                 
                                <label class="col-md-6 col-form-label ">Pass out year</label>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="drp_year" runat="server" ValidationGroup="TimeSlot" CssClass="form-control" DataTextField="passOutYear" DataValueField="passOutYear">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="TimeSlot" ErrorMessage="You must select year" ControlToValidate="drp_year" ForeColor="red" Display="Dynamic" EnableClientScript="True" InitialValue="-1" ></asp:RequiredFieldValidator>
                                    </div>
                                
                            </div>
                        <asp:Button ID="Button12" runat="server" Text="Load" CssClass="btn" ValidationGroup="TimeSlot" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="btn_q_Click" />
                        <asp:GridView ID="gridallstudents" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered" PageSize="8" OnPageIndexChanging="gridallstudents_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="fName" HeaderText="First name" />
                                <asp:BoundField DataField="lName" HeaderText="Last name" />
                                <asp:BoundField DataField="email" HeaderText="Email" />
                                <asp:TemplateField HeaderText="Result">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="btn_viewquestion" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" NavigateUrl='<%# "~/admin/result.aspx?uid=" + Eval("enroll") %>'>
                                            <i class="fa fa-info-circle" aria-hidden="true"></i> View Result
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                



                <asp:Panel ID="panel_studentlistshow_warning" runat="server" Visible="false">
                    <div class="card-footer">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="lbl_studentlistshowwarning" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
                </asp:Panel>

                

            </div>
            

            
                
                
        </div>
    </div>
</asp:Content>
