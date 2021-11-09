using Prueba_Tecnica.Models;
using Prueba_Tecnica.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly DbConnection.IDbConnection dbConnection;
        private readonly IGeneralRepository generalData;

        public AreaRepository(DbConnection.IDbConnection dbConnection, IGeneralRepository generalData)
        {
            this.dbConnection = dbConnection;
            this.generalData = generalData;
        }

        public GeneralViewModel Create(AreaViewModel data)
        {
            GeneralViewModel gvm = new GeneralViewModel();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdArea", SqlDbType.Int)
                {
                    Value = data.IdArea,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@Nombre", SqlDbType.VarChar)
                {
                    Value = data.Name,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@Descripcion", SqlDbType.VarChar)
                {
                    Value = data.Description,
                    Direction = ParameterDirection.Input
                },
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.INSERTAREA", parameters, 1);

            if (dataSet.Tables.Count != 0)
            {
                DataTable dtApp = dataSet.Tables[0];
                gvm.msg = generalData.GetErrorInfo(dtApp);
            }
            return gvm;
        }

        public GeneralViewModel Update(AreaViewModel data)
        {
            GeneralViewModel gvm = new GeneralViewModel();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdArea", SqlDbType.Int)
                {
                    Value = data.IdArea,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@Nombre", SqlDbType.VarChar)
                {
                    Value = data.Name,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@Descripcion", SqlDbType.VarChar)
                {
                    Value = data.Description,
                    Direction = ParameterDirection.Input
                },
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.UPDATEAREA", parameters, 1);

            if (dataSet.Tables.Count != 0)
            {
                DataTable dtApp = dataSet.Tables[0];
                gvm.msg = generalData.GetErrorInfo(dtApp);
            }
            return gvm;
        }

        public GeneralViewModel Delete(int id)
        {
            GeneralViewModel gvm = new GeneralViewModel();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdArea", SqlDbType.Int)
                {
                    Value = id,
                    Direction = ParameterDirection.Input
                }
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.DELETEAREA", parameters, 1);

            if (dataSet.Tables.Count != 0)
            {
                DataTable dtApp = dataSet.Tables[0];
                gvm.msg = generalData.GetErrorInfo(dtApp);
            }
            return gvm;
        }

        public GeneralViewModel GetAll()
        {
            GeneralViewModel gvm = new GeneralViewModel();

            SqlParameter[] parameters = new SqlParameter[] { };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.SEARCHAREA", parameters, 1);

            if (dataSet.Tables.Count != 0)
            {
                DataTable dtApp = dataSet.Tables[0];
                gvm.msg = generalData.GetErrorInfo(dtApp);
                if (gvm.msg == null)
                {
                    gvm.arrayListData = new ArrayList();
                    foreach (DataRow dataTemp in dtApp.Rows)
                    {
                        gvm.arrayListData.Add(new AreaViewModel
                        {
                            IdArea = int.Parse(dataTemp["IdArea"].ToString()),
                            Name = dataTemp["Nombre"].ToString(),
                            Description = dataTemp["Descripcion"].ToString()
                        });
                    }
                    
                }
            }
            return gvm;
        }

        public GeneralViewModel GetById(int id)
        {
            GeneralViewModel gvm = new GeneralViewModel();

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@IdArea", SqlDbType.Int)
                {
                    Value = id,
                    Direction = ParameterDirection.Input
                }
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.READAREA", parameters, 1);

            if (dataSet.Tables.Count != 0)
            {
                DataTable dtApp = dataSet.Tables[0];
                gvm.msg = generalData.GetErrorInfo(dtApp);
                if (gvm.msg == null)
                {
                    gvm.arrayListData = new ArrayList();
                    foreach (DataRow dataTemp in dtApp.Rows)
                    {
                        gvm.arrayListData.Add(new AreaViewModel
                        {
                            IdArea = int.Parse(dataTemp["IdArea"].ToString()),
                            Name = dataTemp["Nombre"].ToString(),
                            Description = dataTemp["Descripcion"].ToString()
                        });
                    }

                }
            }
            return gvm;
        }
    }
}
