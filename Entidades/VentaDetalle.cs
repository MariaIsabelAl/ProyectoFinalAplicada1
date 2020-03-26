using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataVentas.Entidades
{
    public class VentaDetalle
    {
        [Key]
        public int VentaDetalleId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int UsuarioId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public string Descripcion { get; set; }

        public VentaDetalle()
        {
            VentaDetalleId = 0;
            VentaId = 0;
            ProductoId = 0;
            UsuarioId = 0;
            Cantidad = 0;
            Precio = 0;
            Total = 0;
            Descripcion = string.Empty;

        }

        public VentaDetalle(int ventaid, int productoid, int cantidad, decimal precio, decimal total, string descripcion)
        {
            VentaDetalleId = 0;
            VentaId = ventaid;
            ProductoId = productoid;
            Cantidad = cantidad;
            Precio = precio;
            Total = total;
            Descripcion = descripcion;
        }
        
    }
}
