using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ADONETWebApp.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            List<string> students = new List<string>();

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolGradesDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("select * from students", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string givenName = (string)reader["FirstName"];
                            students.Add(givenName);
                        }
                    }
                }
            }

            return View(students);
        }
    }
}