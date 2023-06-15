using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Abstracts
{
    public abstract class TarjetaArticuloBase : ITarjetaArticuloActions
    {
        public string _connectionString;
        public TarjetaArticuloBase(string connectionString) 
        { 
            _connectionString = connectionString;
        }
        public abstract Task Add(TarjetaArticulo entity);

        public abstract Task Delete(int id);

        public abstract Task<TarjetaArticulo> Get(int id);

        public abstract Task<IEnumerable<TarjetaArticulo>> GetAll();

        public abstract Task Update(TarjetaArticulo entity);
    }
}
