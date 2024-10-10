using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace StudentTeacherQA
{
    public partial class ViewQA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPosts();
            }
        }

        // Method to bind posts to the Repeater control
        private void BindPosts()
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
        GROUP BY 
            q.question_id, s.name, q.question, q.publish_time
        ORDER BY 
            q.publish_time DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    PostRepeater.DataSource = reader;
                    PostRepeater.DataBind();
                }
            }
        }

        // Event handler for the Submit button click
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text.Trim();

            if (!string.IsNullOrEmpty(question))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                string insertQuery = @"
                    INSERT INTO question_table (question, publish_time, student_id) 
                    VALUES (@Question, @PublishTime, @StudentID)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Question", question);
                        cmd.Parameters.AddWithValue("@PublishTime", DateTime.Now);
                        // Replace with actual logged-in student ID
                        cmd.Parameters.AddWithValue("@StudentID", GetCurrentStudentID());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // Clear the TextBox and reload the posts
                txtQuestion.Text = string.Empty;
                BindPosts();
            }
        }

        // Example method to get the logged-in student's ID (replace with actual logic)
        private String GetCurrentStudentID()
        {
            // Assuming a session or user authentication system is in place
            // Return the current student's ID here
            return Session["username"].ToString(); // Replace with actual logic
        }

        // Event handler for the Details button click
        protected void btnDetails_Command(object sender, CommandEventArgs e)
        {
            // Get the question ID from the CommandArgument
            string questionID = e.CommandArgument.ToString();

            // Redirect to the postDetails.aspx page, passing the question ID as a query string parameter
            Response.Redirect($"postDetails.aspx?question_id={questionID}");
        }

    }
}
