namespace JMComercialWebApi.Models.Tables
{
    public class TipoDocumento
    {
        public int Id { get; set; }
        public string? Denominacion { get; set; }
        public string? Abreviatura { get; set;}
        public bool Habilitado { get; set; }
    }
}
