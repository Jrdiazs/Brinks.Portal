using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Clase de conexion
    /// </summary>
    public class Connection : IDisposable, IConnection
    {
        /// <summary>
        /// Configuracion de sitio
        /// </summary>
        private readonly IAppConfiguration _config;

        /// <summary>
        /// Establece el objeto de conexion
        /// </summary>
        /// <param name="dbConnection">objeto de conexion</param>
        public Connection(IDbConnection dbConnection) => DBConnection = dbConnection;

        /// <summary>
        /// Estalece la conexion por default
        /// </summary>
        public Connection()
        {
            _config = new AppConfiguration();
            DBConnection = new SqlConnection(_config.GetConnectionString("DefaultConnections"));
        }

        /// <summary>
        /// Retorna la conexion actual de base de datos
        /// </summary>
        public IDbConnection DBConnection { get; }

        /// <summary>
        /// Abre la conexion
        /// </summary>
        public void Open()
        {
            try
            {
                if (DBConnection.State != ConnectionState.Open)
                    DBConnection.Open();

                
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        /// <summary>
        /// Cierra la conexion actual
        /// </summary>
        public void Close()
        {
            try
            {
                if (DBConnection.State != ConnectionState.Closed)
                    DBConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la transaccion actual de la base de datos
        /// </summary>
        /// <param name="isolation">isolation</param>
        /// <returns>retorna la transaccion actual</returns>
        public IDbTransaction GetTransaction(IsolationLevel? isolation = null)
        {
            try
            {
                Open();

                if (isolation.HasValue)
                    return DBConnection.BeginTransaction(isolation.Value);
                else
                    return DBConnection.BeginTransaction();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region [Dispose]

        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Close();
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~Connection() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    /// <summary>
    /// Clase de conexion
    /// </summary>
    public interface IConnection : IDisposable
    {
        /// <summary>
        /// Retorna la conexion actual de base de datos
        /// </summary>
        IDbConnection DBConnection { get; }

        /// <summary>
        /// Cierra la conexion actual
        /// </summary>
        void Close();

        /// <summary>
        /// Abre la conexion
        /// </summary>
        void Open();

        /// <summary>
        /// Obtiene la transaccion actual de la base de datos
        /// </summary>
        /// <param name="isolation">isolation</param>
        /// <returns>retorna la transaccion actual</returns>
        IDbTransaction GetTransaction(IsolationLevel? isolation = null);
    }
}