using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Util;
using APIWeather.DataAcces;

namespace APIWeather.Data
{
    public class Conexion
    {
        /// <summary>
        /// instancia del acceso a datos
        /// </summary>
        public SQLClient accesoDatos = new SQLClient();
        public static string cadenaConexion;

        #region Metodos genericos

        /// <summary>
        /// Abre la conexión hacia la base de datos 
        /// </summary>
        /// <param name="desdeSocket">true: el metodo fue llamado desde el socket, false: no fue llamado desde el socket, valor default: false</param>
        public void AbrirConexion()
        {
            try
            {
                accesoDatos = new SQLClient();
                accesoDatos.CadenaConexion = this.ObtenerCadenaConexion();
                accesoDatos.AbrirConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Cierra la conexión a la base de datos
        /// </summary>
        public void CerrarConexion()
        {
            try
            {
                if (accesoDatos != null)
                {
                    accesoDatos.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene la cadena de conexion a la base de datos
        /// </summary>
        /// <returns>Cadena de cionexión a la base de tatos </returns>
        public string ObtenerCadenaConexion()
        {
            //Util.Utilerias utileria = null;
            try
            {
                if (string.IsNullOrEmpty(cadenaConexion))
                {
                    //utileria = new Util.Utilerias();
                    //utileria.Clave = "";
                    //utileria.Clave = utileria.Descifrar(System.Configuration.ConfigurationManager.AppSettings["ALMCL01"]);
                    //CadenaConexion.cadenaConexion = utileria.Descifrar(System.Configuration.ConfigurationManager.AppSettings["ALMCL02"]);
                    //cadenaConexion = "Data Source=DESKTOP-85BRBE7\\SQLEXPRESS;Initial Catalog=muebleria_monarca;user id=sa; password=Dbadmin;";
                    //cadenaConexion = "Data Source=192.168.1.65;Initial Catalog=muebleria_monarca;user id=sa; password=Dbadmin;";
                    cadenaConexion = "workstation id=APIWeatherDB.mssql.somee.com;packet size=4096;user id=evalencia891212_SQLLogin_1;pwd=u1ehu959ry;data source=APIWeatherDB.mssql.somee.com;persist security info=False;initial catalog=APIWeatherDB";
                }
                return cadenaConexion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //utileria = null;
            }
        }

        #endregion
    }
}
