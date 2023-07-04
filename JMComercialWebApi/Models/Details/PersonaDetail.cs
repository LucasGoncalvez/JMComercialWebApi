namespace JMComercialWebApi.Models.Details
{
    public class PersonaDetail
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public int PaisId { get; set; }
        public string? Pais { get; set; }
        public int DepartamentoId { get; set; }
        public string? Departamento { get; set; }
        public int CiudadId { get; set; }
        public string? Ciudad { get; set; }
        public int? ZonaBarrioId { get; set; }
        public string? ZonaBarrio { get; set; }
        public string? Direccion { get; set; }
        public string? Geolocalizacion { get; set; }
        public int? LoginIdAlta { get; set; }
        public string? LoginAlta { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? LoginIdUltMod { get; set; }
        public string? LoginUltMod { get; set; }
        public DateTime? FechaUltMod { get; set; }
        public bool Habilitado { get; set; }
    }
}
