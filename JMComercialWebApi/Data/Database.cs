namespace JMComercialWebApi.Data
{
    public class SQLServer : IDatabase
    {
        private readonly IConfiguration _configuration;
        public SQLServer(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
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
        }
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
        public string GetConectionString()
        {
            return _configuration.GetValue<string>("ConnectionStrings:");
        }
    }
}
