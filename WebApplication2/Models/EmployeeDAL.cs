using System.Data;
using System.Data.SqlClient;
namespace WebApplication2.Models
{
    public class EmployeeDAL
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            List<EmployeeInfo> empList = new List<EmployeeInfo>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmployeeInfo emp = new EmployeeInfo();
                    emp.ID = new Guid(dr["ID"].ToString());
                    emp.Name = dr["Name"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Company = dr["Company"].ToString();
                    emp.Department = dr["Department"].ToString();

                    empList.Add(emp);
                }
                con.Close();
            }
            return empList;
        }
        public void AddEmployee(EmployeeInfo emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Company", emp.Company);
                cmd.Parameters.AddWithValue("@Department", emp.Department);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateEmployee(EmployeeInfo emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmployee", con);
                cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", emp.ID);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Company", emp.Company);
                cmd.Parameters.AddWithValue("@Department", emp.Department);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteEmployee(int? empId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", con);
                cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", empId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public EmployeeInfo GetEmployeeById(int? empId)
        {
            EmployeeInfo emp = new EmployeeInfo();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", empId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp.ID = new Guid(dr["ID"].ToString());
                    emp.Name = dr["Name"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Company = dr["Company"].ToString();
                    emp.Department = dr["Department"].ToString();
                }
                con.Close();
            }
            return emp;
        }

    }
}
