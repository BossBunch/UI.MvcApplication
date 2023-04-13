using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using System.Configuration;

namespace DatabaseLayer
{
    
    public class EmployeeDatabaseLayer:IEmployee
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                //string CS = ConfigurationManager.ConnectionStrings["DevConnection"].ConnectionString;
                string CS = "Data Source=.; Initial Catalog= MyDemo; Integrated Security=False; Persist Security Info=False;  User ID=sa; Password= Hdfc@123; TrustServerCertificate=True;";

                List<Employee> employees = new List<Employee>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                        employee.EmployeeName = dr["EmployeeName"].ToString();
                        employee.EmployeeGender = dr["EmployeeGender"].ToString();
                        employee.EmployeeDesignation = dr["EmployeeDesignation"].ToString();
                        employee.EmployeeCity = dr["EmployeeCity"].ToString();
                        employees.Add(employee);
                    }
                }
                return employees;
            }
        }
        public IEnumerable<Employee> GetEmployees()
        {
                //string CS = ConfigurationManager.ConnectionStrings["DevConnection"].ConnectionString;
                string CS = "Data Source=.; Initial Catalog= MyDemo; Integrated Security=False; Persist Security Info=False;  User ID=sa; Password= Hdfc@123; TrustServerCertificate=True;";

                List<Employee> employees = new List<Employee>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {   
                        Employee employee = new Employee();
                        employee.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                        employee.EmployeeName = dr["EmployeeName"].ToString();
                        employee.EmployeeGender = dr["EmployeeGender"].ToString();
                        employee.EmployeeDesignation = dr["EmployeeDesignation"].ToString();
                        employee.EmployeeCity = dr["EmployeeCity"].ToString();
                        employees.Add(employee);
                    }
                }
                return employees;
           
        }


        public void AddEmployee(Employee employee)
        {
            string CS = "Data Source=.; Initial Catalog= MyDemo; Integrated Security=False; Persist Security Info=False;  User ID=sa; Password= Hdfc@123; TrustServerCertificate=True;"; ;
            //string CS = ConfigurationManager.ConnectionStrings["DevConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeGender", employee.EmployeeGender);
                cmd.Parameters.AddWithValue("@EmployeeDesignation", employee.EmployeeDesignation);
                cmd.Parameters.AddWithValue("@EmployeeCity", employee.EmployeeCity);

                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            string CS = "Data Source=.; Initial Catalog= MyDemo; Integrated Security=False; Persist Security Info=False;  User ID=sa; Password= Hdfc@123; TrustServerCertificate=True;"; ;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeGender", employee.EmployeeGender);
                cmd.Parameters.AddWithValue("@EmployeeDesignation", employee.EmployeeDesignation);
                cmd.Parameters.AddWithValue("@EmployeeCity", employee.EmployeeCity);


                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(int id)
        {
            string CS = "Data Source=.; Initial Catalog= MyDemo; Integrated Security=False; Persist Security Info=False;  User ID=sa; Password= Hdfc@123; TrustServerCertificate=True;"; ;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", id);
                cmd.ExecuteNonQuery();
            }
        }

        
    }
}
