using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace WebApplication4.Pages.Students
{
    public class IndexModel : PageModel
    {
        public List<StudentInfo> liststudents = new List<StudentInfo>();  
        public void OnGet()
        {
            try
            {
                string conectionString = "Data Source=.\\sqlexpress;Initial Catalog=mystore;Integrated Security=True";

                using (SqlConnection connection = new (conectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM students";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentInfo StudentInfo = new StudentInfo();
                                StudentInfo.studentid = "" + reader["Student Id"];
                                StudentInfo.name = reader["Name"].ToString();
                                StudentInfo.city = reader["City"].ToString();
                                StudentInfo.courseid = reader["Course Id"].ToString();

                                liststudents.Add(StudentInfo);

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


    public class StudentInfo
    {
        public string? studentid;
        public string? name;
        public string? city;
        public string? courseid;
    }
}
