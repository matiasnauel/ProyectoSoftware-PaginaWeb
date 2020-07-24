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
        public int Id_destinoventa{get;set;}
        public int Id_tomapago{get;set;}
        public int Id_estadoventa{get;set;}

          
        
        public virtual Estado EstadoVentaNavigator { get; set; }
        public virtual FormaPago FormaPagoNavigator { get; set; }
        public virtual DestinoVenta DestinoVentaNavigator { get; set; }
       



       
    }
}
