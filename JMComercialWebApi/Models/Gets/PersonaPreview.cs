﻿namespace JMComercialWebApi.Models.Gets
{
    public class PersonaPreview
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public int CiudadId { get; set; }
        public string? Ciudad { get; set; }
    }
}
