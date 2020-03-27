using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataVentas.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public int UsuarioId { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombres = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            UsuarioId = 0;
        }
    }
}
