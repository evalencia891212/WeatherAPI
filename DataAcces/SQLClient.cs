using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace APIWeather.DataAcces
{
    public class SQLClient
    {
        #region "Variables privadas"

        private string cadenaConexion = string.Empty;

        private string consulta = string.Empty;

        private System.Data.CommandType tipoComando = System.Data.CommandType.StoredProcedure;

        private System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> listaParametros = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>();

        private System.Data.SqlClient.SqlConnection conexion = null;

        #endregion

        #region "Constructores"

        public SQLClient()
        {
        }

        public SQLClient(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        #endregion

        #region "Propiedades públicas"

        public string CadenaConexion
        {
            get { return this.cadenaConexion; }
            set { this.cadenaConexion = value; }
        }

        public string Consulta
        {
            get { return this.consulta; }
            set { this.consulta = value; }
        }

        public System.Data.CommandType TipoComando
        {
            get { return this.tipoComando; }
            set { this.tipoComando = value; }
        }

        public System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> ListaParametros
        {
            get { return this.listaParametros; }
            set { this.listaParametros = value; }
        }

        #endregion

        #region "Métodos públicos"

        public void AbrirConexion()
        {
            try
            {
                this.EstablecerProveedorConexion(ref this.conexion);

                this.conexion.ConnectionString = this.CadenaConexion;

                this.conexion.Open();
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("AccesoDatos.Persistencia", "AccesoDatos.Persistencia.Error. " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (this.conexion != null)
                {
                    if (this.conexion.State != System.Data.ConnectionState.Closed)
                    {
                        this.conexion.Close();
                    }
                }
            }
            finally
            {
                if (this.conexion != null)
                {
                    this.conexion.Dispose();
                }

                this.conexion = null;
            }
        }

        public int Ejecutar()
        {
            System.Data.SqlClient.SqlCommand comando = null;

            try
            {

                if (this.SiExisteConexion(ref this.conexion) == false)
                {
                    throw new System.InvalidOperationException("No existe Conexión de Clase con la Base de Datos.");
                }

                this.EstablecerProveedorComando(ref comando);

                comando.Connection = this.conexion;
                comando.CommandTimeout = 0;
                comando.CommandType = this.TipoComando;
                comando.CommandText = this.Consulta;

                for (int i = 0; i < this.ListaParametros.Count; i++)
                {
                    comando.Parameters.Add(this.ListaParametros[i]);
                }

                return comando.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                if (comando != null)
                {
                    comando.Dispose();
                }

                comando = null;

                if (this.SiLimpiarParametros() == true)
                {
                    this.LimpiarParametros();
                }
            }
        }
        public System.Data.DataTable CargarTabla()
        {
            System.Data.SqlClient.SqlCommand comando = null;
            System.Data.SqlClient.SqlDataAdapter adaptador = null;
            System.Data.DataSet conjuntoDatos = new System.Data.DataSet("ConjuntoDatos");

            try
            {

                if (this.SiExisteConexion(ref this.conexion) == false)
                {
                    throw new System.InvalidOperationException("No existe Conexión de Clase con la Base de Datos.");
                }

                this.EstablecerProveedorComando(ref comando);

                comando.Connection = this.conexion;
                comando.CommandTimeout = 0;
                comando.CommandType = this.TipoComando;
                comando.CommandText = this.Consulta;

                for (int i = 0; i < this.ListaParametros.Count; i++)
                {
                    comando.Parameters.Add(this.ListaParametros[i]);
                }

                this.EstablecerProveedorAdaptador(ref adaptador, ref comando);

                adaptador.Fill(conjuntoDatos);

                conjuntoDatos.Tables[0].TableName = "Tabla";

                return conjuntoDatos.Tables["Tabla"];
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                if (comando != null)
                {
                    comando.Dispose();
                }

                comando = null;

                adaptador = null;

                if (conjuntoDatos != null)
                {
                    conjuntoDatos.Dispose();
                }

                conjuntoDatos = null;

                if (this.SiLimpiarParametros() == true)
                {
                    this.LimpiarParametros();
                }
            }
        }

        public System.Data.DataSet CargarConjuntoDatos()
        {
            System.Data.SqlClient.SqlCommand comando = null;
            System.Data.SqlClient.SqlDataAdapter adaptador = null;
            System.Data.DataSet conjuntoDatos = new System.Data.DataSet("ConjuntoDatos");

            try
            {

                if (this.SiExisteConexion(ref this.conexion) == false)
                {
                    throw new System.InvalidOperationException("No existe Conexión de Clase con la Base de Datos.");
                }

                this.EstablecerProveedorComando(ref comando);

                comando.Connection = this.conexion;
                comando.CommandTimeout = 0;
                comando.CommandType = this.TipoComando;
                comando.CommandText = this.Consulta;

                for (int i = 0; i < this.ListaParametros.Count; i++)
                {
                    comando.Parameters.Add(this.ListaParametros[i]);
                }

                this.EstablecerProveedorAdaptador(ref adaptador, ref comando);

                adaptador.Fill(conjuntoDatos);
                ;
                return conjuntoDatos;
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                if (comando != null)
                {
                    comando.Dispose();
                }

                comando = null;

                adaptador = null;

                if (conjuntoDatos != null)
                {
                    conjuntoDatos.Dispose();
                }

                conjuntoDatos = null;

                if (this.SiLimpiarParametros() == true)
                {
                    this.LimpiarParametros();
                }
            }
        }

        public object ObtenerEscalar()
        {
            System.Data.SqlClient.SqlCommand comando = null;

            try
            {

                if (this.SiExisteConexion(ref this.conexion) == false)
                {
                    throw new System.InvalidOperationException("No existe Conexión de Clase con la Base de Datos.");
                }

                this.EstablecerProveedorComando(ref comando);

                comando.Connection = this.conexion;
                comando.CommandTimeout = 0;
                comando.CommandType = this.TipoComando;
                comando.CommandText = this.Consulta;

                for (int i = 0; i < this.ListaParametros.Count; i++)
                {
                    comando.Parameters.Add(this.ListaParametros[i]);
                }

                return comando.ExecuteScalar();
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                if (comando != null)
                {
                    comando.Dispose();
                }

                comando = null;

                if (this.SiLimpiarParametros() == true)
                {
                    this.LimpiarParametros();
                }
            }
        }

        public System.Collections.Generic.List<object> ListarDatos(object instancia, System.Data.DataTable tablaDatos, bool ordenado)
        {
            System.ComponentModel.PropertyDescriptorCollection coleccionCampos = null;
            object copiaInstancia = null;
            System.Collections.Generic.List<object> listaInstancia = new System.Collections.Generic.List<object>();

            int posicion;

            try
            {
                if (instancia == null)
                {
                    throw new System.ArgumentNullException("instancia", "La Instancia del objeto no puede ser null.");
                }

                if (tablaDatos == null)
                {
                    throw new System.ArgumentNullException("tablaDatos", "La Tabla de datos no puede ser null.");
                }

                coleccionCampos = System.ComponentModel.TypeDescriptor.GetProperties(instancia);

                for (int i = 0; i < tablaDatos.Rows.Count; i++)
                {
                    copiaInstancia = this.ClonarObjeto<object>(instancia);

                    posicion = 0;

                    for (int j = 0; j < tablaDatos.Columns.Count; j++)
                    {
                        for (int k = posicion; k < coleccionCampos.Count; k++)
                        {
                           
                            if (tablaDatos.Columns[j].ColumnName == coleccionCampos[k].Name)
                            {
                                coleccionCampos[k].SetValue(copiaInstancia, System.Convert.ChangeType(tablaDatos.Rows[i][j], coleccionCampos[k].PropertyType));

                                if (ordenado == true)
                                {
                                    posicion = k + 1;
                                }

                                break;
                            }
                        }
                    }

                    listaInstancia.Add(copiaInstancia);
                }

                return listaInstancia;
            }
            finally
            {
                copiaInstancia = null;

                coleccionCampos = null;

                listaInstancia = null;
            }
        }
        public System.Data.SqlClient.SqlParameter GenerarParametro(string nombre, object valor, System.Data.DbType tipoDato, System.Data.ParameterDirection direccion)
        {
            System.Data.SqlClient.SqlParameter parametro = null;

            try
            {
                this.EstablecerProveedorParametro(ref parametro);

                parametro.ParameterName = nombre;
                parametro.Value = valor;
                parametro.DbType = tipoDato;
                parametro.Direction = direccion;

                return parametro;
            }
            finally
            {
                parametro = null;
            }
        }

        public void LimpiarParametros()
        {
            this.ListaParametros.Clear();
        }

        public string ObtenerConsultaXml(string nombreArchivoExtension, string etiquetaConsulta)
        {
            System.Uri rutaUri = null;
            System.Xml.XmlDocument documento = new System.Xml.XmlDocument();
            System.Xml.XmlNode nodo;

            string rutaConsultasXml = string.Empty;
            string consulta = string.Empty;

            try
            {
                rutaConsultasXml = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + "\\" + nombreArchivoExtension;
                rutaUri = new System.Uri(rutaConsultasXml);
                rutaConsultasXml = rutaUri.LocalPath;

                documento.Load(rutaConsultasXml);
                nodo = documento.SelectSingleNode("/configuration/Consulta[@EtiquetaId='" + etiquetaConsulta + "']");

                if (nodo == null)
                {
                    throw new System.Xml.XmlException("No se ha encontrado la Etiqueta Nodo de la Consulta.");
                }
                else
                {
                    consulta = nodo.InnerText;
                }

                return consulta;
            }
            finally
            {
                rutaUri = null;
                documento = null;
                nodo = null;
            }
        }

        #endregion

        #region "Métodos privados"

        private void EstablecerProveedorConexion(ref System.Data.SqlClient.SqlConnection conexion)
        {

            conexion = new System.Data.SqlClient.SqlConnection();
        }

        private void EstablecerProveedorComando(ref System.Data.SqlClient.SqlCommand comando)
        {

            comando = new System.Data.SqlClient.SqlCommand();
        }

        private void EstablecerProveedorAdaptador(ref System.Data.SqlClient.SqlDataAdapter adaptador, ref System.Data.SqlClient.SqlCommand comando)
        {
            adaptador = new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)comando);
        }

        private void EstablecerProveedorParametro(ref System.Data.SqlClient.SqlParameter parametro)
        {
            parametro = new System.Data.SqlClient.SqlParameter();
        }

        private bool SiExisteConexion(ref System.Data.SqlClient.SqlConnection conexion)
        {
            bool existeConexion = false;

            if (conexion != null)
            {
                if (conexion.State != System.Data.ConnectionState.Closed && conexion.State != System.Data.ConnectionState.Broken && conexion.State != System.Data.ConnectionState.Connecting)
                {
                    existeConexion = true;
                }
            }

            return existeConexion;
        }

        private string ObtenerCadenaParametros()
        {
            System.Text.StringBuilder cadenaParametros = new System.Text.StringBuilder();

            try
            {
                for (int i = 0; i < this.ListaParametros.Count; i++)
                {
                    cadenaParametros.Append(this.ListaParametros[i].ParameterName + " " + this.ListaParametros[i].Value.ToString() + " " + this.ListaParametros[i].DbType.ToString() + " " + this.ListaParametros[i].Direction.ToString() + "; ");
                }

                return cadenaParametros.ToString();
            }
            finally
            {
                cadenaParametros = null;
            }
        }

        private bool SiLimpiarParametros()
        {
            bool limpiarParametros = true;

            for (int i = 0; i < this.ListaParametros.Count; i++)
            {
                if (this.ListaParametros[i].Direction != System.Data.ParameterDirection.Input)
                {
                    limpiarParametros = false;
                    break;
                }
            }

            return limpiarParametros;
        }

        private Tipo ClonarObjeto<Tipo>(Tipo origen)
        {
            System.Runtime.Serialization.IFormatter formateador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.Stream stream = new System.IO.MemoryStream();

            try
            {
                if (!typeof(Tipo).IsSerializable)
                {
                    throw new System.ArgumentException("El Tipo origen debe ser serializable.", "origen");
                }

                if (object.ReferenceEquals(origen, null))
                {
                    return default(Tipo);
                }

                formateador.Serialize(stream, origen);

                stream.Seek(0, System.IO.SeekOrigin.Begin);

                return (Tipo)formateador.Deserialize(stream);
            }
            finally
            {
                formateador = null;

                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }

                stream = null;
            }
        }

        #endregion
    }
}
