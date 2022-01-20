<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="exam.aspx.cs" Inherits="Project_OnlineQuiz.Admin.exam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <div class="col-md-12">
        <div class="card">
            <%--Button For select panel--%>
            <div class="btn-group bg-danger">
                <asp:Button ID="btn_panelexamlist" runat="server" Text="Exam List" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" OnClick="btn_panelexamlist_Click" />
                <asp:Button ID="btn_paneladdexam" runat="server" Text="Add Exam" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" OnClick="btn_paneladdexam_Click" />
            </div>
            <%--Assign Panel --%>
            <asp:Panel ID="panel_assign" runat="server">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive">

                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Select Branch</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drp_branch" runat="server" CssClass="form-control" DataTextField="branch" DataValueField="branch">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must select a subject" ControlToValidate="drp_branch" ForeColor="red"  InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                                <label class="col-md-2 col-form-label ">Select Semester</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drp_sem" runat="server" CssClass="form-control" DataTextField="category_name" DataValueField="category_id">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must select a semester" ControlToValidate="drp_sem" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="offset-2">
                                <asp:Button ID="Button1" runat="server" CssClass="btn" BackColor="#4169E1" BorderStyle="None" ForeColor="White" Text="Load" OnClick="Loadd" />
                            </div>
                            <br />
                            <asp:GridView ID="GridView_StudentsList" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="grdview_examlist_PageIndexChanging" >
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                          <asp:CheckBox ID="checkAll" runat="server"  OnCheckedChanged="checkAll" AutoPostBack="True"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" Checked=false />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="enroll" HeaderText="Enrollment Number" />
                                </Columns>
                            </asp:GridView>
                            <br />
                            <div class="offset-2">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn" BackColor="#4169E1" BorderStyle="None" ForeColor="White" Text="Assign" OnClick="Save" />
                            </div>
                            <div class="alert alert-danger text-center">
                                    <asp:Label ID="Label1" runat="server" />
                                </div>
                            
                            
                           <br />
                        
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <%--Add exam panel--%>
            <asp:Panel ID="panel_addexam" runat="server">
                <div class="card-body">
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Select Branch</label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="drp_brancha" runat="server"  AutoPostBack="True" CssClass="form-control" DataTextField="Branch" DataValueField="Branch" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must select a semester" ControlToValidate="drp_brancha" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Select Semester</label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="drp_categoryexam" runat="server" CssClass="form-control" DataTextField="category_name" AutoPostBack="True" DataValueField="category_id" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="require_drpcategory" runat="server" ErrorMessage="You must select a semester" ControlToValidate="drp_categoryexam" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Select Subject</label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="drp_subjectexam" runat="server" CssClass="form-control" AutoPostBack="True" DataTextField="subject_name" DataValueField="subject_id" onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="require_subjecexam" runat="server" ErrorMessage="You must select a subject" ControlToValidate="drp_subjectexam" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Exam Name</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txt_examname" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="require_examname" runat="server" ErrorMessage="Enter exam name" ControlToValidate="txt_examname" ForeColor="red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Exam Id</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txt_examid" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter exam Id" ControlToValidate="txt_examid" ForeColor="red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Exam Discription</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txt_examdis" runat="server" TextMode="MultiLine" CssClass="form-control" Height="150px"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Exam Duration(Minute)</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txt_examduration" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="require_examduration" runat="server" ErrorMessage="Enter exam duration" ControlToValidate="txt_examduration" ForeColor="red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="requireregular_examduration" runat="server" ErrorMessage="Enter a valid time" ControlToValidate="txt_examduration" ForeColor="red" ValidationExpression="^[1-9][0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Exam Pass Marks</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txt_exampassmarks" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="require_exampassmark" runat="server" ErrorMessage="Enter exam pass marks" ControlToValidate="txt_exampassmarks" ForeColor="red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="requireregular_exampassmark" runat="server" ErrorMessage="Enter a valid marks" ControlToValidate="txt_exampassmarks" ForeColor="red" ValidationExpression="^\d{1,45}$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    
                    <div class="row form-group">
                    
                        <form id="form1">
    
                        <asp:FileUpload ID="FileUpload1" runat="server"/>
                        <a href="Handler2.ashx?v=Questions.xlsx"  target=""_blank"">Sample Download</a>
                        
                        </form>
                    
                    </div>
                    <div class="card-footer">
                        <div class="offset-2">
                            <asp:Button ID="btn_addexam" runat="server" Text="Add Exam" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="btn_addexam_Click" />
                        </div>
                        <asp:Panel ID="panel_addexam_warning" runat="server" Visible="false">
                            <br />
                            <div class="alert alert-danger text-center">
                                <asp:Label ID="lbl_examaddwarning" runat="server" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>
            <%--exam list panel--%>
            <asp:Panel ID="panel_examlist" runat="server">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="grdview_examlist" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowCommand="grdview_examlist_RowCommand" AllowPaging="True" OnPageIndexChanging="grdview_examlist_PageIndexChanging" PageSize="5">

                                <Columns>
                                    <asp:BoundField DataField="category_name" HeaderText="Semester" />
                                    <asp:BoundField DataField="subject_name" HeaderText="Subject Name" />
                                    <asp:BoundField DataField="exam_name" HeaderText="Exam Name" />
                                    <asp:BoundField DataField="exam_duration" HeaderText="Duration" />
                                    <asp:BoundField DataField="exam_marks" HeaderText="Marks" />
                                    
                                    <asp:TemplateField HeaderText="Options">
                                        <ItemTemplate>
                                            
                                            <asp:LinkButton ID="btn_deleteexam" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" CommandArgument='<%# Eval("exam_id") %>' CommandName="deleteexam">
                                            <i class="fa fa-trash" aria-hidden="true"></i> Delete
                                            </asp:LinkButton>
                                            
                                            <asp:HyperLink ID="btn_addquestion" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" NavigateUrl='<%# "~/admin/addquestion.aspx?eid=" + Eval("exam_id") %>'>
                                            <i class="fa fa-plus" aria-hidden="true"></i> Add Question
                                            </asp:HyperLink>

                                            <asp:HyperLink ID="btn_viewquestion" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" NavigateUrl='<%# "~/admin/examquestion.aspx?eid=" + Eval("exam_id") %>'>
                                            <i class="fa fa-info-circle" aria-hidden="true"></i> View Question
                                            </asp:HyperLink>  
                                            <asp:Button ID="HyperLink1" Text="Assign" runat="server" CommandArgument='<%#Eval("exam_id")%>' CommandName="heyDude" CssClass="btn" BackColor="#343A40" BorderStyle="None" CausesValidation="False" ForeColor="White"  OnClick="btn_panelassign_Click" />
                                            </asp:Button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    There is no exam added now.Add exam
                                </EmptyDataTemplate>
                                <PagerStyle CssClass="card-footer" HorizontalAlign="Right" />
                            </asp:GridView>

                        </div>
                        <asp:Panel ID="panel_examlist_warning" runat="server" Visible="false">
                            <div class="card-footer">
                                <br />
                                <div class="alert alert-danger text-center">
                                    <asp:Label ID="lbl_examlistwarning" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
