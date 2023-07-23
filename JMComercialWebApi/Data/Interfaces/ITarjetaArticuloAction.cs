using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Interfaces
{
    public interface ITarjetaArticuloAction
    {
        public Task<List<TarjetaArticulo>?> GetAll();
        public Task<TarjetaArticulo?> Get(int id);
        public Task Add(TarjetaArticulo entity); //Hacer que retorne el id con el que se agregó en la bd
        public Task Update(TarjetaArticulo entity);
        public Task Delete(int id); //Retornar cantidad de filas eliminadas
    }
}
