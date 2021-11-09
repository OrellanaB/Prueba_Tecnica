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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbConnection.IDbConnection dbConnection;
        private readonly IGeneralRepository generalData;

        public EmployeeRepository(DbConnection.IDbConnection dbConnection, IGeneralRepository generalData)
        {
            this.dbConnection = dbConnection;
            this.generalData = generalData;
        }

        public GeneralViewModel Create(EmpleadoViewModel data)
        {
            GeneralViewModel gvm = new GeneralViewModel();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdEmpleado", SqlDbType.Int)
                {
                    Value = data.IdArea,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@NombreCompleto", SqlDbType.VarChar)
                {
                    Value = data.FullName,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@Cedula", SqlDbType.VarChar)
                {
                    Value = data.identification,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@Correo", SqlDbType.VarChar)
                {
                    Value = data.Email,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@FechaNacimiento", SqlDbType.Date)
                {
                    Value = data.DateBirth,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@FechaIngreso", SqlDbType.Date)
                {
                    Value = data.AdmissionDate,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@IdJefe", SqlDbType.Int)
                {
                    Value = data.IdBoss,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@IdArea", SqlDbType.Int)
                {
                    Value = data.IdArea,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@Foto", SqlDbType.Binary)
                {
                    Value = data.Photo,
                    Direction = ParameterDirection.Input
                }
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.INSERTEMPLEADO", parameters, 1);

            if (dataSet.Tables.Count != 0)
            {
                DataTable dtApp = dataSet.Tables[0];
                gvm.msg = generalData.GetErrorInfo(dtApp);
            }
            return gvm;
        }

        public GeneralViewModel Update(EmpleadoViewModel data)
        {
            GeneralViewModel gvm = new GeneralViewModel();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdEmpleado", SqlDbType.Int)
                {
                    Value = data.IdArea,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@NombreCompleto", SqlDbType.VarChar)
                {
                    Value = data.FullName,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@Cedula", SqlDbType.VarChar)
                {
                    Value = data.identification,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@Correo", SqlDbType.VarChar)
                {
                    Value = data.Email,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@FechaNacimiento", SqlDbType.Date)
                {
                    Value = data.DateBirth,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@FechaIngreso", SqlDbType.Date)
                {
                    Value = data.AdmissionDate,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@IdJefe", SqlDbType.Int)
                {
                    Value = data.IdBoss,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@IdArea", SqlDbType.Int)
                {
                    Value = data.IdArea,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter("@Foto", SqlDbType.Binary)
                {
                    Value = data.Photo,
                    Direction = ParameterDirection.Input
                }
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.UPDATEEMPLEADO", parameters, 1);

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
                new SqlParameter("@IdEmpleado", SqlDbType.Int)
                {
                    Value = id,
                    Direction = ParameterDirection.Input
                }
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.DELETEMPLEADO", parameters, 1);

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

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.SEARCHEMPLEADO", parameters, 1);

            if (dataSet.Tables.Count != 0)
            {
                DataTable dtApp = dataSet.Tables[0];
                gvm.msg = generalData.GetErrorInfo(dtApp);
                if (gvm.msg == null)
                {
                    gvm.arrayListData = new ArrayList();
                    foreach (DataRow dataTemp in dtApp.Rows)
                    {
                        gvm.arrayListData.Add(new EmpleadoViewModel
                        {
                            IdEmployee = int.Parse(dataTemp["IdEmpleado"].ToString()),
                            FullName = dataTemp["NombreCompleto"].ToString(),
                            identification = dataTemp["Cedula"].ToString(),
                            Email = dataTemp["Correo"].ToString(),
                            DateBirth = DateTime.Parse(dataTemp["FechaNacimiento"].ToString()),
                            AdmissionDate = DateTime.Parse(dataTemp["FechaIngreso"].ToString()),
                            IdBoss = int.Parse(dataTemp["IdJefe"].ToString()),
                            Area = new AreaViewModel
                            {
                                IdArea = int.Parse(dataTemp["IdArea"].ToString())
                            },

                            Photo = byte.Parse(dataTemp["Foto"].ToString())
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
                }
            };

            DataSet dataSet = dbConnection.runStoreProcedure("dbo.READEMPLEADO", parameters, 1);

            if (dataSet.Tables.Count != 0)
            {
                DataTable dtApp = dataSet.Tables[0];
                gvm.msg = generalData.GetErrorInfo(dtApp);
                if (gvm.msg == null)
                {
                    gvm.arrayListData = new ArrayList();
                    foreach (DataRow dataTemp in dtApp.Rows)
                    {
                        gvm.arrayListData.Add(new EmpleadoViewModel
                        {
                            IdEmployee = int.Parse(dataTemp["IdEmpleado"].ToString()),
                            FullName = dataTemp["NombreCompleto"].ToString(),
                            identification = dataTemp["Cedula"].ToString(),
                            Email = dataTemp["Correo"].ToString(),
                            DateBirth = DateTime.Parse(dataTemp["FechaNacimiento"].ToString()),
                            AdmissionDate = DateTime.Parse(dataTemp["FechaIngreso"].ToString()),
                            IdBoss = int.Parse(dataTemp["IdJefe"].ToString()),
                            Area = new AreaViewModel
                            {
                               IdArea = int.Parse(dataTemp["IdArea"].ToString())
                            },
                            
                            Photo = byte.Parse(dataTemp["Foto"].ToString())
                        });
                    }

                }
            }
            return gvm;
        }
    }
}
