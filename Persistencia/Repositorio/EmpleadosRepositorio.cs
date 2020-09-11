using Microsoft.Extensions.Options;
using PruebaIFX.Helpers;
using PruebaIFX.Modelos;
using PruebaIFX.Persistencia.IRepositorio;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PruebaIFX.Persistencia.Repositorio
{
    public class EmpleadosRepositorio : IEmpleadosRepositorio
    {
        protected readonly ConectionManager connectionManager;
        protected const string insertEmpleado = "SpInsertEmpleado";
        protected const string updateEmpleado = "SpUpdateEmpleado";
        protected const string getObjectEmpleado = "SpGetObjEmpleado";
        protected const string getEmpleados = "SpGetEmpleados";
        public EmpleadosRepositorio(IOptions<AppSettings> settings)
        {
            connectionManager = new ConectionManager(settings);
        }
        public GenericAnswer CreateEmpleado(EmpleadosModel entity)
        {
            GenericAnswer response = new GenericAnswer();
            SqlParameter[] parameters =
                {
                new SqlParameter {Value = entity.nombres , ParameterName = "@nombres" },
                new SqlParameter {Value = entity.apellidos , ParameterName = "@apellidos" },
                new SqlParameter {Value = entity.genero , ParameterName = "@genero" },
                new SqlParameter {Value = entity.edad , ParameterName = "@edad" },
                new SqlParameter {Value = entity.cargo , ParameterName = "@cargo" },
                new SqlParameter {Value = entity.salario , ParameterName = "@salario" },
                new SqlParameter {Value = entity.direccion , ParameterName = "@direccion" },
                new SqlParameter {Value = entity.telefono , ParameterName = "@telefono" },
                new SqlParameter {Value = entity.correo , ParameterName = "@correo" },
                new SqlParameter {Value = entity.tipoDocumento , ParameterName = "@tipoDocumento" },
                new SqlParameter {Value = entity.documento , ParameterName = "@documento" },
                new SqlParameter {Value = entity.idEntidad , ParameterName = "@idEntidad" },
                new SqlParameter {Value = entity.idUsuario , ParameterName = "@idUsuario" },
                new SqlParameter {SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output, ParameterName = "@OutIdEmpleado" }
                };
            string messageError = string.Empty;
            connectionManager.AcctionRun(insertEmpleado, ref messageError, parameters);
            if (Convert.ToInt32(parameters[parameters.Length - 1].Value.ToString()) > 0)
            {
                entity.id = Convert.ToInt32(parameters[parameters.Length - 1].Value.ToString());
            }
            if (!string.IsNullOrEmpty(messageError))
            {
                response.error = messageError;
                response.successful = false;

                return response;
            }
            response.error = messageError;
            response.entity = entity;
            response.successful = true;

            return response;
        }

        public GenericAnswer DeleteEmPleado(EmpleadosModel entity)
        {
            throw new System.NotImplementedException();
        }

        public GenericAnswer GetEmpleados()
        {
            GenericAnswer response;
            SqlParameter[] parameters = null;
            response = connectionManager.GetList<EmpleadosModel>(getEmpleados, parameters);

            return response;
        }

        public GenericAnswer GetObjEmpleado(EmpleadosModel entity)
        {
            GenericAnswer response;
            SqlParameter[] parameters =
                {
                new SqlParameter {Value = entity.id , ParameterName = "@id" },
                };
            response = connectionManager.GetObject<EmpleadosModel>(getObjectEmpleado, parameters);

            return response;
        }

        public GenericAnswer UpdateEmpleado(EmpleadosModel entity)
        {
            GenericAnswer response = new GenericAnswer();
            SqlParameter[] parameters =
                {
                new SqlParameter {Value = entity.id , ParameterName = "@id" },
                new SqlParameter {Value = entity.nombres , ParameterName = "@nombres" },
                new SqlParameter {Value = entity.apellidos , ParameterName = "@apellidos" },
                new SqlParameter {Value = entity.genero , ParameterName = "@genero" },
                new SqlParameter {Value = entity.edad , ParameterName = "@edad" },
                new SqlParameter {Value = entity.cargo , ParameterName = "@cargo" },
                new SqlParameter {Value = entity.salario , ParameterName = "@salario" },
                new SqlParameter {Value = entity.direccion , ParameterName = "@direccion" },
                new SqlParameter {Value = entity.telefono , ParameterName = "@telefono" },
                new SqlParameter {Value = entity.correo , ParameterName = "@correo" },
                new SqlParameter {Value = entity.tipoDocumento , ParameterName = "@tipoDocumento" },
                new SqlParameter {Value = entity.documento , ParameterName = "@documento" },
                new SqlParameter {Value = entity.idEntidad , ParameterName = "@idEntidad" },
                new SqlParameter {Value = entity.idUsuario , ParameterName = "@idUsuario" },
                };
            string messageError = string.Empty;
            connectionManager.AcctionRun(updateEmpleado, ref messageError, parameters);
            if (!string.IsNullOrEmpty(messageError))
            {
                response.error = messageError;
                response.successful = false;

                return response;
            }
            response.error = messageError;
            response.entity = entity;
            response.successful = true;

            return response;
        }
    }
}
