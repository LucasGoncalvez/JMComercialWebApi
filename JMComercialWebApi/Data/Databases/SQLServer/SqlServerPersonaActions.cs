using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Tables;
using Microsoft.Data.SqlClient;
using JMComercialWebApi.Utils;
using System.Data;
using JMComercialWebApi.Models.Gets;
using JMComercialWebApi.Models.Details;

namespace JMComercialWebApi.Data.Databases.SQLServer
{
    public class SqlServerPersonaActions : PersonaBase
    {
        public SqlServerPersonaActions(string connectionString) : base(connectionString)
        {
        }

        #region Get
        public override async Task<PersonaDetail?> Get(int id)
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
					  LEFT JOIN TipoDocumento AS TD ON TD.Id = P.TipoDocumentoId
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
            PersonaDetail? persona = null;
            if (reader.Read())
            {
                persona = new()
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
            }
            return persona;
        }
        #endregion

        #region GetAll
        public override async Task<List<PersonaPreview>?> GetAll()
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();
            string script =
                    @$"SELECT P.[Id] Id
                          ,P.[Nombre] Nombre
                          ,P.[Apellido] Apellido
						  ,TD.[Denominacion] TipoDocumento
                          ,P.[NumeroDocumento] NumeroDocumento
						  ,CI.Denominacion Ciudad
                      FROM [dbo].[Persona] AS P
					  LEFT JOIN TipoDocumento AS TD ON TD.Id = P.TipoDocumentoId
					  INNER JOIN Ciudad AS CI ON CI.Id = P.CiudadId";
            using SqlCommand cmd = new(script, conn);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            List<PersonaPreview> personasPreview = new();
            while (reader.Read())
            {
                personasPreview.Add(new PersonaPreview
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    Apellido = Safer.SafeGetString(reader, "Apellido"),
                    TipoDocumento = Safer.SafeGetString(reader, "TipoDocumento"),
                    NumeroDocumento = Safer.SafeGetString(reader, "NumeroDocumento"),
                    Ciudad = reader.GetString("Ciudad")
                });
            }
            return personasPreview;
        }
        #endregion

        #region Add
        public override async Task<int?> Add(Persona persona)
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();
            string script =
                $@"INSERT INTO [dbo].[Persona]
                       ([Nombre]
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
                       ,[Habilitado])
                 OUTPUT INSERTED.[Id]
                 VALUES
                       (@Nombre
                       ,@Apellido
                       ,@TipoDocumentoId
                       ,@NumeroDocumento
                       ,@PaisId
                       ,@DepartamentoId
                       ,@CiudadId
                       ,@ZonaBarrioId
                       ,@Direccion
                       ,@Geolocalizacion
                       ,@LoginIdAlta
                       ,@FechaAlta
                       ,@LoginIdModificacion
                       ,@FechaUltModificacion
                       ,@Habilitado)";
            using SqlCommand cmd = new(script, conn);
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = persona.Nombre;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = persona.Apellido ?? (object)DBNull.Value;
            cmd.Parameters.Add("@TipoDocumentoId", SqlDbType.Int).Value = persona.TipoDocumentoId ?? (object)DBNull.Value;
            cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar).Value = persona.NumeroDocumento ?? (object)DBNull.Value;
            cmd.Parameters.Add("@PaisId", SqlDbType.Int).Value = persona.PaisId;
            cmd.Parameters.Add("@DepartamentoId", SqlDbType.Int).Value = persona.DepartamentoId;
            cmd.Parameters.Add("@CiudadId", SqlDbType.Int).Value = persona.CiudadId;
            cmd.Parameters.Add("@ZonaBarrioId", SqlDbType.Int).Value = persona.ZonaBarrioId ?? (object)DBNull.Value;
            cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = persona.Direccion ?? (object)DBNull.Value;
            cmd.Parameters.Add("@Geolocalizacion", SqlDbType.VarChar).Value = persona.Geolocalizacion ?? (object)DBNull.Value;
            cmd.Parameters.Add("@LoginIdAlta", SqlDbType.Int).Value = persona.LoginIdAlta ?? (object)DBNull.Value;
            cmd.Parameters.Add("@FechaAlta", SqlDbType.DateTime).Value = persona.FechaAlta ?? (object)DBNull.Value;
            cmd.Parameters.Add("@LoginIdModificacion", SqlDbType.Int).Value = persona.LoginIdUltMod ?? (object)DBNull.Value;
            cmd.Parameters.Add("@FechaUltModificacion", SqlDbType.DateTime).Value = persona.FechaUltMod ?? (object)DBNull.Value;
            cmd.Parameters.Add("@Habilitado", SqlDbType.Bit).Value = persona.Habilitado;
            int? newId = (int?)await cmd.ExecuteScalarAsync();//Retorna el id con que se agregó a la persona
            return newId;
        }
        #endregion

        #region Update
        public override async Task<int?> Update(Persona persona)
        {
            /*Retorna la cantidad de registros actualizados*/
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();
            string script =
                    $@"UPDATE [dbo].[Persona]
                       SET [Nombre] = @Nombre
                          ,[Apellido] = @Apellido
                          ,[TipoDocumentoId] = @TipoDocumentoId
                          ,[NumeroDocumento] = @NumeroDocumento
                          ,[PaisId] = @PaisId
                          ,[DepartamentoId] = @DepartamentoId
                          ,[CiudadId] = @CiudadId
                          ,[ZonaBarrioId] = @ZonaBarrioId
                          ,[Direccion] = @Direccion
                          ,[Geolocalizacion] = @Geolocalizacion
                          ,[LoginIdAlta] = @LoginIdAlta
                          ,[FechaAlta] = @FechaAlta
                          ,[LoginIdModificacion] = @LoginIdModificacion
                          ,[FechaUltModificacion] = @FechaUltModificacion
                          ,[Habilitado] = @Habilitado
                       WHERE Id = @PersonaId";
            using SqlCommand cmd = new(script, conn);
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = persona.Nombre;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = persona.Apellido ?? (object)DBNull.Value;
            cmd.Parameters.Add("@TipoDocumentoId", SqlDbType.Int).Value = persona.TipoDocumentoId ?? (object)DBNull.Value;
            cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar).Value = persona.NumeroDocumento ?? (object)DBNull.Value;
            cmd.Parameters.Add("@PaisId", SqlDbType.Int).Value = persona.PaisId;
            cmd.Parameters.Add("@DepartamentoId", SqlDbType.Int).Value = persona.DepartamentoId;
            cmd.Parameters.Add("@CiudadId", SqlDbType.Int).Value = persona.CiudadId;
            cmd.Parameters.Add("@ZonaBarrioId", SqlDbType.Int).Value = persona.ZonaBarrioId ?? (object)DBNull.Value;
            cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = persona.Direccion ?? (object)DBNull.Value;
            cmd.Parameters.Add("@Geolocalizacion", SqlDbType.VarChar).Value = persona.Geolocalizacion ?? (object)DBNull.Value;
            cmd.Parameters.Add("@LoginIdAlta", SqlDbType.Int).Value = persona.LoginIdAlta ?? (object)DBNull.Value;
            cmd.Parameters.Add("@FechaAlta", SqlDbType.DateTime).Value = persona.FechaAlta ?? (object)DBNull.Value;
            cmd.Parameters.Add("@LoginIdModificacion", SqlDbType.Int).Value = persona.LoginIdUltMod ?? (object)DBNull.Value;
            cmd.Parameters.Add("@FechaUltModificacion", SqlDbType.DateTime).Value = persona.FechaUltMod ?? (object)DBNull.Value;
            cmd.Parameters.Add("@Habilitado", SqlDbType.Bit).Value = persona.Habilitado;
            cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = persona.Id;

            int result = await cmd.ExecuteNonQueryAsync();
            return result;
        }
        #endregion

        #region Delete
        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetContactos
        public override async Task<List<PersonaContactoDetail>?> GetContactos(int id)
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();
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
                      WHERE PersonaId = @PersonaId";
            using SqlCommand cmd = new(scriptContact, conn);
            cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = id;
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            List<PersonaContactoDetail> personaContactos = new(); //Si no hay contactos, que retorne vacío.
            while (reader.Read())
            {
                personaContactos.Add(new PersonaContactoDetail
                {
                    Id = reader.GetInt32("Id"),
                    PersonaId = reader.GetInt32("PersonaId"),
                    TipoContactoId = reader.GetInt32("TipoContactoId"),
                    TipoContacto = reader.GetString("TipoContacto"),
                    Valor = reader.GetString("Valor"),
                    Descripcion = Safer.SafeGetString(reader, "Descripcion"),
                    Habilitado = Safer.SafeGetBoolean(reader, "Habilitado")
                });
            }
            return personaContactos;
        }
        #endregion

        #region AddContactos
        public override async Task<List<int?>?> AddContactos(List<PersonaContacto>? listaContactos)
        {
            /*Recibe una lista de contactos que se agregaran a una persona en específico según el id que se reciba.
             Retornará la lista de id's que corresponderán a los contactos agregados.*/
            if (listaContactos == null || !listaContactos.Any())
                return null;

            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();
            string script =
                    $@"INSERT INTO [dbo].[PersonaContacto]
                            ([PersonaId]
                            ,[TipoContactoId]
                            ,[Valor]
                            ,[Descripcion]
                            ,[Habilitado])
                     OUTPUT INSERTED.[Id]
                     VALUES
                            (@PersonaId
                            ,@TipoContactoId
                            ,@Valor
                            ,@Descripcion
                            ,@Habilitado)";
            using SqlCommand cmd = new(script, conn);
            List<int?>? contactosId = new();

            //Se crean los parametros
            cmd.Parameters.Add("@PersonaId", SqlDbType.Int);
            cmd.Parameters.Add("@TipoContactoId", SqlDbType.Int);
            cmd.Parameters.Add("@Valor", SqlDbType.VarChar);
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            cmd.Parameters.Add("@Habilitado", SqlDbType.Bit);

            //Se cargan los parametros con los valores correspondientes
            foreach (var contacto in listaContactos)
            {
                cmd.Parameters["@PersonaId"].Value = contacto.PersonaId;
                cmd.Parameters["@TipoContactoId"].Value = contacto.TipoContactoId ?? (object)DBNull.Value;
                cmd.Parameters["@Valor"].Value = contacto.Valor ?? (object)DBNull.Value;
                cmd.Parameters["@Descripcion"].Value = contacto.Descripcion ?? (object)DBNull.Value;
                cmd.Parameters["@Habilitado"].Value = contacto.Habilitado ?? (object)DBNull.Value;

                int? newId = (int?)await cmd.ExecuteScalarAsync();//Retorna el id con que se agregó
                contactosId.Add(newId);//Se agrega el nuevo id a la lista para retornarlos
            }
            return contactosId;
        }
        #endregion

        #region UpdateContactos
        public override Task<int?> UpdateContactos(List<PersonaContacto> contacto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region DeleteContactos
        public override Task DeleteContacto(int contactoId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
