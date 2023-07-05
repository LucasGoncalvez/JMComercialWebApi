using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Details;
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

        public abstract Task<PersonaDetail?> Get(int id);
        public abstract Task<List<PersonaPreview>?> GetAll();
        public abstract Task<int?> Add(Persona entity);
        public abstract Task<int?> Update(Persona entity);
        public abstract Task Delete(int id);

        public abstract Task<List<PersonaContactoDetail>?> GetContactos(int id);
        public abstract Task<List<int?>?> AddContactos(List<PersonaContacto>? listaContacots);
        public abstract Task<int?> UpdateContactos(List<PersonaContacto> contacto);
        public abstract Task DeleteContacto(int contactoId);
    }
}
