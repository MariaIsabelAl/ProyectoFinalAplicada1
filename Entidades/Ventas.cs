using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataVentas.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; } 
        public int Precio { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalles> VentaDetalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            UsuarioId = 0;
            Cantidad = 0;
            Descripcion = string.Empty;
            Precio = 0;
            Total = 0;
            Descuento = 0;
            

            VentaDetalle = new List<VentasDetalles>();
        }
    }
}
