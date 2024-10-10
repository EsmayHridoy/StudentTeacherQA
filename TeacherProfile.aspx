<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TeacherProfile.aspx.cs" Inherits="StudentTeacherQA.TeacherProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
    <div class="row">
        <div class="col-md-5">
            <div class="card">
                <div class="card-body">
                    <!-- Profile Section -->
                    <div class="row">
                        <div class="col">
                            <center>
                                <img style="width:100px;" src="imgs/teacherUser.png" />
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Your Profile</h4>
                                <span>Account Status </span>
                                <asp:Label class="badge rounded-pill text-bg-info" ID="Label1" runat="server" Text="Your Status"></asp:Label>
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                                <hr />
                            </center>
                        </div>
                    </div>

                    <!-- Full name & Date of birth -->
                    <div class="row">
                        <div class="col-md-6">
                            <label>Full Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBoxName" runat="server" placeholder="Enter Your Full Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Date of Birth</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBoxDOB" runat="server" placeholder="Enter Your Date of Birth" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- Contact Number & Email -->
                    <div class="row">
                        <div class="col-md-6">
                            <label>Contact Number</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBoxContact" runat="server" placeholder="Enter Your Contact Number" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Email Id</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBoxEmail" runat="server" placeholder="name@example.com" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- Department & Designation -->
                    <div class="row">
                        <div class="col-md-6">
                            <label>Department</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBoxDepartment" runat="server" placeholder="Enter Your Department"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Designation</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBoxDesignation" runat="server" placeholder="Enter Your Designation"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- Educational Email -->
                    <div class="row">
                        <div class="col-md-6">
                            <label>Educational Email</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBoxEduEmail" runat="server" placeholder="Enter Your Educational Email"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- Credentials -->
                    <center>
                        <span class="badge badge-pill badge-primary">Your Credentials</span>
                    </center>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Password</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBoxOldPassword" runat="server" placeholder="Enter Your Password" TextMode="Password" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>New Password</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBoxNewPassword" runat="server" placeholder="Enter Your New Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- Update Button -->
                    <center>
                        <div class="form-group">
                            <asp:Button ID="ButtonUpdate" class="btn btn-primary btn-block btn-lg" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
                        </div>
                    </center>

                    <!-- Label to display update messages -->
                    <center>
                        <asp:Label ID="LabelMessage" runat="server" CssClass="alert alert-info" Text=""></asp:Label>
                    </center>
                </div>
            </div>
        </div>

        <!-- New Grid Section for Questions Interaction -->
        <div class="col-md-7">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <img style="width:100px;" src="imgs/QA%20icon.png" />
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Your Interaction</h4>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <hr />
                            </center>
                        </div>
                    </div>

                    <!-- GridView for Teacher's Commented Questions -->
                    <div class="row">
                        <div class="col">
                            <asp:GridView ID="GridViewInteractions" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                                <Columns>
                                    <asp:BoundField DataField="question_id" HeaderText="Question ID" />
                                    <asp:BoundField DataField="question" HeaderText="Question" />
                                    <asp:BoundField DataField="publish_time" HeaderText="Publish Time" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:TemplateField HeaderText="Actions">
                                        <ItemTemplate>
                                            <asp:Button ID="ButtonViewDetails" runat="server" Text="View Details" 
                                                CommandArgument='<%# Eval("question_id") %>' OnClick="ButtonViewDetails_Click" CssClass="btn btn-success btn-block btn-lg" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <center><a href="homepage.aspx"><< Back Home</a></center>
</div>
</asp:Content>
