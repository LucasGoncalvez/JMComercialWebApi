using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Tables;
using Microsoft.Data.SqlClient;
using JMComercialWebApi.Utils;
using System.Data;
using JMComercialWebApi.Models.Gets;

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
                    @$"SELECT P.[Id] Id
                          ,P.[Nombre] Nombre
                          ,P.[Apellido] Apellido
                          ,P.[TipoDocumentoId] TipoDocumentoId
						  ,TD.[Denominacion] TipoDocumento
                          ,P.[NumeroDocumento] NumeroDocumento
                          ,P.[PaisId] PaisId
						  ,Pais.Denominacion Pais
                          ,P.[DepartamentoId] DepartamentoId
						  ,DP.Denominacion Departamento
                          ,P.[CiudadId] CiudadId
						  ,CI.Denominacion Ciudad
                          ,P.[ZonaBarrioId] ZonaBarrioId
						  ,ZB.Denominacion ZonaBarrio
                          ,P.[Direccion] Direccion
                          ,P.[Geolocalizacion] Geolocalizacion
                          ,P.[LoginIdAlta] LoginIdAlta
						  ,LGA.NombreAcceso LoginAlta
                          ,P.[FechaAlta] FechaAlta
                          ,P.[LoginIdModificacion] LoginIdUltMod
						  ,LGM.NombreAcceso LoginUltMod
                          ,P.[FechaUltModificacion] FechaUltMod
                          ,P.[Habilitado] Habilitado
                      FROM [dbo].[Persona] AS P
					  INNER JOIN TipoDocumento AS TD ON TD.Id = P.TipoDocumentoId
					  INNER JOIN Pais ON Pais.Id = P.PaisId
					  INNER JOIN Departamento AS DP ON DP.Id = P.DepartamentoId
					  INNER JOIN Ciudad AS CI ON CI.Id = P.CiudadId
					  LEFT JOIN ZonaBarrio AS ZB ON ZB.Id = P.ZonaBarrioId
					  LEFT JOIN [Login] AS LGA ON LGA.Id = P.LoginIdAlta
					  LEFT JOIN [Login] AS LGM ON LGM.Id = P.LoginIdModificacion
                      WHERE P.[Id] = @PersonaId";
                using SqlCommand cmd = new(script, conn);
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = id;
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.Read())
                {
                    Persona persona = new()
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre"),
                        Apellido = Safer.SafeGetString(reader, "Apellido"),
                        TipoDocumentoId = Safer.SafeGetInt(reader, "TipoDocumentoId"),
                        TipoDocumento = Safer.SafeGetString(reader, "TipoDocumento"),
                        NumeroDocumento = Safer.SafeGetString(reader, "NumeroDocumento"),
                        PaisId = reader.GetInt32("PaisId"),
                        Pais = reader.GetString("Pais"),
                        DepartamentoId = reader.GetInt32("DepartamentoId"),
                        Departamento = reader.GetString("Departamento"),
                        CiudadId = reader.GetInt32("CiudadId"),
                        Ciudad = reader.GetString("Ciudad"),
                        ZonaBarrioId = Safer.SafeGetInt(reader, "ZonaBarrioId"),
                        ZonaBarrio = Safer.SafeGetString(reader, "ZonaBarrio"),
                        Direccion = Safer.SafeGetString(reader, "Direccion"),
                        Geolocalizacion = Safer.SafeGetString(reader, "Geolocalizacion"),
                        LoginIdAlta = Safer.SafeGetInt(reader, "LoginIdAlta"),
                        LoginAlta = Safer.SafeGetString(reader, "LoginAlta"),
                        FechaAlta = Safer.SafeGetDateTime(reader, "FechaAlta"),
                        LoginIdUltMod = Safer.SafeGetInt(reader, "LoginIdUltMod"),
                        LoginUltMod = Safer.SafeGetString(reader, "LoginUltMod"),
                        FechaUltMod = Safer.SafeGetDateTime(reader, "FechaUltMod"),
                        Habilitado = reader.GetBoolean("Habilitado")
                    };
                    await reader.CloseAsync();
                    //Obtenemos todos los contactos registrados para la persona
                    string scriptContact =
                    $@"SELECT PC.[Id] Id
                                 ,PC.[PersonaId] PersonaId
                                 ,PC.[TipoContactoId] TipoContactoId
                           	     ,TC.Denominacion TipoContacto
                                 ,PC.[Valor] Valor
                                 ,PC.[Descripcion] Descripcion
                                 ,PC.[Habilitado] Habilitado
                      FROM [dbo].[PersonaContacto] PC
                      INNER JOIN TipoContacto AS TC ON TC.Id = PC.TipoContactoId
                      WHERE PersonaId = @PersonaId AND PC.Habilitado = 1";
                    using SqlCommand cmdContact = new(scriptContact, conn);
                    cmdContact.Parameters.Add("@PersonaId", SqlDbType.Int).Value = id;
                    using SqlDataReader readerContact = await cmdContact.ExecuteReaderAsync();
                    List<PersonaContacto>? personaContactos = new();
                    while (readerContact.Read())
                    {
                        personaContactos.Add(new PersonaContacto
                        {
                            Id = readerContact.GetInt32("Id"),
                            PersonaId = readerContact.GetInt32("PersonaId"),
                            TipoContactoId = readerContact.GetInt32("TipoContactoId"),
                            TipoContacto = readerContact.GetString("TipoContacto"),
                            Valor = readerContact.GetString("Valor"),
                            Descripcion = Safer.SafeGetString(readerContact, "Descripcion"),
                            Habilitado = Safer.SafeGetBoolean(readerContact, "Habilitado")
                        });
                    }
                    persona.Contactos = personaContactos;
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

        public override async Task<List<PersonaPreview>?> GetAll()
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();
                string script =
                    @$"SELECT P.[Id] Id
                          ,P.[Nombre] Nombre
                          ,P.[Apellido] Apellido
                          ,P.[TipoDocumentoId] TipoDocumentoId
						  ,TD.[Denominacion] TipoDocumento
                          ,P.[NumeroDocumento] NumeroDocumento
                          ,P.[CiudadId] CiudadId
						  ,CI.Denominacion Ciudad
                      FROM [dbo].[Persona] AS P
					  INNER JOIN TipoDocumento AS TD ON TD.Id = P.TipoDocumentoId
					  INNER JOIN Ciudad AS CI ON CI.Id = P.CiudadId
                      WHERE P.[Habilitado] = 1";
                using SqlCommand cmd = new(script, conn);
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                List<PersonaPreview> personas = new();
                while(reader.Read())
                {
                    personas.Add(new PersonaPreview
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre"),
                        Apellido = Safer.SafeGetString(reader, "Apellido"),
                        TipoDocumentoId = Safer.SafeGetInt(reader, "TipoDocumentoId"),
                        TipoDocumento = Safer.SafeGetString(reader, "TipoDocumento"),
                        NumeroDocumento = Safer.SafeGetString(reader, "NumeroDocumento"),
                        CiudadId = reader.GetInt32("CiudadId"),
                        Ciudad = reader.GetString("Ciudad")
                    });
                }
                return personas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<PersonaContacto>?> GetContactos(int id)
        {
            throw new NotImplementedException();
        }

        public override Task Update(Persona entity)
        {
            throw new NotImplementedException();
        }
    }
}
