namespace JMComercialWebApi.Models.Tables
{
    public class Persona
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string? NumeroDocumento { get; set; }
        public int PaisId { get; set; }
        public int DepartamentoId { get; set; }
        public int CiudadId { get; set; }
        public int? ZonaBarrioId { get; set; }
        public string? Direccion { get; set; }
        public string? Geolocalizacion { get; set; }
        public int? LoginIdAlta { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? LoginIdUltMod { get; set; }
        public DateTime? FechaUltMod { get; set; }
        public bool Habilitado { get; set; }
    }
}
