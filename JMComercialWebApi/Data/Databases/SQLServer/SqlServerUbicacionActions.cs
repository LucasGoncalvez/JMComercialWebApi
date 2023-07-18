using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Tables;
using System.Collections.Generic;

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
            List<Ciudad> ciudades = new()
            {
                new Ciudad { Id = 1, DepartamentoId = 1, Denominacion = "Areguá", ISO = null },
                new Ciudad { Id = 2, DepartamentoId = 1, Denominacion = "Ypane", ISO = null },
                new Ciudad { Id = 3, DepartamentoId = 1, Denominacion = "Capiatá", ISO = null },
                new Ciudad { Id = 4, DepartamentoId = 1, Denominacion = "San Lorenzo", ISO = null },
                new Ciudad { Id = 5, DepartamentoId = 1, Denominacion = "Fernando de la Mora", ISO = null },
                new Ciudad { Id = 6, DepartamentoId = 1, Denominacion = "Asunción", ISO = null },
                new Ciudad { Id = 7, DepartamentoId = 1, Denominacion = "Ñemby", ISO = null },
                new Ciudad { Id = 8, DepartamentoId = 1, Denominacion = "Itaugua", ISO = null },
                new Ciudad { Id = 9, DepartamentoId = 1, Denominacion = "Luque", ISO = null },
                new Ciudad { Id = 10, DepartamentoId = 1, Denominacion = "Lambare", ISO = null }
            };
            return ciudades;
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
