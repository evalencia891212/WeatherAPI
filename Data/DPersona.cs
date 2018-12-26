using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ASISCOM.Entities;


namespace ASISCOM.Data
{
    public class DPersona : Conexion
    {
        public List<EPersona> BuscarPersonas()
        {
            DataTable dt = null;
            try
            {
                AbrirConexion();
                accesoDatos.LimpiarParametros();
                accesoDatos.TipoComando = CommandType.StoredProcedure;
                accesoDatos.Consulta = accesoDatos.ObtenerConsultaXml(Constantes.RutaSP, "ObtenerPersonas");
                //accesoDatos.ListaParametros.Add(new SqlParameter("@codigo_barras", parametro.CodigoBarras));
                dt = accesoDatos.CargarTabla();
                return accesoDatos.ListarDatos(new Entities.EPersona(), dt, false).ConvertAll(new Converter<object, Entities.EPersona>(delegate (object objeto) { return (Entities.EPersona)objeto; }));
            }
            finally
            {
                dt = null;
                CerrarConexion();
                accesoDatos.LimpiarParametros();
            }
        }

        public DataTable ObtenerCarteraGeneral()
        {
            DataTable dt = null;
            try
            {
                AbrirConexion();
                accesoDatos.LimpiarParametros();
                accesoDatos.TipoComando = CommandType.StoredProcedure;
                accesoDatos.Consulta = accesoDatos.ObtenerConsultaXml(Constantes.RutaSP, "ObtenerCarteraGeneral");
                //accesoDatos.ListaParametros.Add(new SqlParameter("@codigo_barras", parametro.CodigoBarras));
                dt = accesoDatos.CargarTabla();
                return dt;
            }
            finally
            {
                dt = null;
                CerrarConexion();
                accesoDatos.LimpiarParametros();
            }
        }

        public DataTable ObtenerUltimosAbonos()
        {
            DataTable dt = null;
            try
            {
                AbrirConexion();
                accesoDatos.LimpiarParametros();
                accesoDatos.TipoComando = CommandType.StoredProcedure;
                accesoDatos.Consulta = accesoDatos.ObtenerConsultaXml(Constantes.RutaSP, "ObtenerUltimosAbonos");
                //accesoDatos.ListaParametros.Add(new SqlParameter("@codigo_barras", parametro.CodigoBarras));
                dt = accesoDatos.CargarTabla();
                return dt;
            }
            finally
            {
                dt = null;
                CerrarConexion();
                accesoDatos.LimpiarParametros();
            }
        }

        
    }
}
