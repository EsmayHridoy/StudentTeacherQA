<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="postDetails.aspx.cs" Inherits="StudentTeacherQA.postDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="post-details-container">
        <h2>Post Details</h2>

        <!-- Display the question -->
        <div class="post-details">
            <h3><strong>Question:</strong> <asp:Label ID="lblQuestion" runat="server"></asp:Label></h3>
            <p><strong>Posted By:</strong> <asp:Label ID="lblStudentName" runat="server"></asp:Label></p>
            <p><strong>Post Date:</strong> <asp:Label ID="lblPostDate" runat="server"></asp:Label></p>
        </div>

        <hr />

        <!-- Display comments -->
        <h3>Comments</h3>
        <asp:Repeater ID="CommentsRepeater" runat="server">
            <ItemTemplate>
                <div class="comment-box">
                    <p><strong><%# Eval("Name") %>:</strong> <%# Eval("Comment") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <hr />

        <!-- Comment box for submitting new comments -->
        <h3>Add a Comment</h3>
        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Rows="4" Width="100%" placeholder="Write your comment here..."></asp:TextBox><br />
        <asp:Button ID="btnSubmitComment" runat="server" Text="Submit Comment" OnClick="btnSubmitComment_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
