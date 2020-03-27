using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataVentas.Entidades
{
    public class PagosCompras
    {
        [Key]
        public int PagoCompraId { get; set; }
        public int CompraId { get; set; }
        public int UsuarioId { get; set; }
        public decimal Monto { get; set; }
        public decimal Descuento { get; set; }


        public PagosCompras()
        {
            PagoCompraId = 0;
            CompraId = 0;
            UsuarioId = 0;
            Monto = 0;
            Descuento = 0;

        }
    }
}
