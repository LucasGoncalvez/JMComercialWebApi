﻿using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Tables;

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

        public override async Task<Persona> Get(int id)
        {
            return new Persona
            {
                Id = id,
                Nombre = "SQL Server"
            };
        }

        public override Task<IEnumerable<Persona>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<PersonaContacto>> GetContactos(int id)
        {
            throw new NotImplementedException();
        }

        public override Task Update(Persona entity)
        {
            throw new NotImplementedException();
        }
    }
}
