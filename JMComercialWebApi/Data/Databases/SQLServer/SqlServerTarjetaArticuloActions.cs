using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Databases.SQLServer
{
    //Lógica para realizar las acciones correspondientes a la entidad TarjetaArticulo con la base de datos SQL Server
    public class SqlServerTarjetaArticuloActions : TarjetaArticuloBase
    {
        public SqlServerTarjetaArticuloActions(string connectionString) : base(connectionString)
        {
        }

        public override Task Add(TarjetaArticulo entity)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<TarjetaArticulo> Get(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<TarjetaArticulo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task Update(TarjetaArticulo entity)
        {
            throw new NotImplementedException();
        }
    }
}
