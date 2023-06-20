using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Abstracts
{
    public abstract class PersonaBase : IPersonaActions
    {
        public readonly string _connectionString;
        public PersonaBase(string connectionString)
        {
            _connectionString = connectionString;
        }
        public abstract Task Add(Persona entity);

        public abstract Task AddContactos(List<PersonaContacto> listaContacots);

        public abstract Task Delete(int id);

        public abstract Task<Persona?> Get(int id);

        public abstract Task<IEnumerable<Persona>?> GetAll();

        public abstract Task<IEnumerable<PersonaContacto>?> GetContactos(int id);

        public abstract Task Update(Persona entity);
    }
}
