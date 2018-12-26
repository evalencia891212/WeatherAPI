using ASISCOM.Data;
using ASISCOM.Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Data
{
    public class Ddocumento : Conexion
    {
        public List<EDocumento> ObtenerDocumentos()
        {
            DataTable dt = null;
            try
            {
                AbrirConexion();
                accesoDatos.LimpiarParametros();
                accesoDatos.TipoComando = CommandType.StoredProcedure;
                accesoDatos.Consulta = accesoDatos.ObtenerConsultaXml(Constantes.RutaSP, "ObtenerDocumentos");
                //accesoDatos.ListaParametros.Add(new SqlParameter("@codigo_barras", parametro.CodigoBarras));
                dt = accesoDatos.CargarTabla();
                return accesoDatos.ListarDatos(new EDocumento(), dt, false).ConvertAll(new Converter<object, EDocumento>(delegate (object objeto) { return (EDocumento)objeto; }));
            }
            finally
            {
                dt = null;
                CerrarConexion();
                accesoDatos.LimpiarParametros();
            }
        }

        public List<EDocumentoDetalle> ObtenerDocumentosDetalle()
        {
            DataTable dt = null;
            try
            {
                AbrirConexion();
                accesoDatos.LimpiarParametros();
                accesoDatos.TipoComando = CommandType.StoredProcedure;
                accesoDatos.Consulta = accesoDatos.ObtenerConsultaXml(Constantes.RutaSP, "ObtenerDocumentosDetalle");
                //accesoDatos.ListaParametros.Add(new SqlParameter("@codigo_barras", parametro.CodigoBarras));
                dt = accesoDatos.CargarTabla();
                return accesoDatos.ListarDatos(new EDocumentoDetalle(), dt, false).ConvertAll(new Converter<object, EDocumentoDetalle>(delegate (object objeto) { return (EDocumentoDetalle)objeto; }));
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
