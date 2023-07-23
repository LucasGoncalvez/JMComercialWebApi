using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Tables;
using JMComercialWebApi.Utils;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace JMComercialWebApi.Data.Databases.SQLServer
{
    public class SqlServerUbicacionActions : UbicacionBase
    {
        public SqlServerUbicacionActions(string connectionString) : base(connectionString)
        {
        }

        public override Task<Ciudad> AddCiudad(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public override Task<Departamento> AddDepartamento(Departamento departamento)
        {
            throw new NotImplementedException();
        }

        public override Task<Pais> AddPais(Pais pais)
        {
            throw new NotImplementedException();
        }

        public override Task<ZonaBarrio> AddZonaBarrio(ZonaBarrio barrio)
        {
            throw new NotImplementedException();
        }

        public override async Task<List<Ciudad>?> GetCiudades()
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();
            string script =
                $@"SELECT CD.[Id]
						  ,PA.[Id] PaisId
                          ,CD.[DepartamentoId]
                          ,CD.[Denominacion]
                          ,CD.[ISO]
                  FROM [dbo].[Ciudad] AS CD
				  INNER JOIN Departamento AS DP ON DP.Id = CD.DepartamentoId
				  INNER JOIN Pais AS PA ON PA.Id = DP.PaisId";
            using SqlCommand cmd = new(script, conn);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            List<Ciudad> listaCiudades = new();
            while (reader.Read())
            {
                listaCiudades.Add(new Ciudad
                {
                    Id = reader.GetInt32("Id"),
                    PaisId = reader.GetInt32("PaisId"),
                    DepartamentoId = reader.GetInt32("DepartamentoId"),
                    Denominacion = reader.GetString("Denominacion"),
                    ISO = Safer.SafeGetInt(reader, "ISO")
                });
            }
            return listaCiudades;
        }

        public override Task<List<Departamento>?> GetDepartamentos()
        {
            throw new NotImplementedException();
        }

        public override Task<List<Pais>?> GetPaises()
        {
            throw new NotImplementedException();
        }

        public override Task<List<ZonaBarrio>?> GetZonasBarrios()
        {
            throw new NotImplementedException();
        }

        public override Task<Ciudad> UpdateCiudad(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public override Task<Departamento> UpdateDepartamento(Departamento departamento)
        {
            throw new NotImplementedException();
        }

        public override Task<Pais> UpdatePais(Pais pais)
        {
            throw new NotImplementedException();
        }

        public override Task<ZonaBarrio> UpdateZonaBarrio(ZonaBarrio zonaBarrio)
        {
            throw new NotImplementedException();
        }
    }
}
