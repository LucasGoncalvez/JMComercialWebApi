namespace JMComercialWebApi.Models.Tables
{
    public class Ciudad
    {
        public int Id { get; set; }
        public int DepartamentoId { get; set; }
        public string? Denominacion { get; set; }
        public int? ISO { get; set; }
        
    }
}
