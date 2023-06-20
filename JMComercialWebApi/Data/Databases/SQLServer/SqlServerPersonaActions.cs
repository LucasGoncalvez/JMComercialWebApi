using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Tables;
using Microsoft.Data.SqlClient;
using JMComercialWebApi.Utils;
using System.Data;

namespace JMComercialWebApi.Data.Databases.SQLServer
{
    public class SqlServerPersonaActions : PersonaBase
    {
        public SqlServerPersonaActions(string connectionString) : base(connectionString)
        {
        }

        public override Task Add(Persona entity)
        {
            throw new NotImplementedException();
        }

        public override Task AddContactos(List<PersonaContacto> listaContacots)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        #region Get
        public override async Task<Persona?> Get(int id)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();
                string script =
                    @$"SELECT [Id]
                          ,[Nombre]
                          ,[Apellido]
                          ,[TipoDocumentoId]
                          ,[NumeroDocumento]
                          ,[PaisId]
                          ,[DepartamentoId]
                          ,[CiudadId]
                          ,[ZonaBarrioId]
                          ,[Direccion]
                          ,[Geolocalizacion]
                          ,[LoginIdAlta]
                          ,[FechaAlta]
                          ,[LoginIdModificacion]
                          ,[FechaUltModificacion]
                          ,[Habilitado]
                      FROM [dbo].[Persona]
                      WHERE [Id] = @PersonaId";
                using SqlCommand cmd = new(script, conn);
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = id;
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.Read())
                {
                    Persona persona = new()
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = Safer.SafeGetString(reader, 2),
                        TipoDocumentoId = Safer.SafeGetInt(reader, 3),
                        NumeroDocumento = Safer.SafeGetString(reader, 4),
                        PaisId = reader.GetInt32(5),
                        DepartamentoId = reader.GetInt32(6),
                        CiudadId = reader.GetInt32(7),
                        ZonaBarrioId = Safer.SafeGetInt(reader, 8),
                        Direccion = Safer.SafeGetString(reader, 9),
                        Geolocalizacion = Safer.SafeGetString(reader, 10),
                        LoginIdAlta = Safer.SafeGetInt(reader, 11),
                        FechaAlta = Safer.SafeGetDateTime(reader, 12),
                        LoginIdUltMod = Safer.SafeGetInt(reader, 13),
                        FechaUltMod = Safer.SafeGetDateTime(reader, 14),
                        Habilitado = reader.GetBoolean(15)
                    };
                    return persona;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public override async Task<IEnumerable<Persona>?> GetAll()
        {
            Console.WriteLine(_connectionString);
            List<Persona> personas = new();
            for(int i = 0; i < 10; i++)
            {
                personas.Add(new Persona
                {
                    Id = i + 1,
                    Nombre = "SQL Server"
                });
            }
            return personas;
        }

        public override Task<IEnumerable<PersonaContacto>?> GetContactos(int id)
        {
            throw new NotImplementedException();
        }

        public override Task Update(Persona entity)
        {
            throw new NotImplementedException();
        }
    }
}
