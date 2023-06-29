using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Gets;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Abstracts
{
    public abstract class PersonaBase : IPersonaAction
    {
        public readonly string _connectionString;
        public PersonaBase(string connectionString)
        {
            _connectionString = connectionString;
        }
        public abstract Task Add(Persona entity);

        public abstract Task AddContactos(List<PersonaContacto>? listaContacots);

        public abstract Task Delete(int id);

        public abstract Task<Persona?> Get(int id);

        public abstract Task<List<PersonaPreview>?> GetAll();

        public abstract Task<List<PersonaContacto>?> GetContactos(int id);

        public abstract Task Update(Persona entity);
    }
}
