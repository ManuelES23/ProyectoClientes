using System;
using System.Collections.Generic;

namespace Clientes.Models
{
    public partial class Cliente
    {
        public int? Id { get; set; }
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
    }
}
