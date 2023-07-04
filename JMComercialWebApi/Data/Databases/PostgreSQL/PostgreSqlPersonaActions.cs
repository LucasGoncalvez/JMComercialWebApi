using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Details;
using JMComercialWebApi.Models.Gets;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Databases.PostgreSQL
{
    public class PostgreSqlPersonaActions : PersonaBase
    {
        public PostgreSqlPersonaActions(string connectionString) : base(connectionString)
        {
        }

        public override Task<int?> Add(Persona entity)
        {
            throw new NotImplementedException();
        }

        public override Task<List<int?>?> AddContactos(List<PersonaContacto>? listaContacots)
        {
            throw new NotImplementedException();
        }

        public override Task<int?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteContacto(int contactoId)
        {
            throw new NotImplementedException();
        }

        public override async Task<PersonaDetail?> Get(int id)
        {
            return new PersonaDetail
            {
                Id = id,
                Nombre = "PostgreSQL"
            };
        }

        public override Task<List<PersonaPreview>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<List<PersonaContactoDetail>?> GetContactos(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<int?> Update(Persona entity)
        {
            throw new NotImplementedException();
        }

        public override Task<int?> UpdateContactos(List<PersonaContacto> contacto)
        {
            throw new NotImplementedException();
        }
    }
}
