using ASISCOM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASISCOM.Data;

namespace Business
{
    public class BProducto
    {
        EProducto EProducto = new EProducto();
        public List<EProducto> BuscarProducto(EProducto EProducto)
        {
            return new DProducto().BuscarProducto(EProducto);
        }

        public List<EProducto> BuscarProductos()
        {
            return new DProducto().BuscarProductos();
        }
    }
}
