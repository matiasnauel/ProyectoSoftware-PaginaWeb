using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDeDominio.Entity
{
    public class Venta
    {
        public int VentaId {get;set;}
        public int Id_cliente{get;set;}
        public int Id_carrito{get;set;}
        public DateTime FechaVenta{get;set;}
        
        public int Monto { get; set; }
          
        

       



       
    }
}
