using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB
{
    public class DataAccess
    {
        public DataAccess()
        {
            connection = new SqlConnection("server=BRENDA-PC; database=Book_DB; integrated security=true");
            command = new SqlCommand();
        }
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader PropReader
        {
            get { return reader; }
        }

        public void Query(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }
        public void Read()
        {
            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void SP(string SP)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = SP;
        }
        public void Parameters(string ParameterName, object value)
        {
            command.Parameters.AddWithValue(ParameterName, value);
        }
        public void Execute()
        {
            try
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Close()
        {
            if (reader != null)
                reader.Close();
            connection.Close();
        }

    }
}
