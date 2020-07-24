using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDeDominio.Entity
{
    public class Estado
    {
        public int Id {get;set;}

        public string Nombre{get;set;}

        public  int Id_ventaReclamo{get;set;}

        public int Tipoestado{get;set;}

        public virtual TipoEstado TipoEstadoNavigator { get; set; }

        public virtual VentaReclamo VentaReclamoNavigator { get; set; }
    }
}
