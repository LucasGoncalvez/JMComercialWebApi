using JMComercialWebApi.Data.Abstracts;
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

        public override Task AddContactos(List<PersonaContacto>? listaContacots)
        {
            throw new NotImplementedException();
        }

        public override Task<int?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Persona?> Get(int id)
        {
            return new Persona
            {
                Id = id,
                Nombre = "PostgreSQL"
            };
        }

        public override Task<List<PersonaPreview>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<List<PersonaContacto>?> GetContactos(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<int?> Update(Persona entity)
        {
            throw new NotImplementedException();
        }
    }
}
