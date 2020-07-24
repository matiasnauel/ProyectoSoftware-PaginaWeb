using CapaDeDominio.Commands;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDeAplicacion.Services
{
    public interface ITipoEstadoService
    {
        TipoEstado CrearTipoEstado(TipoEstadoDTOs tipo);
        ICollection<TipoEstado> GetTipoEstado();
        bool DeleteTipoEstado(TipoEstadoDTOs tipoestado);
        bool UpdateEstado(TipoEstadoDTOs tipoestado);
        TipoEstado GetId(int id);
    }
   public class TipoEstadoService : ITipoEstadoService
    {
        private IGenericRepository _repository;
        public TipoEstadoService(IGenericRepository repositorio)
        {
            _repository = repositorio;
        }

        public TipoEstado CrearTipoEstado(TipoEstadoDTOs tipo)
        {
            var entity = new TipoEstado()
            {
                Tipo = tipo.Tipo
            };
            _repository.Add(entity);
            return entity;
        }

        public bool DeleteTipoEstado(TipoEstadoDTOs tipoestado)
        {
            var entity = new TipoEstado()
            {
                Id = tipoestado.Id,
                Tipo =  tipoestado.Tipo
            };
            return _repository.Delete<TipoEstado>(entity);
        }

        public TipoEstado GetId(int id)
        {
            return _repository.GetBy<TipoEstado>(id);
        }

        public ICollection<TipoEstado> GetTipoEstado()
        {
            return _repository.GetALL<TipoEstado>().ToList();
        }

        public bool UpdateEstado(TipoEstadoDTOs tipoestado)
        {
            var entity = new TipoEstado()
            {
                Id = tipoestado.Id,
                Tipo = tipoestado.Tipo
            };
            return _repository.Update<TipoEstado>(entity);
        }

    }
}
