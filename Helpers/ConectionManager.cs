using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIFX.Helpers
{
    public class ConectionManager
    {
        private AppSettings AppSettings { get; set; }
        public ConectionManager(IOptions<AppSettings> configuration)
        {
            AppSettings = configuration.Value;
        }
        public void AcctionRun(string procedure, ref string messageError, SqlParameter[] parameters, CommandType type = CommandType.StoredProcedure)
        {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            var sqlAdapter = new SqlDataAdapter(procedure, AppSettings.ConectionString);
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            try
            {
                sqlAdapter.SelectCommand.Connection.Open();
                if (parameters != null)
                {
                    sqlAdapter.SelectCommand.Parameters.AddRange(parameters);
                }
                sqlAdapter.SelectCommand.CommandType = type;
                sqlAdapter.SelectCommand.ExecuteNonQuery();
                sqlAdapter.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                messageError = ex.Message;
            }
            finally
            {
                sqlAdapter.SelectCommand.Connection.Close();
                sqlAdapter.SelectCommand.Connection.Dispose();
            }
        }
        public DataTable GetDataTable(string procedure, ref string messageError, SqlParameter[] parameters = null, CommandType type = CommandType.StoredProcedure)
        {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            var sqlAdpter = new SqlDataAdapter(procedure, AppSettings.ConectionString);
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            DataTable dataTable = new DataTable();
            try
            {
                sqlAdpter.SelectCommand.Connection.Open();
                if (parameters != null)
                {
                    sqlAdpter.SelectCommand.Parameters.AddRange(parameters);
                }
                sqlAdpter.SelectCommand.CommandType = type;
                sqlAdpter.Fill(dataTable);
                sqlAdpter.SelectCommand.Connection.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                messageError = ex.Message;

                return dataTable;
            }
            finally
            {
                sqlAdpter.SelectCommand.Connection.Close();
                sqlAdpter.SelectCommand.Connection.Dispose();
            }
        }
        public GenericAnswer GetList<T>(string procedure, SqlParameter[] parameters = null, CommandType type = CommandType.StoredProcedure)
        {
            GenericAnswer response = new GenericAnswer();
            string messageError = string.Empty;
            DataTable dataTable;

            try
            {
                dataTable = GetDataTable(procedure, ref messageError, parameters, type);

                if (!string.IsNullOrEmpty(messageError))
                {
                    response.error = messageError;
                    response.successful = false;
                    return response;
                }
                response.entity = DataTypeConvertion.ConvertDataTable<T>(dataTable);
                response.successful = true;
                response.error = string.Empty;
            }
            catch (Exception ex)
            {
                response.successful = false;
                response.error = ex.Message;
            }

            return response;
        }
        public GenericAnswer GetObject<T>(string procedure, SqlParameter[] parameters = null, CommandType type = CommandType.StoredProcedure)
        {
            GenericAnswer response = new GenericAnswer();
            string messageError = string.Empty;
            DataTable dataTable;

            try
            {
                dataTable = GetDataTable(procedure, ref messageError, parameters, type);

                if (!string.IsNullOrEmpty(messageError))
                {
                    response.error = messageError;
                    response.successful = false;
                    return response;
                }
                response.entity = DataTypeConvertion.ConvertDataTableObject<T>(dataTable);
                response.successful = true;
                response.error = string.Empty;
            }
            catch (Exception ex)
            {
                response.successful = false;
                response.error = ex.Message;
            }

            return response;
        }

    }
}
