<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="result.aspx.cs" Inherits="Project_OnlineQuiz.Admin.result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <div class="col-md-12">
        <div class="card">
            <%--Button For select panel--%>
            <div class="btn-group bg-danger">
                <asp:Button ID="btn_panelresult" runat="server" Text="All result" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" BackColor="#343A40" />
            </div>
            <div class="card text-center mb-3">
                <asp:Panel ID="panel2" runat="server">
                <div class="row form-group">
                                
                                 
                                <label class="col-md-6 col-form-label ">Exam Id</label>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="drp_EId" runat="server" ValidationGroup="TimeSlot" CssClass="form-control" DataTextField="exam_fid" DataValueField="exam_fid">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="TimeSlot" ErrorMessage="You must select an Exam Id" ControlToValidate="drp_EId" ForeColor="red" Display="Dynamic" EnableClientScript="True" InitialValue="-1" ></asp:RequiredFieldValidator>
                                    </div>
                                
                            </div>
                    </asp:Panel>
                
                <asp:Panel ID="panel1" runat="server">
                <div class="row form-group">
                                
                                 
                                <label class="col-md-6 col-form-label ">Pass out year</label>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="drp_year" runat="server" ValidationGroup="TimeSlot" CssClass="form-control" DataTextField="pOyear" DataValueField="pOyear">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="TimeSlot" ErrorMessage="You must select year" ControlToValidate="drp_year" ForeColor="red" Display="Dynamic" EnableClientScript="True" InitialValue="-1" ></asp:RequiredFieldValidator>
                                    </div>
                                
                            </div>
                    </asp:Panel>
                <asp:Button ID="Button12" runat="server" Text="Load" CssClass="btn" ValidationGroup="TimeSlot" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="btn_q_Click" />
                
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="gridviewspecific" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered" PageSize="8" Visible="false" OnPageIndexChanging="gridviewspecific_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="user_enroll" HeaderText="Enroll" />
                                <asp:BoundField DataField="status" HeaderText="Result" />
                                <asp:BoundField DataField="exam_marks" HeaderText="Total Marks" />
                                <asp:BoundField DataField="score" HeaderText="Your Score" />
                            </Columns>
                        </asp:GridView>
                        
                        <asp:GridView ID="gridresult" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered" PageSize="8" OnPageIndexChanging="gridresult_PageIndexChanging">
                            <Columns>
                                 <asp:BoundField DataField="user_enroll" HeaderText="Enroll" />
                                <asp:BoundField DataField="exam_fid" HeaderText="Exam_Id" NullDisplayText="no exam name" />
                                <asp:BoundField DataField="status" HeaderText="Result" />
                                <asp:BoundField DataField="exam_marks" HeaderText="Total Marks" />
                                <asp:BoundField DataField="score" HeaderText="Score" />
                            </Columns>
                        </asp:GridView>
                        <asp:Panel ID="panel3" runat="server" Visible="false">
                            <asp:GridView ID="GridView1" runat="server" GridLines="None" AllowPaging="false" AutoGenerateColumns="False" CssClass="table table-bordered">
                                <Columns>
                                    <asp:BoundField DataField="user_enroll" HeaderText="Enroll" />
                                    <asp:BoundField DataField="exam_fid" HeaderText="Exam_Id" NullDisplayText="no exam name" />
                                    <asp:BoundField DataField="status" HeaderText="Result" />
                                    <asp:BoundField DataField="exam_marks" HeaderText="Total Marks" />
                                    <asp:BoundField DataField="score" HeaderText="Score" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>

                    </div>
                    <asp:Button ID="btn_Report" runat="server" Text="Generate Report" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="Button1_Click" />
                    
                </div>
                <asp:Panel ID="panel_resultshow_warning" runat="server" Visible="false">
                    <div class="card-footer">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="lbl_resultshowwarning" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
