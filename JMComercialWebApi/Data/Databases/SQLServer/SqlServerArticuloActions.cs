using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Databases.SQLServer
{
    public class SqlServerArticuloActions : ArticuloBase
    {
        public SqlServerArticuloActions(string connectionString) : base(connectionString)
        {
        }

        public override Task Add(Articulo entity)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<Articulo> Get(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Articulo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task Update(Articulo entity)
        {
            throw new NotImplementedException();
        }
    }
}
