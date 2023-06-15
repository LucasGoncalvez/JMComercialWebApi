using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Interfaces
{
    //Acá agregamos las acciones específicas para cada entidad con la que se va a trabajar
    public interface IPersonaActions : IGenericActions<Persona>
    { 
        //Metodos específicos de la entidad Persona
        public Task<IEnumerable<PersonaContacto>> GetContactos(int id);
        public Task AddContactos(List<PersonaContacto> listaContacots);
    }

    public interface IArticuloActions : IGenericActions<Articulo>
    {
        //Metodos específicos de la entidad Articulo

    }

    public interface ITarjetaArticuloActions : IGenericActions<TarjetaArticulo>
    {
        //Metodos específicos de la entidad TarjetaArticulo

    }

}
