namespace JMComercialWebApi.Models.Tables
{
    public class ZonaBarrio
    {
        public int Id { get; set; }
        public int CiudadId { get; set; }
        public string? Denominacion { get; set; }
        public int? ISO { get; set; }

    }
}
