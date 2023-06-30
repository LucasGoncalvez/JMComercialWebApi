﻿using JMComercialWebApi.Data;
using JMComercialWebApi.Data.Databases.PostgreSQL;
using JMComercialWebApi.Data.Databases.SQLServer;
using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Gets;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Services
{
    public class PersonaService : IPersonaAction
    {
        private readonly IDatabase _database;
        public PersonaService(IDatabase database) 
        {
            _database = database;
        }

        public async Task<Persona?> Get(int id)
        {
            try
            {
                return await _database._personaActions.Get(id);
            }
            catch (Exception)
            {
                throw; //Se propaga la excepción a PersonaController
            }
        }

        public async Task<List<PersonaPreview>?> GetAll()
        {
            try
            {
                return await _database._personaActions.GetAll();
            }
            catch (Exception)
            {
                throw; //Se propaga la excepción a PersonaController
            }
        }

        public async Task<int?> Add(Persona persona)
        {
            try
            {
                return await _database._personaActions.Add(persona);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task AddContactos(List<PersonaContacto>? listaContacots)
        {
            throw new NotImplementedException();
        }

        public Task<int?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonaContacto>?> GetContactos(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> Update(Persona persona)
        {
            try
            {
                return await _database._personaActions.Update(persona);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
