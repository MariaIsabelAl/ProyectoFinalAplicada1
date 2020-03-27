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
        public int VendedorId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public string TipoVenta { get; set; }
        public string Efectivo { get; set; }
        public string Tarjeta { get; set; }
        public string Devuelta { get; set; }
        public decimal Balance { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        public int UsuarioId { get; set; }


        [ForeignKey("VentaId")]
        public virtual List<VentasDetalles> VentaDetalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            VendedorId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            TipoVenta = string.Empty;
            Efectivo = string.Empty;
            Tarjeta = string.Empty;
            Devuelta = string.Empty;
            Balance = 0;
            Total = 0;
            Descuento = 0;
            UsuarioId = 0;

            VentaDetalle = new List<VentasDetalles>();
        }
    }
}
