using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Tables;
using System.Globalization;
using System.Transactions;

namespace JMComercialWebApi.Data.Databases.SQLServer
{
    public class SqlServerPersonaActions : PersonaBase
    {
        public SqlServerPersonaActions(string connectionString) : base(connectionString)
        {
        }

        public override Task Add(Persona entity)
        {
            throw new NotImplementedException();
        }

        public override Task AddContactos(List<PersonaContacto> listaContacots)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Persona> Get(int id)
        {
            try
            {
                Console.WriteLine(_connectionString);
                return new Persona
                {
                    Id = id,
                    Nombre = "SQL Server"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<IEnumerable<Persona>> GetAll()
        {
            Console.WriteLine(_connectionString);
            List<Persona> personas = new();
            for(int i = 0; i < 10; i++)
            {
                personas.Add(new Persona
                {
                    Id = i + 1,
                    Nombre = "SQL Server"
                });
            }
            return personas;
        }

        public override Task<IEnumerable<PersonaContacto>> GetContactos(int id)
        {
            throw new NotImplementedException();
        }

        public override Task Update(Persona entity)
        {
            throw new NotImplementedException();
        }
    }
}
