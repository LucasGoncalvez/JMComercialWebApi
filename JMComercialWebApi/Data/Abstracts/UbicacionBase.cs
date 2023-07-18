using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Abstracts
{
    public abstract class UbicacionBase : IUbicacionesAction
    {
        public readonly string _connectionString;
        public UbicacionBase(string connectionString)
        {
            _connectionString = connectionString;
        }
        public abstract Task<Ciudad> AddCiudad(Ciudad ciudad);

        public abstract Task<Departamento> AddDepartamento(Departamento departamento);

        public abstract Task<Pais> AddPais(Pais pais);

        public abstract Task<ZonaBarrio> AddZonaBarrio(ZonaBarrio barrio);

        public abstract Task<List<Ciudad>?> GetCiudades();

        public abstract Task<List<Departamento>?> GetDepartamentos();

        public abstract Task<List<Pais>?> GetPaises();

        public abstract Task<List<ZonaBarrio>?> GetZonasBarrios();

        public abstract Task<Ciudad> UpdateCiudad(Ciudad ciudad);

        public abstract Task<Departamento> UpdateDepartamento(Departamento departamento);

        public abstract Task<Pais> UpdatePais(Pais pais);

        public abstract Task<ZonaBarrio> UpdateZonaBarrio(ZonaBarrio zonaBarrio);
    }
}
