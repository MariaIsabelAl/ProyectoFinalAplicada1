using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataVentas.Entidades
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public DateTime Fecha{ get; set; }
        public string  TipoCompra { get; set; }
        public string Efectivo { get; set; }
        public string Tarjeta { get; set; }
        public string Devuelta { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
        public double  Descuento { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("CompraId")]
        public virtual List<ComprasDetalles> CompraDetalle { get; set; }

        public Compras()
        {
            CompraId = 0;
            Fecha = DateTime.Now;
            TipoCompra = string.Empty;
            Efectivo = string.Empty;
            Tarjeta = string.Empty;
            Devuelta = string.Empty;
            Monto = 0;
            Balance = 0;
            Descuento = 0;
            UsuarioId = 0;

            CompraDetalle = new List<ComprasDetalles>();
        }
       
    }
}
