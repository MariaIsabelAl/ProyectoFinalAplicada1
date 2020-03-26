using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataVentas.Entidades
{
    public class Vendedores
    {
        [Key]
        public int VendedorId { get; set; }
        public int UsuarioId { get; set; }
        public int VentaId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }

        public Vendedores()
        {
            VendedorId = 0;
            UsuarioId = 0;
            VentaId = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Clave = string.Empty;
        }
    }
}
