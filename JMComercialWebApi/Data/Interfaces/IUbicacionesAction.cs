using JMComercialWebApi.Models.Details;
using JMComercialWebApi.Models.Gets;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Interfaces
{
    public interface IUbicacionesAction
    {
        public Task<List<Pais>?> GetPaises();
        public Task<List<Departamento>?> GetDepartamentos();
        public Task<List<Ciudad>?> GetCiudades();
        public Task<List<ZonaBarrio>?> GetZonasBarrios();

        public Task<Pais> AddPais(Pais pais);
        public Task<Departamento> AddDepartamento(Departamento departamento);
        public Task<Ciudad> AddCiudad(Ciudad ciudad);
        public Task<ZonaBarrio> AddZonaBarrio(ZonaBarrio barrio);

        public Task<Pais> UpdatePais(Pais pais);
        public Task<Departamento> UpdateDepartamento(Departamento departamento);
        public Task<Ciudad> UpdateCiudad(Ciudad ciudad);
        public Task<ZonaBarrio> UpdateZonaBarrio(ZonaBarrio zonaBarrio);
    }
}
