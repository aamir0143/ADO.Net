using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net
{
    public class EmployeeRepository
    {
        public static string ConnectionString = @"Data Source=DESKTOP-EQ2NJUS\SQLEXPRESS;Initial Catalog=Payroll_Service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = null;

        public void GetAllEmployees()
        {
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    EmployeeModel model = new EmployeeModel();
                    string query = "select * from Employee_PayRoll";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmployeeId = Convert.ToInt32(reader["Id"] == DBNull.Value ? default : reader["Id"]);
                            model.Name = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
                            model.BasicPay = Convert.ToDouble(reader["BasicPay"] == DBNull.Value ? default : reader["BasicPay"]);
                            model.StartDate = (DateTime)((reader["StartDate"] == DBNull.Value ? default(DateTime) : reader["StartDate"]));
                            model.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                            model.Phone = Convert.ToInt64(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                            model.DepDummy = reader["DepDummy"] == DBNull.Value ? default : reader["DepDummy"].ToString();
                            model.Country = reader["Country"] == DBNull.Value ? default : reader["Country"].ToString();
                            model.Department = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
                            model.Deductions = Convert.ToDouble(reader["Deductions"] == DBNull.Value ? default : reader["Deductions"]);
                            model.TaxablePay = Convert.ToDouble(reader["TaxablePay"] == DBNull.Value ? default : reader["TaxablePay"]);
                            model.IncomeTax = Convert.ToDouble(reader["IncomeTax"] == DBNull.Value ? default : reader["IncomeTax"]);
                            model.NetPay = Convert.ToDouble(reader["NetPay"] == DBNull.Value ? default : reader["NetPay"]);
                            model.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", model.EmployeeId, model.Name, model.BasicPay, model.StartDate, model.Gender, model.Phone, model.DepDummy, model.Country, model.Department, model.Deductions, model.TaxablePay, model.IncomeTax, model.NetPay, model.Address);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows Present");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
