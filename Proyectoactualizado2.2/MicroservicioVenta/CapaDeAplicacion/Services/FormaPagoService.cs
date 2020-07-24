using CapaDeDominio.Commands;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace CapaDeAplicacion.Services
{
    public interface IFormaPagoService
    {
        FormaPago CreatePagos(FormaPagoDTOs formapago);
        ICollection<FormaPago> GetFormaPago();
        bool DeleteFormPago(FormaPagoDTOs admin);
        bool UpdateFormaPago(FormaPagoDTOs forma);
        FormaPago GetId(int id);
    }
    public class FormaPagoService : IFormaPagoService
    {
        private readonly IGenericRepository _repository;
        public FormaPagoService(IGenericRepository repositorio)
        {
            _repository = repositorio;
        }
        public FormaPago CreatePagos(FormaPagoDTOs formapago)
        {
            var entity = new FormaPago()
            {
                Forma = formapago.Forma,
                Descripcion = formapago.Descripcion
            };
            _repository.Add(entity);
            return entity;
        }

        public bool DeleteFormPago(FormaPagoDTOs formapago)
        {
            var entity = new FormaPago()
            {
                Id = formapago.Id,
                Forma = formapago.Forma,
                Descripcion = formapago.Descripcion
            };
            return _repository.Delete<FormaPago>(entity);
        }

        public ICollection<FormaPago> GetFormaPago()
        {
            return _repository.GetALL<FormaPago>().ToList();
        }

        public FormaPago GetId(int id)
        {
            return _repository.GetBy<FormaPago>(id);
        }

        public bool UpdateFormaPago(FormaPagoDTOs forma)
        {
            var entity = new FormaPago()
            {
                Id = forma.Id,
                Forma = forma.Forma,
                Descripcion = forma.Descripcion
            };
            return _repository.Update<FormaPago>(entity);
        }
    }
}
