using JMComercialWebApi.Data;
using JMComercialWebApi.Data.Databases.PostgreSQL;
using JMComercialWebApi.Data.Databases.SQLServer;
using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Services
{
    public class PersonaService : IPersonaActions
    {
        private readonly IDatabase _database;
        public PersonaService(IDatabase database) 
        {
            _database = database;
        }

        public async Task<Persona> Get(int id)
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

        public async Task<IEnumerable<Persona>> GetAll()
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

        public async Task Add(Persona persona)
        {
            throw new NotImplementedException();
        }

        public Task AddContactos(List<PersonaContacto> listaContacots)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonaContacto>> GetContactos(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Persona persona)
        {
            throw new NotImplementedException();
        }
    }
}
