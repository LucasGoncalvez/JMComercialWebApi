using JMComercialWebApi.Data;
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

        public Task Add(Persona entity)
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

        public Task<Persona> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Persona>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonaContacto>> GetContactos(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Persona entity)
        {
            throw new NotImplementedException();
        }
    }
}
