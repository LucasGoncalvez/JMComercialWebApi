using JMComercialWebApi.Models.Gets;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Interfaces
{
    public interface IPersonaAction
    {
        public Task<List<PersonaPreview>?> GetAll();
        public Task<Persona?> Get(int id);
        public Task<int> Add(Persona entity); //Hacer que retorne el id con el que se agregó en la bd
        public Task<int> Update(Persona entity);
        public Task<int> Delete(int id);
        public Task<List<PersonaContacto>?> GetContactos(int id);
        public Task AddContactos(List<PersonaContacto>? listaContacots);
    }
}
