using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Tables;
using JMComercialWebApi.Utils;
using Microsoft.Data.SqlClient;
using System.Data;

namespace JMComercialWebApi.Data.Databases.SQLServer
{
    public class SqlServerDocumentoAction : TipoDocumentoBase
    {
        public SqlServerDocumentoAction(string connectionString) : base(connectionString)
        {
        }

        public override async Task<List<TipoDocumento>?> GetAll()
        {
            //List<TipoDocumento> listTipoDocumento = new()
            //{
            //    new TipoDocumento { Id = 1, Denominacion = "Cédula de identidad", Abreviatura = "", Habilitado = true },
            //    new TipoDocumento { Id = 1, Denominacion = "Pasaporte", Abreviatura = "", Habilitado = true },
            //    new TipoDocumento { Id = 1, Denominacion = "Registro Único del Contribuyente", Abreviatura = "", Habilitado = true },
            //    new TipoDocumento { Id = 1, Denominacion = "Registro de conducir", Abreviatura = "", Habilitado = true },
            //    new TipoDocumento { Id = 1, Denominacion = "Cédula de identidad extranjera", Abreviatura = "", Habilitado = true }
            //};
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();
            string script = 
                $@"SELECT [Id]
                          ,[Denominacion]
                          ,[Abreviatura]
                          ,[Habilitado]
                  FROM [dbo].[TipoDocumento]";
            using SqlCommand command = new(script, conn);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            List<TipoDocumento> listTipoDocumento = new();
            while (reader.Read())
            {
                listTipoDocumento.Add(new TipoDocumento()
                {
                    Id = reader.GetInt32("Id"),
                    Denominacion = reader.GetString("Denominacion"),
                    Abreviatura = Safer.SafeGetString(reader, "Abreviatura"),
                    Habilitado = reader.GetBoolean("Habilitado")
                });
            }
            return listTipoDocumento;
        }

        public override Task<TipoDocumento?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<int?> Add(TipoDocumento entity)
        {
            throw new NotImplementedException();
        }

        public override Task<int?> Update(TipoDocumento entity)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
