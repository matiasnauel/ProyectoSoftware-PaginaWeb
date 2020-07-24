using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDeDominio.DTOs
{
    public class VentaDTOs
    {
        public int Id { get; set; }
        public int Id_cliente { get; set; }
        public int Id_carrito { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Id_destinoventa { get; set; }
        public int Id_tomapago { get; set; }
        public int Id_estadoventa { get; set; }
    }
}
