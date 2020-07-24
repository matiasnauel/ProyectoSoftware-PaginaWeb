using CapaDominioProductos.DTOs;
using CapaDominioProductos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominioProductos.Querys
{
   public interface IProductoQuery
    {
        List<ProductoDto> GetAllProducto();
        List<ProductoDto> BusquedaProducto(int precio);
        ProductoEspecificoDto GetProductoID(int publicacionID);
        List<ProductoEspecificoDto> GetProductosID(JsonProductoDTO json);
        List<ProductoEspecificoDto> ProductosPublicacionFiltro(JsonProductoFiltroDto json);

        ProductosCantidadValorDTO ProductosValorCarritoCliente(ValorCarritoDTO valor);

        List<ProductoEspecificoDto> ProductosPublicacionesFiltroDescripcion(JsonProductoFiltroDto json);
        List<ProductoEspecificoDto> ProductosPublicacionesFiltroCategoria(JsonProductoFiltroDto json);
    }
}
