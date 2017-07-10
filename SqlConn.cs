using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EventCalendar
{
    public class SqlConn
    {
        static string DatabaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CalendarEvent"].ConnectionString;

        public static int executeRow(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                int x = cmd.ExecuteNonQuery();
                return x;
            }
        }

        public static DataTable getDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                DataTable tempTable = new DataTable();
                tempTable.Load(cmd.ExecuteReader());

                return tempTable;
            }
        }
    }
}