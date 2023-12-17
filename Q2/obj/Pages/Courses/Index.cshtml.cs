using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication4.Pages.Courses
{
    public class CourseModel : PageModel
    {
        public List<CourseInfo> listCourses = new List<CourseInfo>();

        public void OnGet()
        { 
              try
              {
                  string conectionString = "Data Source=.\\sqlexpress;Initial Catalog=mystore;Integrated Security=True";

                  using (SqlConnection connection = new SqlConnection(conectionString))
                  {
                      connection.Open();
                      string sql = "SELECT * FROM courses";
                      using (SqlCommand command = new SqlCommand(sql, connection))
                      {
                         using (SqlDataReader reader = command.ExecuteReader())
                         {
                            while (reader.Read())
                            {
                                CourseInfo course = new CourseInfo();
                                course.courseid = (int)reader["Course Id"];
                                course.name = reader["Name"].ToString();
                                course.lecturename = reader["Lecture Name"].ToString();

                                listCourses.Add(course);

                             }
                         }
                      }
                  }
              }
              catch (Exception)
              {
                throw;
              }
        }
        private class Sqlconnection
        {
            public Sqlconnection(string conectionString)
            {
                ConectionString = conectionString;
            }

            public string ConectionString { get; }

            internal void Open()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class CoursesInfo
    {
        public string? courseid;
        public string? name;
        public string? lecturename;
    }
}
