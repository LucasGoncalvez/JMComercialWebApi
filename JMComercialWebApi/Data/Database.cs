namespace JMComercialWebApi.Data
{
    public class SQLServer : IDatabase
    {
        public void GetConection()
        {
            Console.WriteLine("SQLServer");
        }
    }

    public class PostgreSQL : IDatabase
    {
        public void GetConection()
        {
            Console.WriteLine("PostgreSQL");
        }
    }

    public class Oracle : IDatabase
    {
        public void GetConection()
        {
            Console.WriteLine("Oracle");
        }
    }

    public class MySQL : IDatabase
    {
        public void GetConection()
        {
            Console.WriteLine("MySQL");
        }
    }

    public class MariaDB : IDatabase
    {
        public void GetConection()
        {
            Console.WriteLine("MariaDB");
        }
    }

    public class Db2 : IDatabase
    {
        public void GetConection()
        {
            Console.WriteLine("Db2");
        }
    }

    public class SQLite : IDatabase
    {
        public void GetConection()
        {
            Console.WriteLine("SQLite");
        }
    }
}
