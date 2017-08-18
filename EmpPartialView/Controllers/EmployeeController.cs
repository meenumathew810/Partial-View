using EmpPartialView.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpPartialView.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            //List<Employees> emplist = GetEmployees();
            //return View(emplist);
            //return PartialView("Employee", emplist);
            return View();
        }
        public List<Employees> GetEmployees()
        {
            SqlConnection con = new SqlConnection("Data Source=SUYPC068;Initial Catalog=EmployeeDb;Integrated Security=True");
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter("select* from Employees", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            List<Employees> empList = new List<Employees>();
            foreach (DataRow dr in dt.Rows)
            {
                Employees model = new Employees();
                model.Id = Convert.ToInt32(dr["Id"]);
                model.Name = Convert.ToString(dr["Name"]);
                model.Email = Convert.ToString(dr["Email"]);
                model.Phone = Convert.ToInt32(dr["Phone"]);
                empList.Add(model);
            }

            return empList;
        }
        public ActionResult GetEmployee()
        {
            List<Employees> emplist = GetEmployees();
            return PartialView("Employee", emplist);
        }
    }
}