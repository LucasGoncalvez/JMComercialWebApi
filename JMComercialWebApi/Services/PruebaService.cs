using JMComercialWebApi.Data;

namespace JMComercialWebApi.Services
{
    public class PruebaService
    {
        private readonly IDatabase _database;
        public PruebaService(IDatabase database)
        {
            _database = database;
        }

        public string Get()
        {
            if (_database is SQLServer)
                return "Es SQL Server";

            else if (_database is PostgreSQL)
                return "Es PostgreSQL";
            
            return "No es nada";
        }
    }
}
