using APIWeather.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace APIWeather.Data
{
    public class DRecord : Conexion
    {
        public List<ERecord> getRecord(int cityId, string BeginDate, string EndDate)
        {
            DataTable dt = null;
            try
            {
                AbrirConexion();
                accesoDatos.LimpiarParametros();
                accesoDatos.TipoComando = CommandType.StoredProcedure;
                accesoDatos.Consulta = "GetRecord";
                accesoDatos.ListaParametros.Add(new SqlParameter("@cityId", cityId));
                accesoDatos.ListaParametros.Add(new SqlParameter("@beginDate", BeginDate));
                accesoDatos.ListaParametros.Add(new SqlParameter("@endDate", EndDate));
                dt = accesoDatos.CargarTabla();
                return accesoDatos.ListarDatos(new ERecord(), dt, false).ConvertAll(new Converter<object, ERecord>(delegate (object objeto) { return (ERecord)objeto; }));
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

