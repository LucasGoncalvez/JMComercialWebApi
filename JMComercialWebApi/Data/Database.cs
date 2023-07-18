using JMComercialWebApi.Data.Databases.PostgreSQL;
using JMComercialWebApi.Data.Databases.SQLServer;

namespace JMComercialWebApi.Data
{
    public class SQLServer : IDatabase
    {
        private readonly IConfiguration _configuration;
        public SQLServer(IConfiguration configuration) 
        {
            _configuration = configuration;
            _personaActions = new SqlServerPersonaActions(configuration.GetConnectionString("SqlServer"));
            _ubicacionAction = new SqlServerUbicacionActions(configuration.GetConnectionString("SqlServer"));
        }

        public dynamic _personaActions { get; set; }
        public dynamic _ubicacionAction { get; set; }

        public string GetConectionString()
        {
            return _configuration.GetValue<string>("ConnectionStrings:SqlServer");
        }
    }

    public class PostgreSQL : IDatabase
    {
        private readonly IConfiguration _configuration;
        public PostgreSQL(IConfiguration configuration)
        {
            _configuration = configuration;
            _personaActions = new PostgreSqlPersonaActions(configuration.GetConnectionString("SqlServer"));
            _ubicacionAction = new PostgreSqlUbicacionActions(configuration.GetConnectionString("SqlServer"));
        }

        public dynamic _personaActions { get; set; }
        public dynamic _ubicacionAction { get; set; }

        public string GetConectionString()
        {
            return _configuration.GetValue<string>("ConnectionStrings:PostgreSql");
        }
    }

    public class Oracle : IDatabase
    {
        private readonly IConfiguration _configuration;
        public Oracle(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public dynamic _personaActions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic _ubicacionAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetConectionString()
        {
            return _configuration.GetValue<string>("ConnectionStrings:Oracle");
        }
    }

    public class MySQL : IDatabase
    {
        private readonly IConfiguration _configuration;
        public MySQL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public dynamic _personaActions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic _ubicacionAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetConectionString()
        {
            return _configuration.GetValue<string>("ConnectionStrings:MySql");
        }
    }

    public class MariaDB : IDatabase
    {
        private readonly IConfiguration _configuration;
        public MariaDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public dynamic _personaActions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic _ubicacionAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetConectionString()
        {
            return _configuration.GetValue<string>("ConnectionStrings:");
        }
    }

    public class Db2 : IDatabase
    {
        private readonly IConfiguration _configuration;
        public Db2(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public dynamic _personaActions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic _ubicacionAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetConectionString()
        {
            return _configuration.GetValue<string>("ConnectionStrings:");
        }
    }

    public class SQLite : IDatabase
    {
        private readonly IConfiguration _configuration;
        public SQLite(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public dynamic _personaActions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic _ubicacionAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetConectionString()
        {
            return _configuration.GetValue<string>("ConnectionStrings:");
        }
    }
}
