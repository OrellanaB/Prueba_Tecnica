using Prueba_Tecnica.Models;
using Prueba_Tecnica.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Repositories
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly DbConnection.IDbConnection dbConnection;
        private readonly IGeneralRepository generalData;

        public GeneralRepository(DbConnection.IDbConnection dbConnection, IGeneralRepository generalData)
        {
            this.dbConnection = dbConnection;
            this.generalData = generalData;
        }

        public MessegeViewModel GetErrorInfo(DataTable dt)
        {
            MessegeViewModel msg = null;

            if (dt.Columns.Contains("ERROR_MESSAGE"))
            {
                foreach (DataRow dataAppTemp in dt.Rows)
                {
                    msg = new MessegeViewModel
                    {
                        ErrorLine = dataAppTemp["ERROR_LINE"].ToString(),
                        ErrorProcedure = dataAppTemp["ERROR_PROCEDURE"].ToString(),
                        ErrorMessage = dataAppTemp["ERROR_MESSAGE"].ToString(),
                        ErrorSeverity = dataAppTemp["ERROR_SEVERITY"].ToString(),
                        ErrorState = dataAppTemp["ERROR_STATE"].ToString(),
                        NumberError = dataAppTemp["ERROR_NUMBER"].ToString()
                    };
                }
            }
            return msg;
        }
    }
}
