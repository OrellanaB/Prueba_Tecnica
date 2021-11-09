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
    public class SkillEmployeeRepository : ISkillEmployeeRepository
    {
        private readonly DbConnection.IDbConnection dbConnection;
        private readonly IGeneralRepository generalData;

        public SkillEmployeeRepository(DbConnection.IDbConnection dbConnection, IGeneralRepository generalData)
        {
            this.dbConnection = dbConnection;
            this.generalData = generalData;
        }

        public GeneralViewModel Create(EmpleadoHabilidadViewModel data)
        {
            GeneralViewModel gvm = new GeneralViewModel();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdHabilidad", SqlDbType.Int)
                {
                    Value = data.IdAbility,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@IdEmpleado", SqlDbType.Int)
                {
                    Value = data.IdEmployee,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@NombreHabilidad", SqlDbType.VarChar)
                {
                    Value = data.SkillName,
                    Direction = ParameterDirection.Input
                }
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.INSERTEMPLEADOHABILIDAD", parameters, 1);

            if (dataSet.Tables.Count != 0)
            {
                DataTable dtApp = dataSet.Tables[0];
                gvm.msg = generalData.GetErrorInfo(dtApp);
            }
            return gvm;
        }

        public GeneralViewModel Update(EmpleadoHabilidadViewModel data)
        {
            GeneralViewModel gvm = new GeneralViewModel();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdHabilidad", SqlDbType.Int)
                {
                    Value = data.IdAbility,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@IdEmpleado", SqlDbType.Int)
                {
                    Value = data.IdEmployee,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@NombreHabilidad", SqlDbType.VarChar)
                {
                    Value = data.SkillName,
                    Direction = ParameterDirection.Input
                }
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.UPDATEEMPLEADOHABILIDAD", parameters, 1);

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
                new SqlParameter("@IdHabilidad", SqlDbType.Int)
                {
                    Value = id,
                    Direction = ParameterDirection.Input
                }
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.DELETEMPLEADOHABILIDAD", parameters, 1);

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

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.SEARCHEMPLEADOHABILIDAD", parameters, 1);

            if (dataSet.Tables.Count != 0)
            {
                DataTable dtApp = dataSet.Tables[0];
                gvm.msg = generalData.GetErrorInfo(dtApp);
                if (gvm.msg == null)
                {
                    gvm.arrayListData = new ArrayList();
                    foreach (DataRow dataTemp in dtApp.Rows)
                    {
                        gvm.arrayListData.Add(new EmpleadoHabilidadViewModel
                        {
                            IdAbility = int.Parse(dataTemp["IdHabilidad"].ToString()),
                            Empleado = new EmpleadoViewModel
                            {
                                IdEmployee = int.Parse(dataTemp["IdEmpleado"].ToString())
                            },
                            SkillName = dataTemp["NombreHabilidad"].ToString()
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
                new SqlParameter("@IdEmpleado", SqlDbType.Int)
                {
                    Value = id,
                    Direction = ParameterDirection.Input
                },
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.READEMPLEADOHABILIDAD", parameters, 1);

            if (dataSet.Tables.Count != 0)
            {
                DataTable dtApp = dataSet.Tables[0];
                gvm.msg = generalData.GetErrorInfo(dtApp);
                if (gvm.msg == null)
                {
                    gvm.arrayListData = new ArrayList();
                    foreach (DataRow dataTemp in dtApp.Rows)
                    {
                        gvm.arrayListData.Add(new EmpleadoHabilidadViewModel
                        {
                            IdAbility = int.Parse(dataTemp["IdHabilidad"].ToString()),
                            Empleado = new EmpleadoViewModel
                            {
                                IdEmployee = int.Parse(dataTemp["IdEmpleado"].ToString())
                            },
                            SkillName = dataTemp["NombreHabilidad"].ToString()
                        });
                    }

                }
            }
            return gvm;
        }
    }
}
