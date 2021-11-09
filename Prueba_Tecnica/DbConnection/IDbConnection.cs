using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.DbConnection
{
     public interface IDbConnection
    {
        DataSet runStoreProcedure(string nameStoreProcedure, SqlParameter[] parameters, int ConnectionStrings);
        void runStoreProcedureSQL(string nameStoreProcedure, SqlParameter[] parameters, int ConnectionStrings);
    }
}
