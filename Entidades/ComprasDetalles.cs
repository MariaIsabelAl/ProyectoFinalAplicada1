using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataVentas.Entidades
{
    public class ComprasDetalles
    {
        [Key]
        public int CompraDetalleId { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int UsuarioId { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }


        public ComprasDetalles()
        {
            CompraDetalleId = 0;
            CompraId = 0;
            ProductoId = 0;
            UsuarioId = 0;
            Cantidad = 0;
            Descripcion = string.Empty;
            Precio = 0;
            Total = 0;


        }

        public ComprasDetalles(int ventaid, int productoid, int cantidad, string descripcion, decimal precio, decimal total)
        {
            CompraDetalleId = 0;
            CompraId = ventaid;
            ProductoId = productoid;
            Cantidad = cantidad;
            Descripcion = descripcion;
            Precio = precio;
            Total = total;
            Descripcion = descripcion;
        }

    }
}
