<%@ Page Title="View QA" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewQA.aspx.cs" Inherits="StudentTeacherQA.ViewQA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .newsfeed-container {
            width: 60%;
            margin: 0 auto;
            padding-top: 20px;
        }
        .post-card {
            background-color: #fff;
            border: 1px solid #ddd;
            padding: 15px;
            margin-bottom: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        .post-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 10px;
        }
        .post-header .student-name {
            font-size: 18px;
            font-weight: bold;
            color: #333;
        }
        .post-header .post-date {
            font-size: 14px;
            color: #888;
        }
        .post-comment {
            font-size: 16px;
            color: #555;
        }
        .question-form {
            margin-bottom: 30px;
            padding: 15px;
            border: 1px solid #ddd;
            border-radius: 8px;
            background-color: #f9f9f9;
        }
        .question-form input[type="text"], .question-form textarea {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .question-form input[type="submit"] {
            padding: 10px 20px;
            font-size: 16px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .question-form input[type="submit"]:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Form to Post a New Question -->
    <div class="newsfeed-container">
        <div class="question-form">
            <h3>Post a New Question</h3>
            <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Rows="4" placeholder="Type your question here..."></asp:TextBox><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
        </div>

<!-- Displaying Questions as Newsfeed -->
<asp:Repeater ID="PostRepeater" runat="server">
    <ItemTemplate>
        <div class="post-card">
            <div class="post-header">
                <span class="student-name"><%# Eval("StudentName") %></span>
                <span class="post-date"><%# Eval("PostDate", "{0:MMM dd, yyyy hh:mm tt}") %></span>
            </div>
            <div class="post-question">
                <strong>Question:</strong> <%# Eval("Question") %>
            </div>
            <!-- Details Button -->
            <asp:Button ID="btnDetails" runat="server" Text="Details" CommandArgument='<%# Eval("question_id") %>' OnCommand="btnDetails_Command" CssClass="btn btn-info" />
        </div>
    </ItemTemplate>
</asp:Repeater>


    </div>
</asp:Content>
