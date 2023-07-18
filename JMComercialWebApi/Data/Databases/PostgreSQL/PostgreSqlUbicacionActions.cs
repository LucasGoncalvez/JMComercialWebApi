using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Databases.PostgreSQL
{
    public class PostgreSqlUbicacionActions : UbicacionBase
    {
        public PostgreSqlUbicacionActions(string connectionString) : base(connectionString)
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

        public override Task<List<Ciudad>?> GetCiudades()
        {
            throw new NotImplementedException();
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
