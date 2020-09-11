using Microsoft.Extensions.Options;
using PruebaIFX.Helpers;
using PruebaIFX.Modelos;
using PruebaIFX.Persistencia.IRepositorio;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PruebaIFX.Persistencia.Repositorio
{
    public class EntidadesRepositorio : IEntidadesRepositorio
    {
        protected readonly ConectionManager connectionManager;
        protected const string insertEntidad = "SpInsertEntidad";
        protected const string updateEntidad = "SpUpdateEntidad";
        protected const string getObjectEntidad = "SpGetObjEntidad";
        protected const string getEntidades = "SpGetEntidades";

        public EntidadesRepositorio(IOptions<AppSettings> settings)
        {
            connectionManager = new ConectionManager(settings);
        }
        public GenericAnswer CreateEntidad(EntidadesModel entity)
        {
            GenericAnswer response = new GenericAnswer();
            SqlParameter[] parameters =
                {
                new SqlParameter {Value = entity.nombre , ParameterName = "@nombre" },
                new SqlParameter {Value = entity.direccion , ParameterName = "@direccion" },
                new SqlParameter {Value = entity.telefono , ParameterName = "@telefono" },
                new SqlParameter {Value = entity.ciudad , ParameterName = "@ciudad" },
                new SqlParameter {Value = entity.pais , ParameterName = "@pais" },
                new SqlParameter {Value = entity.correo , ParameterName = "@correo" },
                new SqlParameter {SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output, ParameterName = "@OutIdEntidad" }
                };
            string messageError = string.Empty;
            connectionManager.AcctionRun(insertEntidad, ref messageError, parameters);
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

        public GenericAnswer DeleteEntidad(EntidadesModel entity)
        {
            throw new NotImplementedException();
        }

        public GenericAnswer GetEntidades()
        {
            GenericAnswer response;
            SqlParameter[] parameters = null;
            response = connectionManager.GetList<EntidadesModel>(getEntidades, parameters);

            return response;
        }

        public GenericAnswer GetObjEntidad(EntidadesModel entity)
        {
            GenericAnswer response;
            SqlParameter[] parameters =
                { 
                new SqlParameter {Value = entity.id , ParameterName = "@id" },
                };
            response = connectionManager.GetObject<EntidadesModel>(getObjectEntidad, parameters);

            return response;
        }

        public GenericAnswer UpdateEntidad(EntidadesModel entity)
        {
            GenericAnswer response = new GenericAnswer();
            SqlParameter[] parameters =
                {
                new SqlParameter {Value = entity.id , ParameterName = "@id" },
                new SqlParameter {Value = entity.nombre , ParameterName = "@nombre" },
                new SqlParameter {Value = entity.direccion , ParameterName = "@direccion" },
                new SqlParameter {Value = entity.telefono , ParameterName = "@telefono" },
                new SqlParameter {Value = entity.ciudad , ParameterName = "@ciudad" },
                new SqlParameter {Value = entity.pais , ParameterName = "@pais" },
                new SqlParameter {Value = entity.correo , ParameterName = "@correo" },

                };
            string messageError = string.Empty;
            connectionManager.AcctionRun(updateEntidad, ref messageError, parameters);
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
