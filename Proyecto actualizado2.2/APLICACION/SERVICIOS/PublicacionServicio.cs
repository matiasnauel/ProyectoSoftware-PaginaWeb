using DOMINIO.COMANDOS;
using DOMINIO.DTOS;
using DOMINIO.ENTIDADES;
using DOMINIO.QUERYS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APLICACION.SERVICIOS
{

    public interface IPublicacionServicio 
    {

       Publicacion CrearPublicacion(int productoID);
        List<Publicacion> GetPublicaciones();
        Publicacion GetPublicacionesID(int publicacionID);
        Task<ProductoEspecificoDto> GetProductoID(int publicacionID);

        public List<string> PaginacionComentarios(PaginacionComentarioDto json);

        Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltro(string filtro);

        Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroDescripcion(string filtro);

        Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroCategoria(string filtro);
        Task<List<ProductoEspecificoDto>> getProductosPublicacioens(int CANTIDAD);

        public Task<productoYcomentariosDTO> ProductoYcomentariosDePublicacion(int publicacionID, int offset);
    }
    public class PublicacionServicio : IPublicacionServicio
    {

        private readonly IGenericsRepository repository;
        private readonly IQueryPublicacion query;

        public PublicacionServicio(IGenericsRepository repository, IQueryPublicacion query)
        {
            this.repository = repository;
            this.query = query;
        }


        public Publicacion CrearPublicacion(int productoID)
        {
            Publicacion publicacion = new Publicacion
            {
                ProductoID = productoID
            };
            return repository.Agregar<Publicacion>(publicacion);
        }

        public Task<ProductoEspecificoDto> GetProductoID(int publicacionID)
        {
            return query.GetProducto(publicacionID);
        }

        public Task<List<ProductoEspecificoDto>> getProductosPublicacioens(int CANTIDAD)
        {
            return query.getProductosPublicaciones(CANTIDAD);
        }

       

        public List<Publicacion> GetPublicaciones()
        {
            return query.GetPublicaciones();
        }

        public Publicacion GetPublicacionesID(int publicacionID)
        {
            return query.GetPublicacionesID(publicacionID);
        }

        public List<string> PaginacionComentarios(PaginacionComentarioDto json)
        {
            return query.PaginacionComentarios(json);
        }

        public Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltro(string filtro)
        {
            return query.ProductosPublicacionFiltro(filtro);
        }

        public Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroCategoria(string filtro)
        {
            return query.ProductosPublicacionFiltroCategoria(filtro);
        }

        public Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroDescripcion(string filtro)
        {
            return query.ProductosPublicacionFiltroDescripcion(filtro);
        }

        public Task<productoYcomentariosDTO> ProductoYcomentariosDePublicacion(int publicacionID, int offset)
        {
            return query.ProductoYcomentariosDePublicacion(publicacionID,offset);
        }
    }
}
