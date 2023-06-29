using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Interfaces
{
    public interface IArticuloAction
    {
        public Task<List<Articulo>?> GetAll();
        public Task<Articulo?> Get(int id);
        public Task Add(Articulo entity); //Hacer que retorne el id con el que se agregó en la bd
        public Task Update(Articulo entity);
        public Task Delete(int id);
    }
}
