using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKita1704_StoredProcedured
{
    class Program
    {
        static void Main(string[] args)
        {
            // Data Source =.; Initial Catalog = EmployeeDB; Integrated Security = True
            // @"Data Source=.;Initial Catalog=DBSchool;Integrated Security=True"

            //Command and Data Reader
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL_School"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT_STUDENTS_ID", conn);
                cmd.Parameters.Add(new SqlParameter("@id", 1));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    Console.WriteLine($" {reader["ID"]} {reader["NAME"]} {reader["COUNTRY_ID"]}");
                }

                cmd.Connection.Close();
            }
            Console.ReadKey();
        }
    }
}
