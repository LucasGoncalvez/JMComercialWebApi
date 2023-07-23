using JMComercialWebApi.Data;
using JMComercialWebApi.Data.Abstracts;
using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Services
{
    public class DocumentoService : ITipoDocumentoAction
    {
        private readonly IDatabase _database;
        public DocumentoService(IDatabase database)
        {
            _database = database;
        }
        public async Task<int?> Add(TipoDocumento entity)
        {
            return await _database._documentoAction.Add(entity);
        }

        public async Task Delete(int id)
        {
            await await _database._documentoAction.Delete(id);
        }

        public async Task<TipoDocumento?> Get(int id)
        {
            return await _database._documentoAction.Get(id);
        }

        public async Task<List<TipoDocumento>?> GetAll()
        {
            return await _database._documentoAction.GetAll();
        }

        public Task<int?> Update(TipoDocumento entity)
        {
            return _database._documentoAction.Update(entity);
        }
    }
}
