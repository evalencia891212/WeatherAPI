using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ASISCOM.Entities;


namespace ASISCOM.Data
{
    public class DProducto : Conexion
    {
        public List<EProducto> BuscarProducto(EProducto parametro)
        {
            DataTable dt = null;
            try
            {
                AbrirConexion();
                accesoDatos.LimpiarParametros();
                accesoDatos.TipoComando = CommandType.StoredProcedure;
                accesoDatos.Consulta = accesoDatos.ObtenerConsultaXml(Constantes.RutaSP, "ObtenerProductoCB");
                accesoDatos.ListaParametros.Add(new SqlParameter("@codigo_barras", parametro.CodigoBarras));
                dt = accesoDatos.CargarTabla();
                return accesoDatos.ListarDatos(new Entities.EProducto(), dt, false).ConvertAll(new Converter<object, Entities.EProducto>(delegate (object objeto) { return (Entities.EProducto)objeto; }));
            }
            finally
            {
                dt = null;
                CerrarConexion();
                accesoDatos.LimpiarParametros();
            }
        }

        public List<EProducto> BuscarProductos()
        {
            DataTable dt = null;
            try
            {
                AbrirConexion();
                accesoDatos.LimpiarParametros();
                accesoDatos.TipoComando = CommandType.StoredProcedure;
                accesoDatos.Consulta = accesoDatos.ObtenerConsultaXml(Constantes.RutaSP, "ObtenerProductos");
                dt = accesoDatos.CargarTabla();
                return accesoDatos.ListarDatos(new Entities.EProducto(), dt, false).ConvertAll(new Converter<object, Entities.EProducto>(delegate (object objeto) { return (Entities.EProducto)objeto; }));
            }
            finally
            {
                dt = null;
                CerrarConexion();
                accesoDatos.LimpiarParametros();
            }
        }

        public void InsertarPorducto(EProducto parametro)
        {

            try
            {
                AbrirConexion();
                accesoDatos.LimpiarParametros();
                accesoDatos.TipoComando = CommandType.StoredProcedure;
                accesoDatos.Consulta = accesoDatos.ObtenerConsultaXml(Constantes.RutaSP, "InsertarProducto");
                accesoDatos.ListaParametros.Add(new SqlParameter("@IdDepartamento", parametro.IdDepartamento));
                accesoDatos.ListaParametros.Add(new SqlParameter("@IdGrupoProveedor", parametro.IdGrupoProveedor));
                accesoDatos.ListaParametros.Add(new SqlParameter("@ClaveProduco", parametro.ClaveProducto));
                accesoDatos.ListaParametros.Add(new SqlParameter("@CodigoBarras", parametro.CodigoBarras));
                accesoDatos.ListaParametros.Add(new SqlParameter("@TipoProducto", parametro.TipoProducto));
                accesoDatos.ListaParametros.Add(new SqlParameter("@Descripcion", parametro.Descripcion));
                accesoDatos.ListaParametros.Add(new SqlParameter("@IdUnidad", parametro.IdUnidad));
                accesoDatos.ListaParametros.Add(new SqlParameter("@Precio", parametro.Precio));
                accesoDatos.ListaParametros.Add(new SqlParameter("@VentaAGranel", parametro.VentaAGranel));
                accesoDatos.ListaParametros.Add(new SqlParameter("@PrecioCosto", parametro.PrecioCosto));
              
            }
            finally
            {
                CerrarConexion();
                accesoDatos.LimpiarParametros();
            }
        }

    }
}
