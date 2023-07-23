using JMComercialWebApi.Models.Details;
using JMComercialWebApi.Models.Gets;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Interfaces
{
    public interface ITipoDocumentoAction
    {
        public Task<List<TipoDocumento>?> GetAll();
        public Task<TipoDocumento?> Get(int id);
        public Task<int?> Add(TipoDocumento entity); //Retornará el id con que se agregó el nuevo registro
        public Task<int?> Update(TipoDocumento entity); //Retornará la cantidad de registros modificados
        public Task Delete(int id); //Retornar cantidad de filas eliminadas
    }
}
