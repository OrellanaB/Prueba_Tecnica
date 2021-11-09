using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.DbConnection
{
    public class DbConnection : IDbConnection
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public DbConnection(IConfiguration configuration, ILogger logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public DataSet runStoreProcedure(string nameStoreProcedure, SqlParameter[] parameters, int ConnectionStrings)
        {
            try
            {
                DataSet dataSet = new DataSet();
                SqlConnection con;
                con = new SqlConnection(configuration.GetConnectionString("connectionString"));

                SqlDataAdapter adapterSQL = new SqlDataAdapter(nameStoreProcedure, con);
                adapterSQL.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapterSQL.SelectCommand.CommandTimeout = int.Parse(configuration["TimeOutSQL"]);

                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        adapterSQL.SelectCommand.Parameters.Add(parameters[i]);
                    }
                }
                adapterSQL.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                logger.LogError(LogEvents.RunStoreProcedure.Id, ex, "RunStoreProcedure ({StoreProcedureName},{Parameters})", nameStoreProcedure, parameters);
                throw new Exception(ex.Message, ex);
            }
        }

        public void runStoreProcedureSQL(string nameStoreProcedure, SqlParameter[] parameters, int ConnectionStrings)
        {
            try
            {
                SqlConnection con;
                con = new SqlConnection(configuration.GetConnectionString("connectionString"));

                con.Open();
                SqlCommand command = new SqlCommand(nameStoreProcedure, con);
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add(parameters[i]);
                    }
                }
                command.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Dispose();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(LogEvents.RunStoreProcedure.Id, ex, "RunStoreProcedure ({StoreProcedureName},{Parameters})", nameStoreProcedure, parameters);
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
