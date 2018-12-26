using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using APIWeather.Entities;

namespace APIWeather.Data
{
    public class DCity : Conexion
    {
        public List<ECity> GetCities()
        {
            DataTable dt = null;
            try
            {
                AbrirConexion();
                accesoDatos.LimpiarParametros();
                accesoDatos.TipoComando = CommandType.StoredProcedure;
                accesoDatos.Consulta =  "GetCities";
                dt = accesoDatos.CargarTabla();
                return accesoDatos.ListarDatos(new ECity(), dt, false).ConvertAll(new Converter<object, ECity>(delegate (object objeto) { return (ECity)objeto; }));
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
