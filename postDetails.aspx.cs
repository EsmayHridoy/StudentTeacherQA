using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace StudentTeacherQA
{
    public partial class postDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get question_id from the query string
                string questionId = Request.QueryString["question_id"];
                if (!string.IsNullOrEmpty(questionId))
                {
                    LoadPostDetails(questionId);
                    LoadComments(questionId);
                }
            }
        }

        // Method to load the question details
        private void LoadPostDetails(string questionId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            string query = @"
                SELECT 
                    q.question_id,
                    s.name AS StudentName,
                    q.question AS Question,
                    q.publish_time AS PostDate
                FROM 
                    question_table q
                JOIN 
                    student_table s ON q.student_id = s.student_id
                WHERE 
                    q.question_id = @QuestionId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@QuestionId", questionId);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Populate the labels with post details
                        lblQuestion.Text = reader["Question"].ToString();
                        lblStudentName.Text = reader["StudentName"].ToString();
                        lblPostDate.Text = Convert.ToDateTime(reader["PostDate"]).ToString("MMM dd, yyyy hh:mm tt");
                    }
                }
            }
        }

        // Method to load all comments related to the question
        private void LoadComments(string questionId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            string query = @"
                SELECT 
                a.comment AS Comment,
                t.name AS Name
                FROM 
                answer_table a
                LEFT JOIN 
                teacher_table t ON a.edu_mail = t.edu_mail 
                WHERE 
                a.question_id = @QuestionId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@QuestionId", questionId);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    CommentsRepeater.DataSource = reader;
                    CommentsRepeater.DataBind();
                }
            }
        }

        // Event handler for submitting a comment
        protected void btnSubmitComment_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("Teacher"))
            {
                string comment = txtComment.Text.Trim();
                string questionId = Request.QueryString["question_id"];
                string eduMail = Session["edu_mail"].ToString(); // Replace with actual logic to get logged-in user's email

                if (!string.IsNullOrEmpty(comment) && !string.IsNullOrEmpty(questionId) && !string.IsNullOrEmpty(eduMail))
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                    string insertQuery = @"
                    INSERT INTO answer_table (question_id, comment, edu_mail) 
                    VALUES (@QuestionId, @Comment, @EduMail)";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@QuestionId", questionId);
                            cmd.Parameters.AddWithValue("@Comment", comment);
                            cmd.Parameters.AddWithValue("@EduMail", eduMail);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Clear the comment box and reload the comments
                    txtComment.Text = string.Empty;
                    LoadComments(questionId);
                }
            }
            else
            {
                // Display an alert message to the user if an error occurs
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Only teachers can comment.......!');", true);
            }
        }

        // Example method to get the logged-in user's email (replace with actual logic)
        private string GetLoggedInUserEmail()
        {
            // Assuming session or user authentication system is in place
            return Session["edu_mail"].ToString(); // Replace with actual logic
        }
    }
}
