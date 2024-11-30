using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeldenCableInspection.Abstracts
{
    internal abstract class ASqlDatabase
    {
        public string connectionString = null;
        private SqlConnection connection;
        public async Task<DataTable> Reader(string command)
        {
            DataTable dt = new DataTable();
            using (connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                using (SqlDataReader reader = await sqlCommand.ExecuteReaderAsync()) dt.Load(reader);
            }
            return dt;
        }
        public async Task<int> Query(string command)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand sqlCommand = new SqlCommand(command, connection);
                    return await sqlCommand.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(command + " " + ex.Message);
                    return int.MaxValue;
                }
            }
        }
        public async Task<int> Query(string command, QueryReturn queryReturn, TransactionType transaction)
        {
            using (connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                if (queryReturn.Equals(QueryReturn.SCOPEIDENTITY))
                    command += " SELECT SCOPE_IDENTITY() ID";
                if (transaction.Equals(TransactionType.COMMIT))
                    command = string.Format("BEGIN TRANSACTION T {0} COMMIT TRANSACTION T", command);
                else if (transaction.Equals(TransactionType.ROLLBACK))
                    command = string.Format("BEGIN TRANSACTION T {0} ROLLBACK TRANSACTION T", command);
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                if (queryReturn.Equals(QueryReturn.SCOPEIDENTITY))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        using (SqlDataReader reader = await sqlCommand.ExecuteReaderAsync()) dt.Load(reader);
                        return Decimal.ToInt32(dt.Rows[0].Field<decimal>("ID"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(command + " " + ex.Message);
                        return -1;
                    }
                }
                else
                {
                    return await sqlCommand.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
