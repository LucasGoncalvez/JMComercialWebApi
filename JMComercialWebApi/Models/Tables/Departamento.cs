namespace JMComercialWebApi.Models.Tables
{
    public class Departamento
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public string? Denominacion { get; set; }
        public int? ISO { get; set;}

    }
}
