using System;
using System.Configuration;
using System.Data.SqlClient;

namespace StudentTeacherQA
{
    public partial class StudentProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if session contains the student ID
                if (Session["StudentID"] != null)
                {
                    String studentId = Session["StudentID"].ToString();
                    LoadStudentProfile(studentId);
                    LoadStudentQuestions(studentId);
                }
                else
                {
                    // Handle the case where the session variable is null
                    Response.Redirect("Login.aspx"); // Redirect to login or an error page
                }
            }
        }

        private void LoadStudentProfile(String studentId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = @"SELECT name, date_of_birth, contact_number, email, department, batch, student_id, password 
                            FROM student_table WHERE student_id = @StudentID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        TextBox3.Text = reader["name"].ToString();
                        TextBox4.Text = Convert.ToDateTime(reader["date_of_birth"]).ToString("yyyy-MM-dd");
                        TextBox1.Text = reader["contact_number"].ToString();
                        TextBox2.Text = reader["email"].ToString();
                        DropDownList1.SelectedValue = reader["department"].ToString();
                        DropDownList2.SelectedValue = reader["batch"].ToString();
                        TextBox5.Text = reader["student_id"].ToString();
                        TextBox6.Text = reader["password"].ToString(); // Display the old password
                    }
                    else
                    {
                        // Handle case where student ID is not found
                        Label1.Text = "Student profile not found.";
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String studentId = TextBox5.Text.Trim(); // Get the student ID
            string newPassword = TextBox7.Text; // Get the new password

            if (!string.IsNullOrEmpty(newPassword))
            {
                UpdatePassword(studentId, newPassword);
            }
            else
            {
                Label1.Text = "New password cannot be empty.";
            }
        }

        private void UpdatePassword(String studentId, string newPassword)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = "UPDATE student_table SET password = @Password WHERE student_id = @StudentID"; // Ensure consistent parameter name

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Password", newPassword);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Label1.Text = "Password updated successfully!";
                }
            }
        }

        private void LoadStudentQuestions(String studentId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = @"SELECT question_id, question, publish_time 
                            FROM question_table 
                            WHERE student_id = @StudentID ORDER BY publish_time DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
            }
        }
    }
}
