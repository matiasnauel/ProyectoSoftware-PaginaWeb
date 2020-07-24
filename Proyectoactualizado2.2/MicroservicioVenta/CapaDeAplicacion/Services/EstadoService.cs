using CapaDeDominio.Commands;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDeAplicacion.Services
{
    public interface IEstado
    {
        Estado CreateEstado(EstadoDTOs estado);
    }
    public class EstadoService : IEstado
    {
        private readonly IGenericRepository _repository;
        public EstadoService(IGenericRepository repositorio)
        {
            _repository = repositorio;
        }
        public Estado CreateEstado(EstadoDTOs estado)
        {

            TipoEstado navigatorTipoEstado = _repository.GetBy<TipoEstado>(estado.Tipoestado);
            VentaReclamo navigatorReclamo = _repository.GetBy<VentaReclamo>(estado.Id_ventaReclamo);
            var entity = new Estado()
            {
                Nombre = estado.Nombre,
                Id_ventaReclamo = estado.Id_ventaReclamo,
                Tipoestado = estado.Tipoestado,
                TipoEstadoNavigator = navigatorTipoEstado,
                VentaReclamoNavigator = navigatorReclamo
               
            };
            _repository.Add(entity);
            return entity;
        }
    }
}
