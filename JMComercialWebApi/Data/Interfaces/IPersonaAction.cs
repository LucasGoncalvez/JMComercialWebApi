using JMComercialWebApi.Models.Details;
using JMComercialWebApi.Models.Gets;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Interfaces
{
    public interface IPersonaAction
    {
        public Task<PersonaDetail?> Get(int id);
        public Task<List<PersonaPreview>?> GetAll();
        public Task<int?> Add(Persona entity); //Retornará el id con que se agregó el nuevo registro
        public Task<int?> Update(Persona entity); //Retornará la cantidad de registros modificados
        public Task Delete(int id); //No sé que retornar
        public Task<List<PersonaContactoDetail>?> GetContactos(int id);
        public Task<List<int?>?> AddContactos(List<PersonaContacto>? listaContacots); //Retornará la lista de id's de los nuevos registros
        public Task<int?> UpdateContactos(List<PersonaContacto> contacto);
        public Task DeleteContacto(int contactoId);
    }
}
