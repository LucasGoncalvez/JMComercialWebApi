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

        public async Task<List<int?>?> AddContactos(List<PersonaContacto>? listaContacots)
        {
            try
            {
                return await _database._personaActions.AddContactos(listaContacots);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<int?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PersonaContactoDetail>?> GetContactos(int id)
        {
            try
            {
                return await _database._personaActions.GetContactos(id);
            }
            catch (Exception)
            {
                throw;
            }
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

        public async Task<int?> UpdateContactos(List<PersonaContacto> contacto)
        {
            try
            {
                return await _database._personaActions.UpdateContactos(contacto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteContacto(int contactoId)
        {
            try
            {
                await _database._personaActions.DeleteContacto(contactoId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
