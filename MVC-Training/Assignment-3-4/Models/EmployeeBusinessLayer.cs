using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Assignment_3_4.Models
{
    public class EmployeeBusinessLayer
    {
        #region Global variables
        readonly string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
        #endregion

        #region Get employee request
        /// <summary>Gets the employees.</summary>
        /// <value>The employees.</value>
        public IEnumerable<Employee> Employees
        {
            get
            {
                List<Employee> employees = new List<Employee>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("Operations", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Action", "spGetAllEmployees");
                        connection.Open();

                        SqlDataReader sqlDataReader = command.ExecuteReader();

                        while (sqlDataReader.Read())
                        {
                            Employee employee = new Employee
                            {
                                Id = Convert.ToInt32(sqlDataReader["Id"]),
                                Name = sqlDataReader["Name"].ToString(),
                                Gender = sqlDataReader["Gender"].ToString(),
                                City = sqlDataReader["City"].ToString()
                            };
                            if (!(sqlDataReader["DateOfBirth"] is DBNull))
                            {
                                employee.DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]);
                            }
                            employees.Add(employee);
                        }
                    }
                }
                return employees;
            }
        }
        #endregion

        #region Add eployee request
        public void SaveEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("Operations", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Action", "spAddEmployee");
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@City", employee.City);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update employee request
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("Operations", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Action", "spUpdateEmployee");
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@City", employee.City);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Delete employee request
        public void DeleteEmployee(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("Operations", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Action", "spDeleteEmployee");
                    command.Parameters.AddWithValue("@Id", Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}