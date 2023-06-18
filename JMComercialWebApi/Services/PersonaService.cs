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

        public Task Add(Persona persona)
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

        public async Task<Persona> Get(int id)
        {
            //Cambiar que se cree una nueva instancia cada vez que se quiere invocar un método
            switch (_database)
            {
                case SQLServer:
                    return await new SqlServerPersonaActions(_database.GetConectionString()).Get(id); 
                case PostgreSQL:
                    return await new PostgreSqlPersonaActions("").Get(id);
                default:
                    throw new NotImplementedException();
            }
        }

        public Task<IEnumerable<Persona>> GetAll()
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
