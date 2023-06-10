using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using ProgressWebApplication.Models;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace ProgressWebApplication.Controllers
{
    public class StudentController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        //static student object
        public static Student Student = new Student();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Server=tcp:sqlsarwar.database.windows.net,1433;Initial Catalog=ProgressDB;Persist Security Info=False;User ID=rooot;Password={yourpassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        }

        //Display Student Courses

        [HttpGet]
        public IActionResult Courses()
        {
            Student.courses.Clear();
            SqlDataReader dr;
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from CourseStudent Where StudentId = " + Student.Id + ";";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                SqlDataReader d;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Server=tcp:sqlsarwar.database.windows.net,1433;Initial Catalog=ProgressDB;Persist Security Info=False;User ID=rooot;Password={asd};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM COURSE WHERE Code = " + dr.GetInt32(0) + ";";
                d = comm.ExecuteReader();
                if (d.Read())
                {
                    Course c = new Course(dr.GetInt32(0), d.GetInt32(2), d.GetString(1));
                    if (!Student.courses.Contains(c))
                    Student.courses.Add(c);
                }
                    conn.Close();
            }
            con.Close();
            return View("Course", Student.courses);
        }


        [HttpGet]
        public IActionResult Marks()
        {
           connectionString();
            List<Marks> marks = new List<Marks>();
            foreach (Course c in Student.courses)
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "Select * from CourseStudent Where Code = " + c.Code + " And StudentId = " + Student.Id + ";";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    Marks m = new Marks(dr.GetInt32(0), dr.GetInt32(1), dr.GetInt32(2), dr.GetInt32(3), dr.GetInt32(4), dr.GetInt32(5), dr.GetInt32(6), dr.GetInt32(7));
                    marks.Add(m);
                }
                con.Close();
            }
            con.Close();
            return View("Marks", marks);
        }

        [HttpPost]
        public IActionResult VerifyCredentials(Student st)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM STUDENT WHERE ID = " + st.Id + "AND LoginPassword = '" + st.LoginPassword + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                Student = new Student(dr.GetInt32(0), dr.GetString(1), dr.GetString(2));
                con.Close();
                return View("StudentDashboard", Student);
            }
            else 
            {
                con.Close();
                return View("LoginError");
            }
        }
    
    }

}
