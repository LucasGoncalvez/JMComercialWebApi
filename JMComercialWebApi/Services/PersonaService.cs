using JMComercialWebApi.Data;
using JMComercialWebApi.Data.Databases.PostgreSQL;
using JMComercialWebApi.Data.Databases.SQLServer;
using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Details;
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

        public async Task<PersonaDetail?> Get(int id)
        {
            return await _database._personaActions.Get(id);
        }

        public async Task<List<PersonaPreview>?> GetAll()
        {
            return await _database._personaActions.GetAll();
        }

        public async Task<int?> Add(Persona persona)
        {
            return await _database._personaActions.Add(persona);
        }

        public async Task<int?> Update(Persona persona)
        {
            return await _database._personaActions.Update(persona);
        }

        public Task<int?> Delete(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<List<PersonaContactoDetail>?> GetContactos(int id)
        {
            return await _database._personaActions.GetContactos(id);
        }

        public async Task<List<int?>?> AddContactos(List<PersonaContacto>? listaContacots)
        {
            return await _database._personaActions.AddContactos(listaContacots);
        }

        public async Task<int?> UpdateContactos(List<PersonaContacto> contacto)
        {
            return await _database._personaActions.UpdateContactos(contacto);
        }

        public async Task DeleteContacto(int contactoId)
        {
            await _database._personaActions.DeleteContacto(contactoId);
        }
    }
}
