namespace JMComercialWebApi.Models.Tables
{
    public class PersonaContacto
    {
        public int Id { get; set; }
        public int? PersonaId { get; set; }
        public int? TipoContactoId { get; set; }
        public string? Valor { get; set; }
        public string? Descripcion { get; set; }
        public bool? Habilitado { get; set; }
    }
}
