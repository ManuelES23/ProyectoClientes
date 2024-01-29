using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clientes.Models
{
    public partial class Prospecto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Calle { get; set; }
        public int? Numero { get; set; }
        public string? Colonia { get; set; }
        public int? CodigoPostal { get; set; }
        public int? Telefono { get; set; }
        public string? Rfc { get; set; }
        public string? Estatus { get; set; }
        public string? Activo { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Observaciones { get; set; }
        [NotMapped]
        public IFormFile? Archivo { get; set; }
        public string? NombreArchivo { get; set; }
    }
}
