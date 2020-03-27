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
        public int UsuarioId { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Total { get; set; }
        public double  Descuento { get; set; }

        [ForeignKey("CompraId")]
        public virtual List<ComprasDetalles> CompraDetalle { get; set; }

        public Compras()
        {
            CompraId = 0;
            UsuarioId = 0;
            Cantidad = 0;
            Descripcion = string.Empty;
            Precio = 0;
            Total = 0;
            Descuento = 0.0;

            CompraDetalle = new List<ComprasDetalles>();
        }
       
    }
}
