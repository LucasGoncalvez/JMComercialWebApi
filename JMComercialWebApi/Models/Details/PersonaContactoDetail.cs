namespace JMComercialWebApi.Models.Details
{
    public class PersonaContactoDetail
    {
        public int Id { get; set; }
        public int? PersonaId { get; set; }
        public int TipoContactoId { get; set; }
        public string? TipoContacto { get; set; }
        public string? Valor { get; set; }
        public string? Descripcion { get; set; }
        public bool? Habilitado { get; set; }
    }
}
