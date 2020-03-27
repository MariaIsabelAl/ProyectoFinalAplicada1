using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataVentas.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Costo { get; set; }
        public int UsuarioId { get; set; }

        public Productos()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Costo = 0;
            UsuarioId = 0;
        }
    }
}
