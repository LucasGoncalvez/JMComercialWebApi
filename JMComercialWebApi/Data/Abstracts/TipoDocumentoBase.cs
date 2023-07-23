using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Abstracts
{
    public abstract class TipoDocumentoBase : ITipoDocumentoAction
    {
        public readonly string _connectionString;
        public TipoDocumentoBase(string connectionString)
        {
            _connectionString = connectionString;
        }
        public abstract Task<int?> Add(TipoDocumento entity);

        public abstract Task Delete(int id);

        public abstract Task<TipoDocumento?> Get(int id);

        public abstract Task<List<TipoDocumento>?> GetAll();

        public abstract Task<int?> Update(TipoDocumento entity);
    }
}
