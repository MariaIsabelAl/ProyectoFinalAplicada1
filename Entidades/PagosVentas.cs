using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataVentas.Entidades
{
    public class PagosVentas
    {
        [Key]
        public int PagoVentaId { get; set; }
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public decimal Descuento { get; set; }
        public int UsuarioId { get; set; }

        public PagosVentas()
        {
            PagoVentaId = 0;
            VentaId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
            Descuento = 0;
            UsuarioId = 0;

        }
    }
}
