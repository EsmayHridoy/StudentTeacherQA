using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace StudentTeacherQA
{
    public partial class TeacherProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if session contains the teacher's email
                if (Session["edu_mail"] != null)
                {
                    string eduMail = Session["edu_mail"].ToString();
                    LoadTeacherProfile(eduMail);
                    LoadTeacherInteractions(eduMail);  // Load interactions based on comments
                }
                else
                {
                    // Handle the case where the session variable is null
                    Response.Redirect("Login.aspx"); // Redirect to login page or handle session expiry
                }
            }
        }

        private void LoadTeacherProfile(string eduEmail)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = @"SELECT name, date_of_birth, contact_number, email, department, designation, edu_mail 
                             FROM teacher_table WHERE edu_mail = @EduEmail";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EduEmail", eduEmail);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        TextBoxName.Text = reader["name"].ToString();
                        TextBoxDOB.Text = Convert.ToDateTime(reader["date_of_birth"]).ToString("yyyy-MM-dd");
                        TextBoxContact.Text = reader["contact_number"].ToString();
                        TextBoxEmail.Text = reader["email"].ToString();
                        TextBoxDepartment.Text = reader["department"].ToString();
                        TextBoxDesignation.Text = reader["designation"].ToString();
                        TextBoxEduEmail.Text = reader["edu_mail"].ToString();
                    }
                }
            }
        }

        private void LoadTeacherInteractions(string eduMail)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = @"SELECT q.question_id, q.question, q.publish_time 
                             FROM question_table as q, answer_table as a 
                             WHERE a.edu_mail = @TeacherEmail AND a.question_id = q.question_id" ;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TeacherEmail", eduMail);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    GridViewInteractions.DataSource = reader;
                    GridViewInteractions.DataBind();
                }
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string query = @"UPDATE teacher_table 
                                 SET name = @Name, date_of_birth = @DOB, contact_number = @Contact, 
                                     email = @Email, department = @Department, designation = @Designation 
                                 WHERE edu_mail = @EduEmail";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", TextBoxName.Text);
                        cmd.Parameters.AddWithValue("@DOB", TextBoxDOB.Text);
                        cmd.Parameters.AddWithValue("@Contact", TextBoxContact.Text);
                        cmd.Parameters.AddWithValue("@Email", TextBoxEmail.Text);
                        cmd.Parameters.AddWithValue("@Department", TextBoxDepartment.Text);
                        cmd.Parameters.AddWithValue("@Designation", TextBoxDesignation.Text);
                        cmd.Parameters.AddWithValue("@EduEmail", TextBoxEduEmail.Text);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            LabelMessage.Text = "Profile updated successfully!";
                        }
                        else
                        {
                            LabelMessage.Text = "Profile update failed!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "An error occurred while updating the profile.";
                // Log the exception message if needed
                Console.WriteLine(ex.Message);
            }
        }

        protected void ButtonViewDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string questionId = btn.CommandArgument;
            Response.Redirect("postDetails.aspx?question_id=" + questionId);
        }
    }
}
