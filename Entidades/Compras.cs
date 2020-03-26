using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataVentas.Entidades
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public int UsuarioId { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public double  Descuento { get; set; }
        public string Descripcion { get; set; }

        public Compras()
        {
            CompraId = 0;
            UsuarioId = 0;
            Precio = 0;
            Cantidad = 0;
            Total = 0;
            Descuento = 0.0;
            Descripcion = string.Empty;
            
        }
       
    }
}
