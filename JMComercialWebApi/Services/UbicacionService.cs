using JMComercialWebApi.Data;
using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Services
{
    public class UbicacionService : IUbicacionesAction
    {
        private readonly IDatabase _database;
        public UbicacionService(IDatabase database)
        {
            _database = database;
        }
        public Task<Ciudad> AddCiudad(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public Task<Departamento> AddDepartamento(Departamento departamento)
        {
            throw new NotImplementedException();
        }

        public Task<Pais> AddPais(Pais pais)
        {
            throw new NotImplementedException();
        }

        public Task<ZonaBarrio> AddZonaBarrio(ZonaBarrio barrio)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ciudad>?> GetCiudades()
        {
            return await _database._ubicacionAction.GetCiudades();
        }

        public Task<List<Departamento>?> GetDepartamentos()
        {
            throw new NotImplementedException();
        }

        public Task<List<Pais>?> GetPaises()
        {
            throw new NotImplementedException();
        }

        public Task<List<ZonaBarrio>?> GetZonasBarrios()
        {
            throw new NotImplementedException();
        }

        public Task<Ciudad> UpdateCiudad(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public Task<Departamento> UpdateDepartamento(Departamento departamento)
        {
            throw new NotImplementedException();
        }

        public Task<Pais> UpdatePais(Pais pais)
        {
            throw new NotImplementedException();
        }

        public Task<ZonaBarrio> UpdateZonaBarrio(ZonaBarrio zonaBarrio)
        {
            throw new NotImplementedException();
        }
    }
}
